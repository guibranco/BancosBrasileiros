# Bancos Brasileiros

Brazilian commercial banks list

[![Build status](https://ci.appveyor.com/api/projects/status/f9sx7ux82epp8bd6?svg=true)](https://ci.appveyor.com/project/guibranco/bancosbrasileiros)
![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)
![GitHub license](https://img.shields.io/github/license/guibranco/BancosBrasileiros)
[![GitHub issues by-label](https://img.shields.io/github/issues/guibranco/BancosBrasileiros/help%20wanted.svg)](https://github.com/guibranco/BancosBrasileiros/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)
[![time tracker](https://wakatime.com/badge/github/guibranco/BancosBrasileiros.svg)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)

***Para a versão em português do README.md, por favor [siga me](/README.md)***

---

## List of banks

### Formats

This list contains 260 registered banks, in the following formats:

- **CSV**: [bancos.csv](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.csv)
- **JSON**: [bancos.json](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.json)
- **SQL**: [bancos.sql](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.sql)
- **XML**: [bancos.xml](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.xml)

### Available data

Each of the lists has the following information:

| Column | Description | Observations |
|-------------------|:---------------------------------------:|:--------------------------------------------------------------------------:|
| COMPE | Bank Code - COMPE | 3 digits |
| ISPB | Bank Code - ISPB | 8 digits (TODO [Issue #31](https://github.com/guibranco/BancosBrasileiros/issues/31)) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Nome | Bank's corporate or fantasy/trade name  | - |
| CNPJ | Bank's document | (TODO [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4)) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Url  | Website url | (TODO [Issue #9](https://github.com/guibranco/BancosBrasileiros/issues/9)) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Data de cadastro | Registration date on schema | (TODO bancos.sql) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Data de alteração | Change date on schema | - |
| Data de remoção | Removal date in the schema | (TODO bancos.sql) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Removido | Flag indicating whether this bank has been removed or not | Logical DELETE |

---

## NPM - Node Package Manager

[![npm](https://img.shields.io/npm/v/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)
![npm](https://img.shields.io/npm/dy/bancos-brasileiros)

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
- **RSFN** - SFN Network
- **SFN** - National Financial System
- **SPB** - Brazilian Payment System
- **SPI** - Instant Payment System
- **STR** - Reservation Transfer System

---

## TODO ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted)

- Gather the banks documents (CNPJ): [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4).
- Gather the banks website (url/link): [Issue #9](https://github.com/guibranco/BancosBrasileiros/issues/9).
- Gather the ISPB numbers: [Issue #31](https://github.com/guibranco/BancosBrasileiros/issues/31).

---

## Changelog

**Changelog only exists in the PT-BR version for simplicity** [PT-BR version of this file](/README.md)
