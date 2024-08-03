import json

from typing import Any
from typing import Optional

from .helpers import MapState
from .helpers import Prototype
from .helpers import _c_str
from .helpers import _to_str
from .helpers import _unpack_list


class ProtoGeneric:
    def __init__(self, _type: Prototype, name: str, _json: str):
        self.type = _type
        self.name = name
        self.json = _json


class Prototypes:
    def __init__(self, api, ffi, game):
        self._api = api
        self._ffi = ffi
        self.game = game
        self.game.add_map_state_callback(self._map_state_changed)

        self._hit_chances_table: dict[str, Any]
        self._terrain_types_table: dict[str, Any]

        self._all: list[int] = []
        self._types: dict[int, ProtoGeneric] = {}
        self._resources: dict[int, Any] = {}
        self._recipes: dict[int, Any] = {}
        self._constructions: dict[int, Any] = {}
        self._units: dict[int, Any] = {}

    def all(self) -> list[int]:
        return self._all

    def type(self, _id: int) -> Prototype:
        return self._types[_id].type if _id in self._types else Prototype.NONE

    def name(self, _id: int) -> str:
        return self._types[_id].name if _id in self._types else ""

    def json(self, _id: int) -> str:
        return self._types[_id].json if _id in self._types else ""

    def resource(self, _id: int) -> Optional[dict]:
        return self._resources.get(_id)

    def recipes(self, _id: int) -> Optional[dict]:
        return self._recipes.get(_id)

    def construction(self, _id: int) -> Optional[dict]:
        return self._constructions.get(_id)

    def unit(self, _id: int) -> Optional[dict]:
        return self._units.get(_id)

    def hit_chances_table(self):
        return self._hit_chances_table

    def terrain_types_table(self):
        return self._terrain_types_table

    def all_ids(self) -> list[int]:
        ids = self._ffi.new("struct UwIds *")
        self._api.uwAllPrototypes(ids)
        return _unpack_list(self._ffi, ids)

    def _load_prototypes(self):
        print("loading prototypes")

        self._all = []
        self._types = {}
        self._resources = {}
        self._recipes = {}
        self._constructions = {}
        self._units = {}

        for i in self.all_ids():
            _type = Prototype(self._api.uwPrototypeType(i))
            js = json.loads(_to_str(self._ffi, self._api.uwPrototypeJson(i)))
            if _type == Prototype.Resource:
                self._resources[i] = js
            elif _type == Prototype.Recipe:
                self._recipes[i] = js
            elif _type == Prototype.Construction:
                self._constructions[i] = js
            elif _type == Prototype.Unit:
                self._units[i] = js

            self._types[i] = ProtoGeneric(_type, js["name"], js)
            self._all.append(i)

        print("prototypes loaded")

    def _load_definitions(self):
        print("loading definitions")

        defs = json.loads(_to_str(self._ffi, self._api.uwDefinitionsJson()))
        self._hit_chances_table = defs["hitChancesTable"]
        self._terrain_types_table = defs["terrainTypesTable"]

        print("definitions loaded")

    def _map_state_changed(self, state: MapState):
        if state == MapState.Loaded:
            self._load_prototypes()
            self._load_definitions()
