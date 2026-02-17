# Bancos Brasileiros

<p align="center">
  <img src="https://raw.githubusercontent.com/guibranco/BancosBrasileiros/main/logo.png" alt="Bancos Brasileiros logo" width="300"/>
</p>

<p align="center">
  🇧🇷 🏦 📋 <strong>Comprehensive Brazilian Financial Institutions Database</strong>
</p>

<p align="center">
  <a href="https://ci.appveyor.com/project/guibranco/bancosbrasileiros"><img src="https://ci.appveyor.com/api/projects/status/f9sx7ux82epp8bd6?svg=true" alt="Build status"></a>  
  <a href="https://github.com/guibranco/BancosBrasileiros/"><img src="https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros" alt="GitHub last commit"></a>
  <a href="https://github.com/guibranco/BancosBrasileiros/"><img src="https://img.shields.io/github/license/guibranco/BancosBrasileiros" alt="GitHub license"></a>
  <a href="https://wakatime.com/badge/github/guibranco/BancosBrasileiros"><img src="https://wakatime.com/badge/github/guibranco/BancosBrasileiros.svg" alt="time tracker"></a>
</p>

<p align="center">
  <a href="https://github.com/guibranco/BancosBrasileiros/actions/workflows/daily-updates.yml"><img src="https://github.com/guibranco/BancosBrasileiros/actions/workflows/daily-updates.yml/badge.svg" alt="Daily updates"></a>
  <a href="https://github.com/guibranco/BancosBrasileiros/actions/workflows/link-checker.yml"><img src="https://github.com/guibranco/BancosBrasileiros/actions/workflows/link-checker.yml/badge.svg" alt="Link checker"></a>
  <a href="https://www.codefactor.io/repository/github/guibranco/BancosBrasileiros"><img src="https://www.codefactor.io/repository/github/guibranco/BancosBrasileiros/badge" alt="CodeFactor"></a>
  <a href="https://snyk.io/test/github/guibranco/BancosBrasileiros"><img src="https://snyk.io/test/github/guibranco/BancosBrasileiros/badge.svg?style=plastic" alt="Known Vulnerabilities"></a>
  <a href="https://github.com/guibranco/bancosbrasileiros/issues"><img src="https://img.shields.io/github/issues/guibranco/bancosbrasileiros" alt="GitHub issues"></a>
</p>

> [!Important]
>
> Para a versão em Português *(PT_BR)* do README.md, [siga me](https://guilherme.stracini.com.br/BancosBrasileiros/README.pt-br.html) por favor.

---

## 📖 Overview

Bancos Brasileiros is a comprehensive database containing information on over 400 registered Brazilian financial institutions. The data is automatically updated daily from official sources using our [MergeTool](https://github.com/guibranco/BancosBrasileiros-MergeTool).

## 📊 Available Data Formats

The database is available in multiple formats to suit your needs:

- [**CSV**](/data/bancos.csv) - For spreadsheet applications and data analysis
- [**JSON**](/data/bancos.json) - For web applications and APIs
- [**Markdown**](/data/bancos.md) - For documentation and GitHub projects
- [**SQL**](/data/bancos.sql) - For database implementations
- [**XML**](/data/bancos.xml) - For legacy systems and specific applications

## 🏛️ Data Schema

Each entry in the database contains the following information:

| Field | Description | Format |
|:------|:------------|:-------|
| **COMPE** | Bank code (Clearing System) | 3 digits |
| **ISPB** | Brazilian Payment System ID | 8 digits |
| **Document** | CNPJ (Company Registration) | 14 numbers or 18 digits (formatted) |
| **LongName** | Official institution name | As registered with BACEN/STR |
| **ShortName** | Abbreviated name | As registered with BACEN/STR |
| **Network** | Connection network type | RSFN, Internet, or null |
| **Type** | Institution type | commercial, multiple, savings, or null |
| **PixType** | PIX/SPI participation type | DRCT (Direct), INDR (Indirect), or null |
| **Charge** | Supports charge operations | true, false, or null |
| **CreditDocument** | Supports TED operations | true, false, or null |
| **LegalCheque** | "Cheque Legal" participation | true or false |
| **DetectaFlow** | "Detecta Flow" participation | true or false |
| **PCR** | "PCR" participation | true or false |
| **PCRP** | "PCRP" participation | true or false |
| **SalaryPortability** | Salary portability support | "Banco folha e Destinatário" (both), "Destinatário" (receive only), or null |
| **Products** | Offered financial products | List in Portuguese |
| **Url** | Official website | URL format |
| **DateOperationStarted** | Commercial operations start date | Date format |
| **DatePixStarted** | PIX operations start date | Date format (PIX participants only) |
| **DateRegistered** | Database entry creation date | Date format |
| **DateUpdated** | Database entry last update | Date format |

## 🛠️ Schema Files & Class Definitions

### Schema Files

Ready-to-use schema definitions are available in the [schemas](/schemas) folder:

- [JSON Schema](/schemas/schema.json)
- [SQL Schema](/schemas/schema.sql)
- [XML Schema](/schemas/schema.xml)

### Class Definitions

Use our pre-built class definitions in various programming languages:

<div align="center">

| Language | File | Badge |
|:---------|:-----|:--|
| [C#](/schemas/csharp.cs) | `Bank.cs` | <img alt="C Sharp" src="https://img.shields.io/badge/-C_Sharp-239120?style=flat-square&logo=dotnet&logoColor=white" /> |
| [Dart](/schemas/dart.dart) | `bank.dart` | <img alt="Dart" src="https://img.shields.io/badge/-Dart-00C3B1?style=flat-square&logo=dart&logoColor=white" /> |
| [Go](/schemas/go.go) | `bank.go` | <img alt="Go" src="https://img.shields.io/badge/-Go-00ADD8?style=flat-square&logo=go&logoColor=white" /> |
| [Java](/schemas/java.java) | `Bank.java` | <img alt="Java" src="https://img.shields.io/badge/-Java-007396?style=flat-square&logo=OpenJDK&logoColor=white" /> |
| [JavaScript](/schemas/javascript.js) | `bank.js` | <img alt="JavaScript" src="https://img.shields.io/badge/-JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=white" /> |
| [Kotlin](/schemas/kotlin.kt) | `Bank.kt` | <img alt="Kotlin" src="https://img.shields.io/badge/-Kotlin-0095D5?style=flat-square&logo=kotlin&logoColor=white" /> |
| [PHP](/schemas/php.php) | `Bank.php` | <img alt="PHP" src="https://img.shields.io/badge/-PHP-777BB4?style=flat-square&logo=php&logoColor=white" /> |
| [Python](/schemas/python.py) | `bank.py` | <img alt="Python" src="https://img.shields.io/badge/-Python-3776AB?style=flat-square&logo=python&logoColor=white" /> |
| [Rust](/schemas/rust.rs) | `bank.rs` | <img alt="Rust" src="https://img.shields.io/badge/-Rust-000000?style=flat-square&logo=rust&logoColor=white" /> |
| [TypeScript](/schemas/typescript.ts) | `bank.ts` | <img alt="TypeScript" src="https://img.shields.io/badge/-TypeScript-3178C6?style=flat-square&logo=typescript&logoColor=white" /> |

</div>

## 📝 Implementation Examples

Practical implementation examples are available in the [examples](/examples) folder:

<div align="center">

| Technology | Directory | Badge |
|:-----------|:----------|:--|
| [Dart](/examples/dart/) | `/examples/dart/` | <img alt="Dart" src="https://img.shields.io/badge/-Dart-00C3B1?style=flat-square&logo=dart&logoColor=white" /> |
| [.NET/C#](/examples/dotnet) | `/examples/dotnet/` | <img alt=".NET" src="https://img.shields.io/badge/-.NET-5C2D91?style=flat-square&logo=dotnet&logoColor=white" /><img alt="C Sharp" src="https://img.shields.io/badge/-C_Sharp-239120?style=flat-square&logo=dotnet&logoColor=white" /> |
| [EmberJS](/examples/emberjs) | `/examples/emberjs/` | <img alt="Ember.js" src="https://img.shields.io/badge/-Emberjs-E04E39?style=flat-square&logo=ember.js&logoColor=white" /> |
| [PHP](/examples/php) | `/examples/php/` | <img alt="PHP" src="https://img.shields.io/badge/-PHP-777BB4?style=flat-square&logo=php&logoColor=white" /> |

</div>

> [!Tip]
> Need an example for a specific language or framework? [Open an issue](https://github.com/guibranco/bancosbrasileiros/issues) requesting it!

## 📦 Package Manager Integrations

### Rust Crates (Cargo)

[![Crates.io](https://img.shields.io/crates/v/bancos_brasileiros.svg)](https://crates.io/crates/bancos_brasileiros)

```toml
[dependencies]
bancos_brasileiros = "5.0.0"
```

### Node.js (NPM)

[![npm](https://img.shields.io/npm/v/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)
[![npm](https://img.shields.io/npm/dy/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)

```bash
npm i bancos-brasileiros
```

### .NET (NuGet)

[![BancosBrasileiros NuGet Version](https://img.shields.io/nuget/v/BancosBrasileiros.svg?style=flat)](https://www.nuget.org/packages/BancosBrasileiros/)
[![BancosBrasileiros NuGet Downloads](https://img.shields.io/nuget/dt/BancosBrasileiros.svg?style=flat)](https://www.nuget.org/packages/BancosBrasileiros/)

```bash
dotnet add package BancosBrasileiros
```

### PHP (Packagist)

[![BancosBrasileiros Packagist Version](https://img.shields.io/packagist/v/guibranco/bancos-brasileiros.svg?style=flat)](https://packagist.org/packages/guibranco/bancos-brasileiros)
[![BancosBrasileiros Packagist Downloads](https://img.shields.io/packagist/dt/guibranco/bancos-brasileiros.svg?style=flat)](https://packagist.org/packages/guibranco/bancos-brasileiros)

```bash
composer require guibranco/bancos-brasileiros
```

## 📚 Financial System Acronyms

Understanding the Brazilian financial system terminology:

<!--START_SECTION:abbreviations-section-->
<table width="100%"><tr><th>ABBC</th><td> Brazilian Banks Association</td></tr><tr><th>BCB</th><td> Central Bank of Brazil (regulatory authority)(also known as BACEN or BC)</td></tr><tr><th>CIP</th><td> Interbank Payment Chamber</td></tr><tr><th>CNPJ</th><td> National Register of Legal Entities - RFB</td></tr><tr><th>COMPE</th><td> Check and Other Papers Compensation System</td></tr><tr><th>CTC</th><td> Credit Transfer Center</td></tr><tr><th>CPF</th><td> Individual Taxpayer Registry - RFB</td></tr><tr><th>CVM</th><td> Securities and Exchange Commission</td></tr><tr><th>FEBRABAN</th><td> Brazilian Federation of Banks</td></tr><tr><th>ISPB</th><td> SPB identification</td></tr><tr><th>PCPS</th><td> Centralized Salary Portability Platform</td></tr><tr><th>PCR</th><td> Centralized Receivables Platform</td></tr><tr><th>PIX</th><td> Brazilian Instant Payments</td></tr><tr><th>RFB</th><td> Federal Revenue Service of Brazil</td></tr><tr><th>RSFN</th><td> National Financial System Network</td></tr><tr><th>SFN</th><td> National Financial System</td></tr><tr><th>SLC</th><td> Card Settlement Service</td></tr><tr><th>SILOC</th><td> Deferred Settlement System for Interbank Transfers of Credit Orders</td></tr><tr><th>SITRAF</th><td> Funds Transfer System</td></tr><tr><th>SPB</th><td> Brazilian Payment System</td></tr><tr><th>SPI</th><td> Instant Payment System</td></tr><tr><th>STR</th><td> Reserves Transfer System</td></tr></table>
<!--END_SECTION:abbreviations-section-->

## 🔄 Updates & Data Quality

The database is **automatically updated daily** using our [MergeTool](https://github.com/guibranco/BancosBrasileiros-MergeTool) that collects information from official sources.

> [!Warning]
>
> Found missing or incorrect data? Please [open an issue](https://github.com/guibranco/BancosBrasileiros/issues/new/choose)

## 📜 Changelog

View our complete [changelog](/CHANGELOG.md) for detailed update history.

## 👨‍💻 Contributors

<!-- readme: collaborators,contributors,snyk-bot/-,guistracini-outsurance-ie/- -start -->
<table>
	<tbody>
		<tr>
            <td align="center">
                <a href="https://github.com/guibranco">
                    <img src="https://avatars.githubusercontent.com/u/3362854?v=4" width="100;" alt="guibranco"/>
                    <br />
                    <sub><b>Guilherme Branco Stracini</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/icarusiftctts">
                    <img src="https://avatars.githubusercontent.com/u/174119232?v=4" width="100;" alt="icarusiftctts"/>
                    <br />
                    <sub><b>Praneel Dev</b></sub>
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
                <a href="https://github.com/vduggen">
                    <img src="https://avatars.githubusercontent.com/u/53385727?v=4" width="100;" alt="vduggen"/>
                    <br />
                    <sub><b>Vitor Duggen</b></sub>
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
                <a href="https://github.com/luisccf">
                    <img src="https://avatars.githubusercontent.com/u/14101365?v=4" width="100;" alt="luisccf"/>
                    <br />
                    <sub><b>Luis Carlos Cardoso</b></sub>
                </a>
            </td>
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/AmolKumarGupta">
                    <img src="https://avatars.githubusercontent.com/u/88397611?v=4" width="100;" alt="AmolKumarGupta"/>
                    <br />
                    <sub><b>Amol</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/victorbrandaao">
                    <img src="https://avatars.githubusercontent.com/u/85573492?v=4" width="100;" alt="victorbrandaao"/>
                    <br />
                    <sub><b>Victor Leonardo Brandão</b></sub>
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
                <a href="https://github.com/MauriciDmarc">
                    <img src="https://avatars.githubusercontent.com/u/129069676?v=4" width="100;" alt="MauriciDmarc"/>
                    <br />
                    <sub><b>Maurici Dmarco</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/leogregianin">
                    <img src="https://avatars.githubusercontent.com/u/1684053?v=4" width="100;" alt="leogregianin"/>
                    <br />
                    <sub><b>Leonardo Gregianin</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/joaovaladares">
                    <img src="https://avatars.githubusercontent.com/u/42593399?v=4" width="100;" alt="joaovaladares"/>
                    <br />
                    <sub><b>João V. Valadares</b></sub>
                </a>
            </td>
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/jesobreira">
                    <img src="https://avatars.githubusercontent.com/u/3002249?v=4" width="100;" alt="jesobreira"/>
                    <br />
                    <sub><b>Jefrey Sobreira Santos</b></sub>
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
                <a href="https://github.com/Guillergood">
                    <img src="https://avatars.githubusercontent.com/u/16701917?v=4" width="100;" alt="Guillergood"/>
                    <br />
                    <sub><b>Guillermo Bueno Vargas</b></sub>
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
                <a href="https://github.com/Erick-Bueno">
                    <img src="https://avatars.githubusercontent.com/u/101439440?v=4" width="100;" alt="Erick-Bueno"/>
                    <br />
                    <sub><b>Erick Bueno</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/sahalhes">
                    <img src="https://avatars.githubusercontent.com/u/146409442?v=4" width="100;" alt="sahalhes"/>
                    <br />
                    <sub><b>E S Sahal Hussain</b></sub>
                </a>
            </td>
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/BrunoM90">
                    <img src="https://avatars.githubusercontent.com/u/152902220?v=4" width="100;" alt="BrunoM90"/>
                    <br />
                    <sub><b>Null</b></sub>
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
                <a href="https://github.com/apoorvdarshan">
                    <img src="https://avatars.githubusercontent.com/u/90602809?v=4" width="100;" alt="apoorvdarshan"/>
                    <br />
                    <sub><b>Apoorv Darshan</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: collaborators,contributors,snyk-bot/-,guistracini-outsurance-ie/- -end -->

### 🤖 Bots

<!-- readme: snyk-bot,bots -start -->
<table>
	<tbody>
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
            </td>
            <td align="center">
                <a href="https://github.com/gstraccini[bot]">
                    <img src="https://avatars.githubusercontent.com/in/480132?v=4" width="100;" alt="gstraccini[bot]"/>
                    <br />
                    <sub><b>gstraccini[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/gitauto-ai[bot]">
                    <img src="https://avatars.githubusercontent.com/in/844909?v=4" width="100;" alt="gitauto-ai[bot]"/>
                    <br />
                    <sub><b>gitauto-ai[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/penify-dev[bot]">
                    <img src="https://avatars.githubusercontent.com/in/399279?v=4" width="100;" alt="penify-dev[bot]"/>
                    <br />
                    <sub><b>penify-dev[bot]</b></sub>
                </a>
            </td>
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/stack-file[bot]">
                    <img src="https://avatars.githubusercontent.com/in/408123?v=4" width="100;" alt="stack-file[bot]"/>
                    <br />
                    <sub><b>stack-file[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/deepsource-io[bot]">
                    <img src="https://avatars.githubusercontent.com/in/16372?v=4" width="100;" alt="deepsource-io[bot]"/>
                    <br />
                    <sub><b>deepsource-io[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/deepsource-autofix[bot]">
                    <img src="https://avatars.githubusercontent.com/in/57168?v=4" width="100;" alt="deepsource-autofix[bot]"/>
                    <br />
                    <sub><b>deepsource-autofix[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/codefactor-io[bot]">
                    <img src="https://avatars.githubusercontent.com/in/25603?v=4" width="100;" alt="codefactor-io[bot]"/>
                    <br />
                    <sub><b>codefactor-io[bot]</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: snyk-bot,bots -end -->
