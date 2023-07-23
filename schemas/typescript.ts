// To parse this data:
//
//   import { Convert } from "./file";
//
//   const bank = Convert.toBank(json);
//
// These functions will throw an error if the JSON doesn't
// match the expected interface, even if the JSON is valid.

export interface Bank {
    COMPE:                  string;
    ISPB:                   string;
    Document:               string;
    LongName:               string;
    ShortName:              string;
    Network:                null | string;
    Type:                   null | string;
    PixType:                null | string;
    Charge:                 null | boolean;
    CreditDocument:         null | boolean;
    LegalCheque:            boolean,
    DetectaFlow:            boolean,
    SalaryPortability:      null | string;
    Products:               null | string[];
    Url:                    null | string;
    DateOperationStarted:   null | string;
    DatePixStarted:         null | string;
    DateRegistered:         Date;
    DateUpdated:            Date;
}

// Converts JSON strings to/from your types
// and asserts the results of JSON.parse at runtime
export class Convert {
    public static toBank(json: string): Bank[] {
        return cast(JSON.parse(json), a(r("Bank")));
    }

    public static bankToJson(value: Bank[]): string {
        return JSON.stringify(uncast(value, a(r("Bank"))), null, 2);
    }
}

function invalidValue(typ: any, val: any): never {
    throw Error(`Invalid value ${JSON.stringify(val)} for type ${JSON.stringify(typ)}`);
}

function jsonToJSProps(typ: any): any {
    if (typ.jsonToJS === undefined) {
        const map: any = {};
        typ.props.forEach((p: any) => map[p.json] = { key: p.js, typ: p.typ });
        typ.jsonToJS = map;
    }
    return typ.jsonToJS;
}

function jsToJSONProps(typ: any): any {
    if (typ.jsToJSON === undefined) {
        const map: any = {};
        typ.props.forEach((p: any) => map[p.js] = { key: p.json, typ: p.typ });
        typ.jsToJSON = map;
    }
    return typ.jsToJSON;
}

function transform(val: any, typ: any, getProps: any): any {
    function transformPrimitive(typ: string, val: any): any {
        if (typeof typ === typeof val) return val;
        return invalidValue(typ, val);
    }

    function transformUnion(typs: any[], val: any): any {
        // val must validate against one typ in typs
        const l = typs.length;
        for (let i = 0; i < l; i++) {
            const typ = typs[i];
            try {
                return transform(val, typ, getProps);
            } catch (_) {}
        }
        return invalidValue(typs, val);
    }

    function transformEnum(cases: string[], val: any): any {
        if (cases.indexOf(val) !== -1) return val;
        return invalidValue(cases, val);
    }

    function transformArray(typ: any, val: any): any {
        // val must be an array with no invalid elements
        if (!Array.isArray(val)) return invalidValue("array", val);
        return val.map(el => transform(el, typ, getProps));
    }

    function transformDate(val: any): any {
        if (val === null) {
            return null;
        }
        const d = new Date(val);
        if (isNaN(d.valueOf())) {
            return invalidValue("Date", val);
        }
        return d;
    }

    function transformObject(props: { [k: string]: any }, additional: any, val: any): any {
        if (val === null || typeof val !== "object" || Array.isArray(val)) {
            return invalidValue("object", val);
        }
        const result: any = {};
        Object.getOwnPropertyNames(props).forEach(key => {
            const prop = props[key];
            const v = Object.prototype.hasOwnProperty.call(val, key) ? val[key] : undefined;
            result[prop.key] = transform(v, prop.typ, getProps);
        });
        Object.getOwnPropertyNames(val).forEach(key => {
            if (!Object.prototype.hasOwnProperty.call(props, key)) {
                result[key] = transform(val[key], additional, getProps);
            }
        });
        return result;
    }

    if (typ === "any") return val;
    if (typ === null) {
        if (val === null) return val;
        return invalidValue(typ, val);
    }
    if (typ === false) return invalidValue(typ, val);
    while (typeof typ === "object" && typ.ref !== undefined) {
        typ = typeMap[typ.ref];
    }
    if (Array.isArray(typ)) return transformEnum(typ, val);
    if (typeof typ === "object") {
        return typ.hasOwnProperty("unionMembers") ? transformUnion(typ.unionMembers, val)
            : typ.hasOwnProperty("arrayItems")    ? transformArray(typ.arrayItems, val)
            : typ.hasOwnProperty("props")         ? transformObject(getProps(typ), typ.additional, val)
            : invalidValue(typ, val);
    }
    // Numbers can be parsed by Date but shouldn't be.
    if (typ === Date && typeof val !== "number") return transformDate(val);
    return transformPrimitive(typ, val);
}

function cast<T>(val: any, typ: any): T {
    return transform(val, typ, jsonToJSProps);
}

function uncast<T>(val: T, typ: any): any {
    return transform(val, typ, jsToJSONProps);
}

function a(typ: any) {
    return { arrayItems: typ };
}

function u(...typs: any[]) {
    return { unionMembers: typs };
}

function o(props: any[], additional: any) {
    return { props, additional };
}

function m(additional: any) {
    return { props: [], additional };
}

function r(name: string) {
    return { ref: name };
}

const typeMap: any = {
    "Bank": o([
        { json: "COMPE", js: "COMPE", typ: "" },
        { json: "ISPB", js: "ISPB", typ: "" },
        { json: "Document", js: "Document", typ: "" },
        { json: "LongName", js: "LongName", typ: "" },
        { json: "ShortName", js: "ShortName", typ: "" },
        { json: "Network", js: "Network", typ: u("", null) },
        { json: "Type", js: "Type", typ: u("", null) },
        { json: "PixType", js: "PixType", typ: u("", null) },
        { json: "Charge", js: "Charge", typ: u("", null) },
        { json: "CreditDocument", js: "CreditDocument", typ: u("", null) },
        { json: "LegalCheque", js: "LegalCheque", typ: u("", null) },
        { json: "DetectaFlow", js: "DetectaFlow", typ: u("", null) },
        { json: "SalaryPortability", js: "SalaryPortability", typ: u("", null) },
        { json: "Products", js: "Products", typ: u("", null) },
        { json: "Url", js: "Url", typ: u("", null) },
        { json: "DateOperationStarted", js: "DateOperationStarted", typ: u("", null) },
        { json: "DatePixStarted", js: "DatePixStarted", typ: u("", null) },   
        { json: "DateRegistered", js: "DateRegistered", typ: Date },
        { json: "DateUpdated", js: "DateUpdated", typ: Date },
    ], false),
};
