from .helpers import Order
from .helpers import OrderType
from .helpers import OrderPriority
from .helpers import Priority
from .helpers import _unpack_list


class Commands:
    invalid = 4294967295

    def __init__(self, api, ffi):
        self._api = api
        self._ffi = ffi

    def orders(self, unit: int) -> list[Order]:
        os = self._ffi.new("struct UwOrders *")
        self._api.uwOrders(unit, os)
        return [Order.from_c(o) for o in _unpack_list(self._ffi, os, "orders")]

    def order(self, unit: int, order: Order):
        o = self._ffi.new("struct UwOrder *")
        o.entity = order.entity
        o.position = order.position
        o.order = int(order.order_type)
        o.priority = int(order.priority)
        self._api.uwOrder(unit, o)

    def stop(self) -> Order:
        return Order(entity=self.invalid, position=self.invalid, order_type=OrderType.Stop, priority=OrderPriority.User)

    def guard(self) -> Order:
        return Order(entity=self.invalid, position=self.invalid, order_type=OrderType.Guard,
                     priority=OrderPriority.User)

    def run_to_position(self, position: int) -> Order:
        return Order(entity=self.invalid, position=position, order_type=OrderType.Run,
                     priority=OrderPriority.User)

    def run_to_entity(self, entity: int) -> Order:
        return Order(entity=entity, position=self.invalid, order_type=OrderType.Run,
                     priority=OrderPriority.User)

    def fight_to_position(self, position: int) -> Order:
        return Order(entity=self.invalid, position=position, order_type=OrderType.Fight,
                     priority=OrderPriority.User)

    def fight_to_entity(self, entity: int) -> Order:
        return Order(entity=entity, position=self.invalid, order_type=OrderType.Fight,
                     priority=OrderPriority.User)

    def command_self_destruct(self, unit: int):
        self._api.uwCommandSelfDestruct(unit)

    def command_place_construction(self, proto: int, position: int, yaw: float = 0):
        self._api.uwCommandPlaceConstruction(proto, position, yaw)

    def command_set_recipe(self, unit: int, recipe: int):
        self._api.uwCommandSetRecipe(unit, recipe)

    def command_set_priority(self, unit: int, priority: Priority):
        self._api.uwCommandSetPriority(unit, int(priority))

    def command_load(self, unit: int, resource_type: int):
        self._api.uwCommandLoad(unit, resource_type)

    def command_unload(self, unit: int):
        self._api.uwCommandUnload(unit)

    def command_move(self, unit: int, position: int, yaw: float = 0):
        self._api.uwCommandMove(unit, position, yaw)

    def command_aim(self, unit: int, target: int):
        self._api.uwCommandAim(unit, target)

    def command_renounce_control(self, unit: int):
        self._api.uwCommandRenounceControl(unit)
