# Bancos Brasileiros

<p align="center">
  <img src="https://raw.githubusercontent.com/guibranco/BancosBrasileiros/main/logo.png" alt="Logotipo Bancos Brasileiros" width="300"/>
</p>

<p align="center">
  🇧🇷 🏦 📋 <strong>Base de Dados Abrangente de Instituições Financeiras Brasileiras</strong>
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
  <a href="https://github.com/guibranco/BancosBrasileiros/security"><img src="https://img.shields.io/github/vulnerabilities/guibranco/BancosBrasileiros" alt="Known Vulnerabilities"></a>
  <a href="https://github.com/guibranco/bancosbrasileiros/issues"><img src="https://img.shields.io/github/issues/guibranco/bancosbrasileiros" alt="GitHub issues"></a>
</p>

> [!Important]
>
> Para a versão em inglês (EN_US) do README.md, [clique aqui](https://github.com/guibranco/BancosBrasileiros) por favor.

---

## 📖 Visão Geral

Bancos Brasileiros é uma base de dados abrangente contendo informações sobre mais de 400 instituições financeiras brasileiras registradas. Os dados são automaticamente atualizados diariamente a partir de fontes oficiais usando nossa [Ferramenta de Mesclagem](https://github.com/guibranco/BancosBrasileiros-MergeTool).

## 📊 Formatos de Dados Disponíveis

A base de dados está disponível em múltiplos formatos para atender às suas necessidades:

- [**CSV**](/data/bancos.csv) - Para aplicativos de planilha e análise de dados
- [**JSON**](/data/bancos.json) - Para aplicações web e APIs
- [**Markdown**](/data/bancos.md) - Para documentação e projetos no GitHub
- [**SQL**](/data/bancos.sql) - Para implementações de banco de dados
- [**XML**](/data/bancos.xml) - Para sistemas legados e aplicações específicas

## 🏛️ Esquema de Dados

Cada entrada na base de dados contém as seguintes informações:

| Campo | Descrição | Formato |
|:------|:------------|:-------|
| **COMPE** | Código do banco (Sistema de Compensação) | 3 dígitos |
| **ISPB** | ID do Sistema de Pagamentos Brasileiro | 8 dígitos |
| **Document** | CNPJ (Cadastro Nacional de Pessoa Jurídica) | 14 números ou 18 dígitos (formatado) |
| **LongName** | Nome oficial da instituição | Conforme registrado no BACEN/STR |
| **ShortName** | Nome abreviado | Conforme registrado no BACEN/STR |
| **Network** | Tipo de rede de conexão | RSFN, Internet, ou nulo |
| **Type** | Tipo de instituição | comercial, múltiplo, poupança, ou nulo |
| **PixType** | Tipo de participação no PIX/SPI | DRCT (Direto), INDR (Indireto), ou nulo |
| **Charge** | Suporta operações de cobrança | verdadeiro, falso, ou nulo |
| **CreditDocument** | Suporta operações TED | verdadeiro, falso, ou nulo |
| **LegalCheque** | Participação no "Cheque Legal" | verdadeiro ou falso |
| **DetectaFlow** | Participação no "Detecta Flow" | verdadeiro ou falso |
| **PCR** | Participação no "PCR" | verdadeiro ou falso |
| **PCRP** | Participação no "PCRP" | verdadeiro ou falso |
| **SalaryPortability** | Suporte à portabilidade salarial | "Banco folha e Destinatário" (ambos), "Destinatário" (apenas recebimento), ou nulo |
| **Products** | Produtos financeiros oferecidos | Lista em português |
| **Url** | Site oficial | Formato URL |
| **DateOperationStarted** | Data de início das operações comerciais | Formato de data |
| **DatePixStarted** | Data de início das operações PIX | Formato de data (apenas participantes PIX) |
| **DateRegistered** | Data de criação da entrada no banco de dados | Formato de data |
| **DateUpdated** | Última atualização da entrada no banco de dados | Formato de data |

## 🛠️ Arquivos de Esquema e Definições de Classes

### Arquivos de Esquema

Definições de esquema prontas para uso estão disponíveis na pasta [schemas](/schemas):

- [Esquema JSON](/schemas/schema.json)
- [Esquema SQL](/schemas/schema.sql)
- [Esquema XML](/schemas/schema.xml)

### Definições de Classes

Use nossas definições de classe pré-construídas em várias linguagens de programação:

<div align="center">

| Linguagem | Arquivo | Distintivo |
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

## 📝 Exemplos de Implementação

Exemplos práticos de implementação estão disponíveis na pasta [examples](/examples):

<div align="center">

| Tecnologia | Diretório | Distintivo |
|:-----------|:----------|:--|
| [Dart](/examples/dart/) | `/examples/dart/` | <img alt="Dart" src="https://img.shields.io/badge/-Dart-00C3B1?style=flat-square&logo=dart&logoColor=white" /> |
| [.NET/C#](/examples/dotnet) | `/examples/dotnet/` | <img alt=".NET" src="https://img.shields.io/badge/-.NET-5C2D91?style=flat-square&logo=dotnet&logoColor=white" /><img alt="C Sharp" src="https://img.shields.io/badge/-C_Sharp-239120?style=flat-square&logo=dotnet&logoColor=white" /> |
| [EmberJS](/examples/emberjs) | `/examples/emberjs/` | <img alt="Ember.js" src="https://img.shields.io/badge/-Emberjs-E04E39?style=flat-square&logo=ember.js&logoColor=white" /> |
| [PHP](/examples/php) | `/examples/php/` | <img alt="PHP" src="https://img.shields.io/badge/-PHP-777BB4?style=flat-square&logo=php&logoColor=white" /> |

</div>

> [!Dica]
> Precisa de um exemplo para uma linguagem ou framework específico? [Abra uma issue](https://github.com/guibranco/bancosbrasileiros/issues) solicitando!

## 📦 Integrações com Gerenciadores de Pacotes

### Rust Crates (Cargo)

[![Crates.io](https://img.shields.io/crates/v/bancos_brasileiros.svg)](https://crates.io/crates/bancos_brasileiros)

```toml
[dependencies]
bancos_brasileiros = "0.1.0"
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

## 📚 Siglas do Sistema Financeiro

Entendendo a terminologia do sistema financeiro brasileiro:

<!--START_SECTION:abbreviations-section-->
<table width="100%"><tr><th>ABBC</th><td> Associação Brasileira de Bancos</td></tr><tr><th>BCB</th><td> Banco Central do Brasil (autoridade reguladora) (também conhecido como BACEN ou BC)</td></tr><tr><th>CIP</th><td> Câmara Interbancária de Pagamentos</td></tr><tr><th>CNPJ</th><td> Cadastro Nacional de Pessoa Jurídica - RFB</td></tr><tr><th>COMPE</th><td> Sistema de Compensação de Cheques e Outros Papéis</td></tr><tr><th>CTC</th><td> Central de Transferência de Crédito</td></tr><tr><th>CPF</th><td> Cadastro de Pessoa Física - RFB</td></tr><tr><th>CVM</th><td> Comissão de Valores Mobiliários</td></tr><tr><th>FEBRABAN</th><td> Federação Brasileira de Bancos</td></tr><tr><th>ISPB</th><td> Identificação de SPB</td></tr><tr><th>PCPS</th><td> Plataforma Centralizada de Portabilidade de Salário</td></tr><tr><th>PCR</th><td> Plataforma Centralizada de Recebíveis</td></tr><tr><th>PIX</th><td> Pagamentos Instantâneos Brasileiro</td></tr><tr><th>RFB</th><td> Receita Federal do Brasil</td></tr><tr><th>RSFN</th><td> Rede do Sistema Financeiro Nacional</td></tr><tr><th>SFN</th><td> Sistema Financeiro Nacional</td></tr><tr><th>SLC</th><td> Serviço de Liquidação Cartões</td></tr><tr><th>SILOC</th><td> Sistema de Liquidação Diferida das Transferências Interbancárias de Ordens de Crédito</td></tr><tr><th>SITRAF</th><td> Sistema de Transferência de Fundos</td></tr><tr><th>SPB</th><td> Sistema de Pagamentos Brasileiro</td></tr><tr><th>SPI</th><td> Sistema de Pagamentos Instantâneos</td></tr><tr><th>STR</th><td> Sistema de Transferência de Reservas</td></tr></table>
<!--END_SECTION:abbreviations-section-->

## 🔄 Atualizações e Qualidade dos Dados

A base de dados é **atualizada automaticamente diariamente** usando nossa [Ferramenta de Mesclagem](https://github.com/guibranco/BancosBrasileiros-MergeTool) que coleta informações de fontes oficiais.

> [!Aviso]
>
> Encontrou dados ausentes ou incorretos? Por favor [abra uma issue](https://github.com/guibranco/BancosBrasileiros/issues/new/choose)

## 📜 Registro de Alterações

Veja nosso [registro de alterações](/CHANGELOG.md) completo para um histórico detalhado de atualizações.

## 👨‍💻 Contribuidores

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
                <a href="https://github.com/mvanhorn">
                    <img src="https://avatars.githubusercontent.com/u/455140?v=4" width="100;" alt="mvanhorn"/>
                    <br />
                    <sub><b>Matt Van Horn</b></sub>
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
                <a href="https://github.com/joaovaladares">
                    <img src="https://avatars.githubusercontent.com/u/42593399?v=4" width="100;" alt="joaovaladares"/>
                    <br />
                    <sub><b>João V. Valadares</b></sub>
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
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/sahalhes">
                    <img src="https://avatars.githubusercontent.com/u/146409442?v=4" width="100;" alt="sahalhes"/>
                    <br />
                    <sub><b>E S Sahal Hussain</b></sub>
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
                <a href="https://github.com/deepsource-autofix[bot]">
                    <img src="https://avatars.githubusercontent.com/in/57168?v=4" width="100;" alt="deepsource-autofix[bot]"/>
                    <br />
                    <sub><b>deepsource-autofix[bot]</b></sub>
                </a>
            </td>
		</tr>
		<tr>
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
            <td align="center">
                <a href="https://github.com/deepsource-io[bot]">
                    <img src="https://avatars.githubusercontent.com/in/16372?v=4" width="100;" alt="deepsource-io[bot]"/>
                    <br />
                    <sub><b>deepsource-io[bot]</b></sub>
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
