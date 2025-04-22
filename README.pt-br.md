# Bancos Brasileiros

🇧🇷 🏦 📋 Lista de bancos comerciais brasileiros

[![Build status](https://ci.appveyor.com/api/projects/status/f9sx7ux82epp8bd6?svg=true)](https://ci.appveyor.com/project/guibranco/bancosbrasileiros)
[![Daily updates](https://github.com/guibranco/BancosBrasileiros/actions/workflows/daily-updates.yml/badge.svg)](https://github.com/guibranco/BancosBrasileiros/actions/workflows/daily-updates.yml)
[![Link checker](https://github.com/guibranco/BancosBrasileiros/actions/workflows/link-checker.yml/badge.svg)](https://github.com/guibranco/BancosBrasileiros/actions/workflows/link-checker.yml)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![GitHub license](https://img.shields.io/github/license/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![time tracker](https://wakatime.com/badge/github/guibranco/BancosBrasileiros.svg)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)

[![Maintainability](https://api.codeclimate.com/v1/badges/2dfea6fc7a71e09ea7da/maintainability)](https://codeclimate.com/github/guibranco/BancosBrasileiros/maintainability) [![CodeFactor](https://www.codefactor.io/repository/github/guibranco/BancosBrasileiros/badge)](https://www.codefactor.io/repository/github/guibranco/BancosBrasileiros)
[![codebeat badge](https://codebeat.co/badges/6ca48409-5cda-48b2-844e-9248c2416865)](https://codebeat.co/projects/github-com-guibranco-bancosbrasileiros-main)
[![Known Vulnerabilities](https://snyk.io/test/github/guibranco/BancosBrasileiros/badge.svg?style=plastic)](https://snyk.io/test/github/guibranco/BancosBrasileiros)
[![GitHub issues](https://img.shields.io/github/issues/guibranco/bancosbrasileiros)](https://github.com/guibranco/bancosbrasileiros/issues)

![Bancos Brasileiros logo](logo.png)

> [!Note]
>
> For an English *(EN_US)* version of README.md, please [follow me](https://guibranco.github.io/BancosBrasileiros/).

---

## Lista de Bancos

### Formatos

Esta lista contém 400+ bancos cadastrados, nos seguintes formatos:

- **CSV**: [bancos.csv](/data/bancos.csv)
- **JSON**: [bancos.json](/data/bancos.json)
- **Markdown**: [bancos.md](/data/bancos.md)
- **SQL**: [bancos.sql](/data/bancos.sql)
- **XML**: [bancos.xml](/data/bancos.xml)

### Dados disponíves

Cada uma das listas possui as seguintes informações (schema):

| Coluna | Descrição | Observações |
|:------:|:---------:|:-----------:|
| COMPE | Código - COMPE | 3 dígitos |
| ISPB | Código - ISPB | 8 dígitos |
| Document | Documento - CNPJ | 14 números - 18 dígitos (formatado) |
| LongName | Nome extenso | Conforme BACEN - STR |
| ShortName | Nome reduzido | Conforme BACEN - STR |
| Network | Rede | RSFN, Internet, null |
| Type | Tipo | comercial, múltiplo, caixa econômica, null |
| PixType | Tipo de participante PIX/SPI | DRCT - Direto, INDR - Indireto, null |
| Charge | Efetua cobrança | true, false, null |
| CreditDocument | Efetua TED | true, false, null |
| LegalCheque | Se pertence ao "Cheque Legal" | true, false |
| Detecta Flow | Se pertence ao "Detecta Flow" | true, false |
| PCR | Se pertence ao "PCR" | true, false |
| PCRP | Se pertence ao "PCRP" | true, false |
| SalaryPortability | Efetua/recebe portabilidade de salário | "Banco folha e Destinatário" - ambas as operações,  "Destinatário" - apenas recebe, null |
| Products | Lista de produtos oferecidos | Apenas em português |
| Url | Website | - |
| DateOperationStarted | Data de início da operação comercial | - |
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

- [C#](/schemas/csharp.cs) <img alt="C Sharp" src="https://img.shields.io/badge/-C_Sharp-239120?style=flat-square&logo=csharp&logoColor=white" />
- [Dart](/schemas/dart.dart) <img alt="Dart" src="https://img.shields.io/badge/-Dart-00C3B1?style=flat-square&logo=dart&logoColor=white" />
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

- [Dart](/exAMPLES/dart/) <img alt="Dart" src="https://img.shields.io/badge/-Dart-00C3B1?style=flat-square&logo=dart&logoColor=white" />
- [.NET/C#](/examples/dotnet) <img alt=".NET" src="https://img.shields.io/badge/-.NET-5C2D91?style=flat-square&logo=dotnet&logoColor=white" /><img alt="C Sharp" src="https://img.shields.io/badge/-C_Sharp-239120?style=flat-square&logo=c-sharp&logoColor=white" />
- [EmberJS](/examples/emberjs) <img alt="Ember.js" src="https://img.shields.io/badge/-Emberjs-E04E39?style=flat-square&logo=ember.js&logoColor=white" />
- [PHP](/examples/php) <img alt="PHP" src="https://img.shields.io/badge/-PHP-777BB4?style=flat-square&logo=php&logoColor=white" />

Caso sinta falta de um exemplo, na linguagem, biblioteca ou framework, abra uma issue solicitando um projeto de exemplo na tecnologia desejada!

---

## NPM - Node Package Manager

[![npm](https://img.shields.io/npm/v/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)
[![npm](https://img.shields.io/npm/dy/bancos-brasileiros)](https://www.npmjs.com/package/bancos-brasileiros)

Este repositório está disponível no [NPM](https://www.npmjs.com) com o nome [bancos-brasileiros](https://www.npmjs.com/package/bancos-brasileiros).

Um agradecimento ao [@RauppRafael](https://github.com/RauppRafael) por ter idealizado e criado a versão 1.0.0 no NPM.

```bash

npm i bancos-brasileiros

```

## NuGet - Package Manager for .NET

[![BancosBrasileiros NuGet Version](https://img.shields.io/nuget/v/BancosBrasileiros.svg?style=flat)](https://www.nuget.org/packages/BancosBrasileiros/)
[![BancosBrasileiros NuGet Downloads](https://img.shields.io/nuget/dt/BancosBrasileiros.svg?style=flat)](https://www.nuget.org/packages/BancosBrasileiros/)

Este repositório está disponível no [NuGet](https://www.nuget.org) com o nome [BancosBrasileiros](https://www.nuget.org/packages/BancosBrasileiros/).

```bash

dotnet add package BancosBrasileiros

```

## Packagist - Package Manager for PHP/Composer

[![BancosBrasileiros Packagist Version](https://img.shields.io/packagist/v/guibranco/bancos-brasileiros.svg?style=flat)](https://packagist.org/packages/guibranco/bancos-brasileiros)
[![BancosBrasileiros Packagist Downloads](https://img.shields.io/packagist/dt/guibranco/bancos-brasileiros.svg?style=flat)](https://packagist.org/packages/guibranco/bancos-brasileiros)

ste repositório está disponível no  [Packagist](https://packagist.org) com o nome [guibranco/bancos-brasileiros](https://packagist.org/packages/guibranco/bancos-brasileiros)

```bash

composer require guibranco/bancos-brasileiros

```

---

## Siglas e abreviações

Para aqueles que não estão familiarizados com entidades financeiras/regulatórias brasileiras:

<!--START_SECTION:abbreviations-section-->
<table width="100%"><tr><th>ABBC</th><td> Associação Brasileira de Bancos</td></tr><tr><th>BCB</th><td> Banco Central do Brasil (autoridade reguladora) (também conhecido como BACEN ou BC)</td></tr><tr><th>CIP</th><td> Câmara Interbancária de Pagamentos</td></tr><tr><th>CNPJ</th><td> Cadastro Nacional de Pessoa Jurídica - RFB</td></tr><tr><th>COMPE</th><td> Sistema de Compensação de Cheques e Outros Papéis</td></tr><tr><th>CTC</th><td> Central de Transferência de Crédito</td></tr><tr><th>CPF</th><td> Cadastro de Pessoa Física - RFB</td></tr><tr><th>CVM</th><td> Comissão de Valores Mobiliários</td></tr><tr><th>FEBRABAN</th><td> Federação Brasileira de Bancos</td></tr><tr><th>ISPB</th><td> Identificação de SPB</td></tr><tr><th>PCPS</th><td> Plataforma Centralizada de Portabilidade de Salário</td></tr><tr><th>PCR</th><td> Plataforma Centralizada de Recebíveis</td></tr><tr><th>PIX</th><td> Pagamentos Instantâneos Brasileiro</td></tr><tr><th>RFB</th><td> Receita Federal do Brasil</td></tr><tr><th>RSFN</th><td> Rede do Sistema Financeiro Nacional</td></tr><tr><th>SFN</th><td> Sistema Financeiro Nacional</td></tr><tr><th>SLC</th><td> Serviço de Liquidação Cartões</td></tr><tr><th>SILOC</th><td> Sistema de Liquidação Diferida das Transferências Interbancárias de Ordens de Crédito</td></tr><tr><th>SITRAF</th><td> Sistema de Transferência de Fundos</td></tr><tr><th>SPB</th><td> Sistema de Pagamentos Brasileiro</td></tr><tr><th>SPI</th><td> Sistema de Pagamentos Instantâneos</td></tr><tr><th>STR</th><td> Sistema de Transferência de Reservas</td></tr></table>
<!--END_SECTION:abbreviations-section-->

---

## Atualizações

Os dados são atualizados diariamente de forma automática por meio de uma [ferramenta](https://github.com/guibranco/BancosBrasileiros-MergeTool) que coleta as informações de listas de fontes oficiais.

> [!Warning]
>
> Se você encontrar algum problema com os dados, banco ausente ou dados desatualizados, abra um issue neste repositório: [Novo Issue](https://github.com/guibranco/BancosBrasileiros/issues/new/choose)

---

## Changelog

[Changelog](/CHANGELOG.md)

---

## Contributors

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
                <a href="https://github.com/BrunoM90">
                    <img src="https://avatars.githubusercontent.com/u/152902220?v=4" width="100;" alt="BrunoM90"/>
                    <br />
                    <sub><b>Null</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/sahalhes">
                    <img src="https://avatars.githubusercontent.com/u/146409442?v=4" width="100;" alt="sahalhes"/>
                    <br />
                    <sub><b>E S Sahal Hussain</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/Erick-Bueno">
                    <img src="https://avatars.githubusercontent.com/u/101439440?v=4" width="100;" alt="Erick-Bueno"/>
                    <br />
                    <sub><b>Erick Bueno</b></sub>
                </a>
            </td>
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/pferreirafabricio">
                    <img src="https://avatars.githubusercontent.com/u/42717522?v=4" width="100;" alt="pferreirafabricio"/>
                    <br />
                    <sub><b>Fabrício Pinto Ferreira</b></sub>
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
            </td>
            <td align="center">
                <a href="https://github.com/joaovaladares">
                    <img src="https://avatars.githubusercontent.com/u/42593399?v=4" width="100;" alt="joaovaladares"/>
                    <br />
                    <sub><b>João V. Valadares</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/leogregianin">
                    <img src="https://avatars.githubusercontent.com/u/1684053?v=4" width="100;" alt="leogregianin"/>
                    <br />
                    <sub><b>Leonardo Gregianin</b></sub>
                </a>
            </td>
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/MauriciDmarc">
                    <img src="https://avatars.githubusercontent.com/u/129069676?v=4" width="100;" alt="MauriciDmarc"/>
                    <br />
                    <sub><b>Maurici Dmarco</b></sub>
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
                <a href="https://github.com/victorbrandaao">
                    <img src="https://avatars.githubusercontent.com/u/85573492?v=4" width="100;" alt="victorbrandaao"/>
                    <br />
                    <sub><b>Victor Leonardo Brandão</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/AmolKumarGupta">
                    <img src="https://avatars.githubusercontent.com/u/88397611?v=4" width="100;" alt="AmolKumarGupta"/>
                    <br />
                    <sub><b>Amol</b></sub>
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
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/vduggen">
                    <img src="https://avatars.githubusercontent.com/u/53385727?v=4" width="100;" alt="vduggen"/>
                    <br />
                    <sub><b>Vitor Duggen</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: collaborators,contributors,snyk-bot/-,guistracini-outsurance-ie/- -end -->

## Bots

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
                <a href="https://github.com/github-actions[bot]">
                    <img src="https://avatars.githubusercontent.com/in/15368?v=4" width="100;" alt="github-actions[bot]"/>
                    <br />
                    <sub><b>github-actions[bot]</b></sub>
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
            <td align="center">
                <a href="https://github.com/stack-file[bot]">
                    <img src="https://avatars.githubusercontent.com/in/408123?v=4" width="100;" alt="stack-file[bot]"/>
                    <br />
                    <sub><b>stack-file[bot]</b></sub>
                </a>
            </td>
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/codefactor-io[bot]">
                    <img src="https://avatars.githubusercontent.com/in/25603?v=4" width="100;" alt="codefactor-io[bot]"/>
                    <br />
                    <sub><b>codefactor-io[bot]</b></sub>
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
                <a href="https://github.com/deepsource-io[bot]">
                    <img src="https://avatars.githubusercontent.com/in/16372?v=4" width="100;" alt="deepsource-io[bot]"/>
                    <br />
                    <sub><b>deepsource-io[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/gstraccini[bot]">
                    <img src="https://avatars.githubusercontent.com/in/480132?v=4" width="100;" alt="gstraccini[bot]"/>
                    <br />
                    <sub><b>gstraccini[bot]</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: snyk-bot,bots -end -->
