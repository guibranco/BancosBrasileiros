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
    long_name: str
    short_name: str
    network: Optional[str]
    type_: Optional[str]
    pix_type: Optional[str]
    url: Optional[str]
    date_operation_started: Optional[str]
    date_pix_started: Optional[str]
    date_registered: datetime
    date_updated: datetime

    def __init__(self, compe: str, ispb: str, document: str, long_name: str, short_name: str, network: Optional[str], type_: Optional[str], pix_type: Optional[str], url: Optional[str], date_operation_started: Optional[str], date_pix_started: Optional[str], date_registered: datetime, date_updated: datetime) -> None:
        self.compe = compe
        self.ispb = ispb
        self.document = document
        self.long_name = long_name
        self.short_name = short_name
        self.network = network
        self.type_ = type_
        self.pix_type = pix_type
        self.url = url
        self.date_operation_started = date_operation_started
        self.date_pix_started = date_pix_started
        self.date_registered = date_registered
        self.date_updated = date_updated

    @staticmethod
    def from_dict(obj: Any) -> 'BankElement':
        assert isinstance(obj, dict)
        compe = from_str(obj.get("COMPE"))
        ispb = from_str(obj.get("ISPB"))
        document = from_str(obj.get("Document"))
        long_name = from_str(obj.get("LongName"))
        short_name = from_str(obj.get("ShortName"))
        network = from_union([from_none, from_str], obj.get("Network"))
        type_ = from_union([from_none, from_str], obj.get("Type"))
        url = from_union([from_none, from_str], obj.get("Url"))
        date_operation_started = from_union([from_none, from_str], obj.get("DateOperationStarted"))
        date_pix_started = from_union([from_none, from_str], obj.get("DatePixStarted"))
        date_registered = from_datetime(obj.get("DateRegistered"))
        date_updated = from_datetime(obj.get("DateUpdated"))
        return BankElement(compe, ispb, document, long_name, short_name, network, type_, pix_type, url, date_operation_started, date_pix_started, date_registered, date_updated)

    def to_dict(self) -> dict:
        result: dict = {}
        result["COMPE"] = from_str(self.compe)
        result["ISPB"] = from_str(self.ispb)
        result["Document"] = from_str(self.document)
        result["LongName"] = from_str(self.long_name)
        result["ShortName"] = from_str(self.short_name)
        result["Network"] = from_union([from_none, from_str], self.network)
        result["Type"] = from_union([from_none, from_str], self.type_)
        result["PixType"] = from_union([from_none, from_str], self.pix_type)
        result["Url"] = from_union([from_none, from_str], self.url)
        result["DateOperationStarted"] = from_union([from_none, from_str], self.date_operation_started)
        result["DatePixStarted"] = from_union([from_none, from_str], self.date_pix_started)
        result["DateRegistered"] = self.date_registered.isoformat()
        result["DateUpdated"] = self.date_updated.isoformat()
        return result


def bank_from_dict(s: Any) -> List[BankElement]:
    return from_list(BankElement.from_dict, s)


def bank_to_dict(x: List[BankElement]) -> Any:
    return from_list(lambda x: to_class(BankElement, x), x)
