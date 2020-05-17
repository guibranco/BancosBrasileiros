# This code parses date/times, so please
#
#     pip install python-dateutil
#
# To use this code, make sure you
#
#     import json
#
# and then, to convert JSON from a string, do
#
#     result = bank_from_dict(json.loads(json_string))

from typing import Optional, Any, List, TypeVar, Callable, Type, cast
from datetime import datetime
import dateutil.parser


T = TypeVar("T")


def from_str(x: Any) -> str:
    assert isinstance(x, str)
    return x


def from_none(x: Any) -> Any:
    assert x is None
    return x


def from_union(fs, x):
    for f in fs:
        try:
            return f(x)
        except:
            pass
    assert False


def from_datetime(x: Any) -> datetime:
    return dateutil.parser.parse(x)


def from_bool(x: Any) -> bool:
    assert isinstance(x, bool)
    return x


def from_list(f: Callable[[Any], T], x: Any) -> List[T]:
    assert isinstance(x, list)
    return [f(y) for y in x]


def to_class(c: Type[T], x: Any) -> dict:
    assert isinstance(x, c)
    return cast(Any, x).to_dict()


class BankElement:
    compe: str
    ispb: str
    document: str
    fiscal_name: str
    fantasy_name: str
    url: Optional[str]
    date_registered: datetime
    date_updated: Optional[datetime]
    date_removed: Optional[datetime]
    is_removed: bool

    def __init__(self, compe: str, ispb: str, document: str, fiscal_name: str, fantasy_name: str, url: Optional[str], date_registered: datetime, date_updated: Optional[datetime], date_removed: Optional[datetime], is_removed: bool) -> None:
        self.compe = compe
        self.ispb = ispb
        self.document = document
        self.fiscal_name = fiscal_name
        self.fantasy_name = fantasy_name
        self.url = url
        self.date_registered = date_registered
        self.date_updated = date_updated
        self.date_removed = date_removed
        self.is_removed = is_removed

    @staticmethod
    def from_dict(obj: Any) -> 'BankElement':
        assert isinstance(obj, dict)
        compe = from_str(obj.get("COMPE"))
        ispb = from_str(obj.get("ISPB"))
        document = from_str(obj.get("Document"))
        fiscal_name = from_str(obj.get("FiscalName"))
        fantasy_name = from_str(obj.get("FantasyName"))
        url = from_union([from_none, from_str], obj.get("Url"))
        date_registered = from_datetime(obj.get("DateRegistered"))
        date_updated = from_union([from_none, from_datetime], obj.get("DateUpdated"))
        date_removed = from_union([from_none, from_datetime], obj.get("DateRemoved"))
        is_removed = from_bool(obj.get("IsRemoved"))
        return BankElement(compe, ispb, document, fiscal_name, fantasy_name, url, date_registered, date_updated, date_removed, is_removed)

    def to_dict(self) -> dict:
        result: dict = {}
        result["COMPE"] = from_str(self.compe)
        result["ISPB"] = from_str(self.ispb)
        result["Document"] = from_str(self.document)
        result["FiscalName"] = from_str(self.fiscal_name)
        result["FantasyName"] = from_str(self.fantasy_name)
        result["Url"] = from_union([from_none, from_str], self.url)
        result["DateRegistered"] = self.date_registered.isoformat()
        result["DateUpdated"] = from_union([from_none, lambda x: x.isoformat()], self.date_updated)
        result["DateRemoved"] = from_union([from_none, lambda x: x.isoformat()], self.date_removed)
        result["IsRemoved"] = from_bool(self.is_removed)
        return result


def bank_from_dict(s: Any) -> List[BankElement]:
    return from_list(BankElement.from_dict, s)


def bank_to_dict(x: List[BankElement]) -> Any:
    return from_list(lambda x: to_class(BankElement, x), x)
