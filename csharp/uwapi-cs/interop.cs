// THIS FILE IS GENERATED BY SCRIPT
// DO NOT MODIFY

using System;
using System.Runtime.InteropServices;

namespace Unnatural
{
    public static class Interop
    {
        const string LibName = "unnatural-uwapi";

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwCommandSelfDestruct(uint unit);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwCommandPlaceConstruction(uint proto, uint position, float yaw);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwCommandSetRecipe(uint unit, uint recipe);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwCommandLoadAll(uint unit, uint resourceType);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwCommandUnloadAll(uint unit);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwCommandMove(uint unit, uint position, float yaw);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwCommandAim(uint unit, uint target);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwCommandRenounceControl(uint unit);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwOrder
        {
            public uint entity;
            public uint position;
            public byte order;
            public byte priority;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwOrder(uint unit, ref UwOrder data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwOrders
        {
            public IntPtr orders;
            public uint count;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwOrders(uint unit, ref UwOrders data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UwExceptionCallbackType([MarshalAs(UnmanagedType.LPStr)] string message);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwSetExceptionCallback(UwExceptionCallbackType callback);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwLogCallback
        {
            public IntPtr message;
            public IntPtr component;
            public uint severity;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UwLogCallbackType(ref UwLogCallback data);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwSetLogCallback(UwLogCallbackType callback);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwLog(uint severity, [MarshalAs(UnmanagedType.LPStr)] string message);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwSetPlayerName([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwSetPlayerColor(float r, float g, float b);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwConnectFindLan();

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwConnectDirect([MarshalAs(UnmanagedType.LPStr)] string address, ushort port);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UwStateCallbackType(uint state);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwSetConnectionStateCallback(UwStateCallbackType callback);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwSetGameStateCallback(UwStateCallbackType callback);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint uwConnectionState();

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint uwGameState();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UwUpdateCallbackType(uint tick, [MarshalAs(UnmanagedType.I1)] bool stepping);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwSetUpdateCallback(UwUpdateCallbackType callback);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwAssistLogistics([MarshalAs(UnmanagedType.I1)] bool enabled);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwAssistAiming([MarshalAs(UnmanagedType.I1)] bool enabled);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwMyPlayer
        {
            public uint playerEntityId;
            public uint forceEntityId;
            [MarshalAs(UnmanagedType.I1)] public bool primaryController;
            [MarshalAs(UnmanagedType.I1)] public bool admin;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwMyPlayer(ref UwMyPlayer data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwShootingUnit
        {
            public uint position;
            public uint force;
            public uint prototype;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UwShootingData
        {
            public UwShootingUnit shooter;
            public UwShootingUnit target;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UwShootingCallbackType(ref UwShootingData data);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwSetShootingCallback(UwShootingCallbackType callback);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwMapInfo
        {
            public IntPtr name;
            public IntPtr guid;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwMapInfo(ref UwMapInfo data);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint uwTilesCount();

        [StructLayout(LayoutKind.Sequential)]
        public struct UwTile
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] position;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] up;
            public IntPtr neighborsIndices;
            public uint neighborsCount;
            public byte terrain;
            [MarshalAs(UnmanagedType.I1)] public bool border;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwTile(uint index, ref UwTile data);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte uwOverviewFlags(uint position);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwOverviewNames
        {
            public IntPtr names;
            public uint count;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwOverviewNames(uint position, ref UwOverviewNames data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwOverviewExtract
        {
            public IntPtr flags;
            public uint count;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwOverviewExtract(ref UwOverviewExtract data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwTiles
        {
            public IntPtr tiles;
            public uint count;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwAreaRange(float x, float y, float z, float radius, ref UwTiles data);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwAreaConnected(uint position, float radius, ref UwTiles data);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwAreaNeighborhood(uint position, float radius, ref UwTiles data);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwAreaExtended(uint position, float radius, ref UwTiles data);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwTestVisible(float x1, float y1, float z1, float x2, float y2, float z2);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwTestShooting(uint shooterPosition, uint shooterProto, uint targetPosition, uint targetProto);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float uwDistanceLine(float x1, float y1, float z1, float x2, float y2, float z2);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float uwDistanceEstimate(uint a, uint b);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float uwYaw(uint position, uint towards);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwTestValidPlacement(uint constructionPrototype, uint position);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint uwFindValidPlacement(uint constructionPrototype, uint position);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint uwPrototypesCount();

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint uwPrototypeIdFromIndex(uint index);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint uwPrototypeType(uint prototypeId);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr uwPrototypeJson(uint prototypeId);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr uwDefinitionsJson();

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr uwEntity(uint id);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint uwEntityId(IntPtr entity);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwEntitiesGroup
        {
            public IntPtr entities;
            public uint count;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwAllEntities(ref UwEntitiesGroup data);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void uwModifiedEntities(ref UwEntitiesGroup data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwProtoComponent
        {
            public uint proto;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchProtoComponent(IntPtr entity, ref UwProtoComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwOwnerComponent
        {
            public uint force;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchOwnerComponent(IntPtr entity, ref UwOwnerComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwControllerComponent
        {
            public uint player;
            public uint timestamp;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchControllerComponent(IntPtr entity, ref UwControllerComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwPositionComponent
        {
            public uint position;
            public float yaw;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchPositionComponent(IntPtr entity, ref UwPositionComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwMoveComponent
        {
            public uint posStart;
            public uint posEnd;
            public uint tickStart;
            public uint tickEnd;
            public float yawStart;
            public float yawEnd;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchMoveComponent(IntPtr entity, ref UwMoveComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwAimComponent
        {
            public uint target;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchAimComponent(IntPtr entity, ref UwAimComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwUnitComponent
        {
            public uint state;
            public uint killCount;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchUnitComponent(IntPtr entity, ref UwUnitComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwCooldownComponent
        {
            public uint timestamp;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchCooldownComponent(IntPtr entity, ref UwCooldownComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwRecipeComponent
        {
            public uint recipe;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchRecipeComponent(IntPtr entity, ref UwRecipeComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwUpdateTimestampComponent
        {
            public uint timestamp;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchUpdateTimestampComponent(IntPtr entity, ref UwUpdateTimestampComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwRecipeStatisticsComponent
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public uint[] timestamps;
            public uint processed;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchRecipeStatisticsComponent(IntPtr entity, ref UwRecipeStatisticsComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwAmountComponent
        {
            public uint amount;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchAmountComponent(IntPtr entity, ref UwAmountComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwAttachmentComponent
        {
            public uint target;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchAttachmentComponent(IntPtr entity, ref UwAttachmentComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwPlayerComponent
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)] public char[] name;
            public uint nameLength;
            public uint force;
            public float progress;
            public uint ping;
            public uint state;
            public byte playerConnectionClass;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public byte[] dummy;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchPlayerComponent(IntPtr entity, ref UwPlayerComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwForceComponent
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] color;
            public ulong score;
            public ulong killValue;
            public ulong lossValue;
            public uint killCount;
            public uint lossCount;
            public uint team;
            public uint state;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchForceComponent(IntPtr entity, ref UwForceComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwForceStartingPositionComponent
        {
            public uint startingPosition;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchForceStartingPositionComponent(IntPtr entity, ref UwForceStartingPositionComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwForeignPolicyComponent
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public uint[] forces;
            public uint policy;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchForeignPolicyComponent(IntPtr entity, ref UwForeignPolicyComponent data);

        [StructLayout(LayoutKind.Sequential)]
        public struct UwDiplomacyProposalComponent
        {
            public uint offeror;
            public uint offeree;
            public uint proposal;
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool uwFetchDiplomacyProposalComponent(IntPtr entity, ref UwDiplomacyProposalComponent data);

    }
}
