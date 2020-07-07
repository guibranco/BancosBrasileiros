# Bancos Brasileiros

Brazilian commercial banks list

[![Build status](https://ci.appveyor.com/api/projects/status/f9sx7ux82epp8bd6?svg=true)](https://ci.appveyor.com/project/guibranco/bancosbrasileiros)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![GitHub license](https://img.shields.io/github/license/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![GitHub issues by-label](https://img.shields.io/github/issues/guibranco/BancosBrasileiros/help%20wanted.svg)](https://github.com/guibranco/BancosBrasileiros/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)
[![time tracker](https://wakatime.com/badge/github/guibranco/BancosBrasileiros.svg)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)

***Para a versão em português do README.md, por favor [siga me](/README.md)***

---

## List of banks

### Formats

This list contains 259 registered banks, in the following formats:

- **CSV**: [bancos.csv](/data/bancos.csv)
- **JSON**: [bancos.json](/data/bancos.json)
- **Markdown**: [bancos.md](/data/bancos.md)
- **SQL**: [bancos.sql](/data/bancos.sql)
- **XML**: [bancos.xml](/data/bancos.xml)

### Available data

Each of the lists has the following information (schema):

| Column | Description | Observations |
|-------------------|:---------------------------------------:|:--------------------------------------------------------------------------:|
| COMPE | Bank code - COMPE | 3 digits |
| ISPB | Bank code - ISPB | 8 digits |
| Document | Bank's document - CNPJ | 14 numbers - 18 digits (formatted) |
| FiscalName | Bank's corporate name  | According to the Federal Revenue Service of Brazil |
| FantasyName | Bank's fantasy name | Commercial/trade name |
| Network | The network that the bank can be accessed | RSFN, internet, null |
| Type | The type of bank | commercial, multiple, savings, null |
| Url | Website url | - |
| DateOperationStarted | Commercial operation start date | - |
| DateRegistered | Registration date on schema | - |
| DateUpdated | Change date on schema | - |
| DateRemoved | Removal date in the schema | [Soft Delete](https://www.brentozar.com/archive/2020/02/what-are-soft-deletes-and-how-are-they-implemented/) |
| IsRemoved | Flag indicating whether this bank has been removed or not | [Soft Delete](https://www.brentozar.com/archive/2020/02/what-are-soft-deletes-and-how-are-they-implemented/) |

---

## Schemas and classes

A schema file is available in the folder [schemas](/schemas) for lists of type:

- [JSON](schemas/schema.json)
- [SQL](schemas/schema.sql)
- [XML](schemas/schema.xml)

And classes (DTO - Data Transport Object) in the following languages:

- [C#](/schemas/csharp.cs)
- [Go](/schemas/go.go)
- [Java](/schemas/java.java)
- [JavaScript](/schemas/javascript.js)
- [Kotlin](/schemas/kotlin.kt)
- [PHP](/schemas/php.php)
- [Python](/schemas/python.py)
- [Rust](/schemas/rust.rs)
- [TypeScript](/schemas/typescript.ts)

---

## NPM - Node Package Manager

[![npm](https://img.shields.io/npm/v/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)
[![npm](https://img.shields.io/npm/dy/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)

This repository is available at NPM under the name [bancos-brasileiros](https://www.npmjs.com/package/bancos-brasileiros).
Thanks to [@RauppRafael](https://github.com/RauppRafael) for creating and publish version 1.0.0 on NPM.

```bash

npm i bancos-brasileiros

```

---

## Acronyms and abbreviations

For those unfamiliar with Brazilian entities:

- **ABBC** - Brazilian Association of Banks
- **BCB** - Central Bank of Brazil (regulatory authority)
- **CIP** - Interbank Payments Chamber
- **CNPJ** - National Register of Legal Entities
- **COMPE** - Clearing System for Checks and Other Papers
- **CPF** - Individual Taxpayer Registration
- **FEBRABAN** - Brazilian Federation of Banks
- **ISPB** - SPB identification
- **PIX** - Instant Payments
- **RFB** - Federal Revenue Service of Brazil
- **RSFN** - SFN Network
- **SFN** - National Financial System
- **SPB** - Brazilian Payment System
- **SPI** - Instant Payment System
- **STR** - Reservation Transfer System

---

## Changelog

**Changelog only exists in the PT-BR version for simplicity** [PT-BR version of this file](/README.md)
