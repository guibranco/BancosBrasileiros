# Bancos Brasileiros

Brazilian commercial banks list

![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)
![GitHub](https://img.shields.io/github/license/guibranco/BancosBrasileiros)

***Para a versão em português do README.md, por favor [siga me](https://github.com/guibranco/BancosBrasileiros/blob/master/README.md)***

--- 

## List of banks

### Formats

This list contains 259 registered banks, in the following formats:

- **CSV**: [Banks.csv](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.csv)
- **JSON**: [Banks.json](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.json)
- **SQL**: [Banks.sql](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.sql)
- **XML**: [Banks.xml](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.xml)

### Available data

Each of the lists has the following information:

| Column | Description | Observations |
|-------------------|:---------------------------------------:|:--------------------------------------------------------------------------:|
| COMPE | Bank Code - COMPE | 3 digits |
| ISPB | Bank Code - ISPB | 8 digits (TODO [Issue #31](https://github.com/guibranco/BancosBrasileiros/issues/31)) |
| Razão Social | Bank's corporate name | - |
| CNPJ | Bank's document | (TODO [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4)) |
| Url  | Website url | (TODO [Issue #9](https://github.com/guibranco/BancosBrasileiros/issues/9)) |
| Data de cadastro | Registration date on schema | (TODO bancos.sql) |
| Data de alteração | Change date on schena | - |
| Data de remoção | Removal date in the schema | (TODO bancos.sql) |
| Removido | Flag indicating whether this bank has been removed or not | Logical DELETE |

---

## NPM - Node Package Manager

This repository is available at NPM under the name [bancos-brasileiros](https://www.npmjs.com/package/bancos-brasileiros).
Thanks to [@RauppRafael](https://github.com/RauppRafael) for creating and published version 1.0.0 on NPM.

```bash

npm i bancos-brasileiros

```

---

## Acronyms and abbreviations

For those unfamiliar with Brazilian entities:

- **BCB** - Central Bank of Brazil (regulatory authority)
- **FEBRABAN** - Brazilian Federation of Banks
- **ABBC** - Brazilian Association of Banks
- **CNPJ** - National Register of Legal Entities
- **CPF** - Individual Taxpayer Registration
- **CIP** - Interbank Payments Chamber
- **SPB** - Brazilian Payment System
- **ISPB** - SPB identification
- **COMPE** - Clearing System for Checks and Other Papers
- **SFN** - National Financial System
- **RSFN** - SFN Network
- **PIX** - Instant Payments
- **STR** - Reservation Transfer System

---

## TODO

- Gather the banks documents (CNPJ) [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4)
- Gather the banks website (url/link) [Issue #9](https://github.com/guibranco/BancosBrasileiros/issues/9)
- Gather the ISPB numbers [Issue #31](https://github.com/guibranco/BancosBrasileiros/issues/31)

---

## Changelog

**Changelog only exists in the PT-BR version for simplicity** [PT-BR version of this file](https://github.com/guibranco/BancosBrasileiros/blob/master/README.md)
