# Bancos Brasileiros

Brazilian commercial banks list

[![Build status](https://ci.appveyor.com/api/projects/status/f9sx7ux82epp8bd6?svg=true)](https://ci.appveyor.com/project/guibranco/bancosbrasileiros)
[![Daily updates](https://github.com/guibranco/BancosBrasileiros/actions/workflows/daily-updates.yml/badge.svg)](https://github.com/guibranco/BancosBrasileiros/actions/workflows/daily-updates.yml)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![GitHub license](https://img.shields.io/github/license/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![time tracker](https://wakatime.com/badge/github/guibranco/BancosBrasileiros.svg)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)

[![Maintainability](https://api.codeclimate.com/v1/badges/2dfea6fc7a71e09ea7da/maintainability)](https://codeclimate.com/github/guibranco/BancosBrasileiros/maintainability) [![Test Coverage](https://api.codeclimate.com/v1/badges/2dfea6fc7a71e09ea7da/test_coverage)](https://codeclimate.com/github/guibranco/BancosBrasileiros/test_coverage)
[![CodeFactor](https://www.codefactor.io/repository/github/guibranco/BancosBrasileiros/badge)](https://www.codefactor.io/repository/github/guibranco/BancosBrasileiros)
[![Known Vulnerabilities](https://snyk.io/test/github/guibranco/BancosBrasileiros/badge.svg?style=plastic)](https://snyk.io/test/github/guibranco/BancosBrasileiros)

![Bancos Brasileiros logo](logo.png)

***Para a versão em português do README.md, [siga me](/README.pt-br.md) por favor.***

---

## List of banks

### Formats

This list contains 300+ registered banks, in the following formats:

- **CSV**: [bancos.csv](/data/bancos.csv)
- **JSON**: [bancos.json](/data/bancos.json)
- **Markdown**: [bancos.md](/data/bancos.md)
- **SQL**: [bancos.sql](/data/bancos.sql)
- **XML**: [bancos.xml](/data/bancos.xml)

### Available data

Each of the lists has the following information (schema):

| Column | Description | Observations |
|-------------------|:---------------------------------------:|:--------------------------------------------------------------------------:|
| COMPE | Code - COMPE | 3 digits |
| ISPB | Code - ISPB | 8 digits |
| Document | Document - CNPJ | 14 numbers - 18 digits (formatted) |
| LongName | Long name  | According to BACEN - STR |
| ShortName | Short name | According to BACEN - STR|
| Network | Network | RSFN, Internet, null |
| Type | Type | commercial, multiple, savings, null |
| PixType | Type of PIX/SPI participant | DRCT - Directly, INDR - Indirectly, null |
| Charge | If does charge operations | true, false, null | 
| CreditDocument | If does DOC/TED operations | true, false, null | 
| SalaryPortability | If does/accept salary portability | "Banco folha e Destinatário" - both operations, "Destinatário" - only receive, null | 
| Products | List of products offered | In portuguese only | 
| Url | Website | - |
| DateOperationStarted | Commercial operation start date | - |
| DatePixStarted | PIX operation start date | Only for those PSP of SPI |
| DateRegistered | Registration date on schema | - |
| DateUpdated | Change date on schema | - |

---

## Schemas and classes

A schema file is available in the folder [schemas](/schemas) for lists of type:

- [JSON](schemas/schema.json)
- [SQL](schemas/schema.sql)
- [XML](schemas/schema.xml)

And classes (DTO - Data Transport Object) in the following languages:

- [C#](/schemas/csharp.cs) <img alt="C Sharp" src="https://img.shields.io/badge/-C_Sharp-239120?style=flat-square&logo=c-sharp&logoColor=white" />
- [Go](/schemas/go.go) <img alt="Go" src="https://img.shields.io/badge/-Go-00ADD8?style=flat-square&logo=go&logoColor=white" />
- [Java](/schemas/java.java) <img alt="Java" src="https://img.shields.io/badge/-Java-007396?style=flat-square&logo=OpenJDK&logoColor=white" />
- [JavaScript](/schemas/javascript.js) <img alt="JavaScript" src="https://img.shields.io/badge/-JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=white" />
- [Kotlin](/schemas/kotlin.kt) <img alt="Kotlin" src="https://img.shields.io/badge/-Kotlin-0095D5?style=flat-square&logo=kotlin&logoColor=white" />
- [PHP](/schemas/php.php) <img alt="PHP" src="https://img.shields.io/badge/-PHP-777BB4?style=flat-square&logo=php&logoColor=white" />
- [Python](/schemas/python.py) <img alt="Python" src="https://img.shields.io/badge/-Python-3776AB?style=flat-square&logo=python&logoColor=white" />
- [Rust](/schemas/rust.rs) <img alt="Rust" src="https://img.shields.io/badge/-Rust-000000?style=flat-square&logo=rust&logoColor=white" />
- [TypeScript](/schemas/typescript.ts) <img alt="TypeScript" src="https://img.shields.io/badge/-TypeScript-3178C6?style=flat-square&logo=typescript&logoColor=white" />

---

## Examples

Implementation examples are available in the folder [examples](/examples), we currently have examples in the following technologies:

- [.NET/C#](/examples/dotnet) <img alt=".NET" src="https://img.shields.io/badge/-.NET-5C2D91?style=flat-square&logo=dotnet&logoColor=white" /><img alt="C Sharp" src="https://img.shields.io/badge/-C_Sharp-239120?style=flat-square&logo=c-sharp&logoColor=white" />
- [EmberJS](/examples/emberjs) <img alt="Ember.js" src="https://img.shields.io/badge/-Emberjs-E04E39?style=flat-square&logo=ember.js&logoColor=white" />

If you miss an example, in the language, library or framework, open an issue requesting an example project on the desired technology!

---

## NPM - Node Package Manager

[![npm](https://img.shields.io/npm/v/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)
[![npm](https://img.shields.io/npm/dy/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)

This repository is available at NPM under the name [bancos-brasileiros](https://www.npmjs.com/package/bancos-brasileiros).

Thanks to [@RauppRafael](https://github.com/RauppRafael) for creating and publish version 1.0.0 on NPM.

```bash

npm i bancos-brasileiros

```

## NuGet - Package Manager for .NET

[![BancosBrasileiros NuGet Version](https://img.shields.io/nuget/v/BancosBrasileiros.svg?style=flat)](https://www.nuget.org/packages/BancosBrasileiros/)
[![BancosBrasileiros NuGet Downloads](https://img.shields.io/nuget/dt/BancosBrasileiros.svg?style=flat)](https://www.nuget.org/packages/BancosBrasileiros/)

This repository is available at NuGet under the name [BancosBrasileiros](https://www.nuget.org/packages/BancosBrasileiros/).

```bash

dotnet add package BancosBrasileiros

```

---

## Acronyms and abbreviations

For those unfamiliar with Brazilian financial/regulatory entities:

- **ABBC** - Brazilian Association of Banks
- **BCB** - Central Bank of Brazil (regulatory authority)(also known as *BACEN* or *BC*)
- **CIP** - Interbank Payments Chamber
- **CNPJ** - National Register of Legal Entities - *RFB*
- **COMPE** - Clearing System for Checks and Other Papers
- **CPF** - Individual Taxpayer Registration - *RFB*
- **FEBRABAN** - Brazilian Federation of Banks
- **ISPB** - *SPB* identification
- **PIX** - Instant Payments
- **RFB** - Federal Revenue Service of Brazil
- **RSFN** - *SFN* Network
- **SFN** - National Financial System
- **SPB** - Brazilian Payment System
- **SPI** - Instant Payment System
- **STR** - Reservation Transfer System

---

## Changelog

[Changelog](/CHANGELOG.md)


## Contributors

<!-- readme: collaborators,contributors,snyk-bot/- -start -->
<table>
<tr>
    <td align="center">
        <a href="https://github.com/guibranco">
            <img src="https://avatars.githubusercontent.com/u/3362854?v=4" width="100;" alt="guibranco"/>
            <br />
            <sub><b>Guilherme Branco Stracini</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/raphaelcunha">
            <img src="https://avatars.githubusercontent.com/u/3853552?v=4" width="100;" alt="raphaelcunha"/>
            <br />
            <sub><b>Raphael Cunha</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/Baldini">
            <img src="https://avatars.githubusercontent.com/u/8235570?v=4" width="100;" alt="Baldini"/>
            <br />
            <sub><b>Guilherme Baldini</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/pferreirafabricio">
            <img src="https://avatars.githubusercontent.com/u/42717522?v=4" width="100;" alt="pferreirafabricio"/>
            <br />
            <sub><b>Fabrício Pinto Ferreira</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/iurisilvio">
            <img src="https://avatars.githubusercontent.com/u/105852?v=4" width="100;" alt="iurisilvio"/>
            <br />
            <sub><b>Iuri De Silvio</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/jesobreira">
            <img src="https://avatars.githubusercontent.com/u/3002249?v=4" width="100;" alt="jesobreira"/>
            <br />
            <sub><b>Jefrey Sobreira Santos</b></sub>
        </a>
    </td></tr>
<tr>
    <td align="center">
        <a href="https://github.com/leogregianin">
            <img src="https://avatars.githubusercontent.com/u/1684053?v=4" width="100;" alt="leogregianin"/>
            <br />
            <sub><b>Leonardo Gregianin</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/rafaeldomi">
            <img src="https://avatars.githubusercontent.com/u/135021?v=4" width="100;" alt="rafaeldomi"/>
            <br />
            <sub><b>Rafael Domiciano</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/luisccf">
            <img src="https://avatars.githubusercontent.com/u/14101365?v=4" width="100;" alt="luisccf"/>
            <br />
            <sub><b>Luis Carlos Cardoso</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/rodrigondec">
            <img src="https://avatars.githubusercontent.com/u/3301060?v=4" width="100;" alt="rodrigondec"/>
            <br />
            <sub><b>Rodrigo Castro</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/vduggen">
            <img src="https://avatars.githubusercontent.com/u/53385727?v=4" width="100;" alt="vduggen"/>
            <br />
            <sub><b>Vitor Duggen</b></sub>
        </a>
    </td></tr>
</table>
<!-- readme: collaborators,contributors,snyk-bot/- -end -->

## Bots

<!-- readme: snyk-bot,bots -start -->
<table>
<tr>
    <td align="center">
        <a href="https://github.com/snyk-bot">
            <img src="https://avatars.githubusercontent.com/u/19733683?v=4" width="100;" alt="snyk-bot"/>
            <br />
            <sub><b>Snyk Bot</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/dependabot[bot]">
            <img src="https://avatars.githubusercontent.com/in/29110?v=4" width="100;" alt="dependabot[bot]"/>
            <br />
            <sub><b>dependabot[bot]</b></sub>
        </a>
    </td>
    <td align="center">
        <a href="https://github.com/github-actions[bot]">
            <img src="https://avatars.githubusercontent.com/in/15368?v=4" width="100;" alt="github-actions[bot]"/>
            <br />
            <sub><b>github-actions[bot]</b></sub>
        </a>
    </td></tr>
</table>
<!-- readme: snyk-bot,bots -end -->
