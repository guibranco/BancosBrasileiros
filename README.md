# Bancos Brasileiros

Listagem de bancos comerciais brasileiros

[![Build status](https://ci.appveyor.com/api/projects/status/f9sx7ux82epp8bd6?svg=true)](https://ci.appveyor.com/project/guibranco/bancosbrasileiros)
[![Daily updates](https://github.com/guibranco/BancosBrasileiros/actions/workflows/dailyUpdates.yml/badge.svg)](https://github.com/guibranco/BancosBrasileiros/actions/workflows/dailyUpdates.yml)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![GitHub license](https://img.shields.io/github/license/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![Known Vulnerabilities](https://snyk.io/test/github/guibranco/BancosBrasileiros/badge.svg?style=plastic)](https://snyk.io/test/github/guibranco/BancosBrasileiros)
[![time tracker](https://wakatime.com/badge/github/guibranco/BancosBrasileiros.svg)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)

***For a english version of README.md, please [follow me](/README.en.md)***

---

## Lista de bancos

### Formatos

Esta lista contém 300+ bancos cadastrados, nos seguintes formatos:

- **CSV**: [bancos.csv](/data/bancos.csv)
- **JSON**: [bancos.json](/data/bancos.json)
- **Markdown**: [bancos.md](/data/bancos.md)
- **SQL**: [bancos.sql](/data/bancos.sql)
- **XML**: [bancos.xml](/data/bancos.xml)

### Dados disponíves

Cada uma das listas possui as seguintes informações (schema):

| Coluna | Descrição | Observações |
|-------------------|:---------------------------------------:|:--------------------------------------------------------------------------:|
| COMPE | Código - COMPE | 3 dígitos |
| ISPB | Código - ISPB | 8 dígitos |
| Document | Documento - CNPJ | 14 números - 18 dígitos (formatado) |
| LongName | Nome extenso | Conforme BACEN - STR |
| ShortName | Nome reduzido | Conforme BACEN - STR |
| Network | Rede | RSFN, Internet, null |
| Type | Tipo | comercial, múltiplo, caixa econômica, null |
| PixType | Tipo de participante PIX/SPI | DRCT - Direto, INDR - Indireto, null |
| Charge | Efetua cobrança | true, false, null | 
| CreditDocument | Efetua DOC/TED | true, false, null | 
| SalaryPortability | Efetua/recebe portabilidade de salário | "Banco folha e Destinatário" - ambas as operações,  "Destinatário" - apenas recebe, null
| Products | Lista de produtos oferecidos | Apenas em português |
| Url | Website | - |
| DateOperationStarted | Data de início da operação | - |
| DatePixStarted | Data de início da operação PIX | Somente para PSP do SPI |
| DateRegistered | Data de cadastro no schema | - |
| DateUpdated | Data de alteração no schema | - |

---

## Schemas e classes

Um arquivo de schema está disponível na pasta [schemas](/schemas) para as listas do tipo:

- [JSON](/schemas/schema.json)
- [SQL](/schemas/schema.sql)
- [XML](/schemas/schema.xml)

E classes (DTO - Data Transport Object) das seguintes linguagens:

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

## Exemplos

Exemplos de implementação estão disponíveis na pasta [examples](/examples), atualmente dispomos de exemplos nas seguintes tecnologias:

- [.NET/C#](/examples/dotnet) <img alt=".NET" src="https://img.shields.io/badge/-.NET-5C2D91?style=flat-square&logo=dotnet&logoColor=white" /><img alt="C Sharp" src="https://img.shields.io/badge/-C_Sharp-239120?style=flat-square&logo=c-sharp&logoColor=white" />
- [EmberJS](/examples/emberjs) <img alt="Ember.js" src="https://img.shields.io/badge/-Emberjs-E04E39?style=flat-square&logo=ember.js&logoColor=white" />

Caso sinta falta de um exemplo, na linguagem, biblioteca ou framework, abra uma issue solicitando um projeto de exemplo na tecnologia desejada!

---

## NPM - Node Package Manager

[![npm](https://img.shields.io/npm/v/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)
[![npm](https://img.shields.io/npm/dy/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)

Este repositório está disponível no NPM com o nome [bancos-brasileiros](https://www.npmjs.com/package/bancos-brasileiros).

Um agradecimento ao [@RauppRafael](https://github.com/RauppRafael) por ter idealizado e criado a versão 1.0.0 no NPM.

```bash

npm i bancos-brasileiros

```

## NuGet - Package Manager for .NET

[![BancosBrasileiros NuGet Version](https://img.shields.io/nuget/v/BancosBrasileiros.svg?style=flat)](https://www.nuget.org/packages/BancosBrasileiros/)
[![BancosBrasileiros NuGet Downloads](https://img.shields.io/nuget/dt/BancosBrasileiros.svg?style=flat)](https://www.nuget.org/packages/BancosBrasileiros/)

Este repositório está disponível no NPM com o nome [BancosBrasileiros](https://www.nuget.org/packages/BancosBrasileiros/).

```bash

dotnet add package BancosBrasileiros

```

---

## Siglas e abreviações

Para aqueles que não estão familiarizados com entidades financeiras/regulatórias brasileiras:

- **ABBC** - Associação Brasileira de Bancos
- **BCB** - Banco Central do Brasil (autoridade reguladora) (também chamado de *BACEN* ou *BC*)
- **CIP** - Câmara Interbancária de Pagamentos
- **CNPJ** - Cadastro Nacional de Pessoa Jurídica - *RFB*
- **COMPE** - Sistema de Compensação de Cheques e Outros Papéis
- **CPF** - Cadastro Pessoa Física - *RFB*
- **FEBRABAN** - Federação Brasileira de Bancos
- **ISPB** - Identificação do *SPB*
- **PIX** - Pagamentos Instantâneos
- **RFB** - Receita Federal do Brasil
- **RSFN** - Rede do *SFN*
- **SFN** - Sistema Financeiro Nacional
- **SPB** - Sistema de Pagamentos Brasileiro
- **SPI** - Sistema de Pagamentos Instantâneos
- **STR** - Sistema de Transferência de Reserva

---

## Changelog

[Changelog](/CHANGELOG.md)
