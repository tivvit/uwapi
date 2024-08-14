using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Unnatural
{
    using PolicyEnum = Interop.UwForeignPolicyEnum;

    internal class Bot
    {
        readonly Random random = new Random();
        uint step = 0;

        void AttackNearestEnemies()
        {
            var ownUnits = World.Entities().Values.Where(x => Entity.Own(x) && Entity.Has(x, "Unit") && Prototypes.Unit(x.Proto.proto)?.dps > 0);
            if (ownUnits.Count() == 0)
                return;

            var enemyUnits = World.Entities().Values.Where(x => Entity.Policy(x) == PolicyEnum.Enemy && Entity.Has(x, "Unit"));
            if (enemyUnits.Count() == 0)
                return;

            foreach (dynamic own in ownUnits)
            {
                uint id = own.Id;
                uint pos = own.Position.position;
                if (Commands.Orders(id).Length == 0)
                {
                    dynamic enemy = enemyUnits.OrderByDescending(x => Map.DistanceEstimate(pos, x.Position.position)).First();
                    Commands.Order(id, Commands.FightToEntity(enemy.Id));
                }
            }
        }

        void AssignRandomRecipes()
        {
            foreach (dynamic own in World.Entities().Values.Where(x => Entity.Own(x) && Entity.Has(x, "Unit")))
            {
                List<uint> recipes = Prototypes.Unit((uint)own.Proto.proto).recipes;
                if (recipes?.Count > 0)
                {
                    var recipe = recipes[random.Next(recipes.Count)];
                    Commands.CommandSetRecipe((uint)own.Id, recipe);
                }
            }
        }

        void Updating(object sender, bool stepping)
        {
            if (!stepping)
                return;
            switch (step++ % 10) // save some cpu cycles by splitting work over multiple steps
            {
                case 1:
                    AttackNearestEnemies();
                    break;
                case 5:
                    AssignRandomRecipes();
                    break;
            }
        }

        void Start()
        {
            Game.LogInfo("starting");
            Game.SetPlayerName("bot-cs");
            if (!Game.TryReconnect())
            {
                Game.SetStartGui(true);
                string lobby = Environment.GetEnvironmentVariable("UNNATURAL_CONNECT_LOBBY");
                string addr = Environment.GetEnvironmentVariable("UNNATURAL_CONNECT_ADDR");
                string port = Environment.GetEnvironmentVariable("UNNATURAL_CONNECT_PORT");
                if (lobby != null)
                    Game.ConnectLobbyId(ulong.Parse(lobby));
                else if (addr != null && port != null)
                    Game.ConnectDirect(addr, ushort.Parse(port));
                else
                    Game.ConnectNewServer();
            }
            Game.LogInfo("done");
        }

        Bot()
        {
            Game.Updating += Updating;
        }

        static int Main(string[] args)
        {
            string root = Environment.GetEnvironmentVariable("UNNATURAL_ROOT");
            if (root == null)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    root = "C:/Program Files (x86)/Steam/steamapps/common/Unnatural Worlds/bin";
                else
                    root = Environment.GetEnvironmentVariable("HOME") + "/.steam/steam/steamapps/common/Unnatural Worlds/bin";
            }
            Console.WriteLine("looking for uw library in: " + root);
            System.IO.Directory.SetCurrentDirectory(root);

            Bot bot = new Bot();
            bot.Start();
            return 0;
        }
    }
}
