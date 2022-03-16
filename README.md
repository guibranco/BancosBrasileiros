# Bancos Brasileiros

Listagem de bancos comerciais brasileiros

[![Build status](https://ci.appveyor.com/api/projects/status/f9sx7ux82epp8bd6?svg=true)](https://ci.appveyor.com/project/guibranco/bancosbrasileiros)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![GitHub license](https://img.shields.io/github/license/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![GitHub issues by-label](https://img.shields.io/github/issues/guibranco/BancosBrasileiros/help%20wanted.svg)](https://github.com/guibranco/BancosBrasileiros/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)
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
| PIX Type | Tipo de participante PIX/SPI | DRCT - Direto, INDR - Indireto, null |
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
- [Java](/schemas/java.java) <img alt="Java" src="https://img.shields.io/badge/-Java-007396?style=flat-square&logo=java&logoColor=white" />
- [JavaScript](/schemas/javascript.js) <img alt="JavaScript" src="https://img.shields.io/badge/-JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=white" />
- [Kotlin](/schemas/kotlin.kt) <img alt="Kotlin" src="https://img.shields.io/badge/-Kotlin-0095D5?style=flat-square&logo=kotlin&logoColor=white" />
- [PHP](/schemas/php.php) <img alt="PHP" src="https://img.shields.io/badge/-PHP-777BB4?style=flat-square&logo=php&logoColor=white" />
- [Python](/schemas/python.py) <img alt="Python" src="https://img.shields.io/badge/-Python-3776AB?style=flat-square&logo=python&logoColor=white" />
- [Rust](/schemas/rust.rs) <img alt="Rust" src="https://img.shields.io/badge/-Rust-000000?style=flat-square&logo=rust&logoColor=white" />
- [TypeScript](/schemas/typescript.ts) <img alt="TypeScript" src="https://img.shields.io/badge/-TypeScript-3178C6?style=flat-square&logo=typescript&logoColor=white" />

---

## Exemplos

Exemplos de implementação estão disponíveis na pasta [examples](/examples), atualmente dispomos de exemplos nas seguintes tecnologias:

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

- 2022-03-16: Adicionado 3 bancos (385 - CECM DOS TRAB.PORT. DA G.VITOR, 469 - LECCA DTVM LTDA, 470 - CDC SOCIEDADE DE CRÉDITO). Atualizado 5 bancos (113 - NEON CTVM S.A., 250 - "BCV - BCO, CRÉDITO E VAREJO S.A.", 289 - EFX CC LTDA., 322 - CCR DE ABELARDO LUZ, 468 - PORTOSEG S.A. CFI). - [@guibranco](https://github.com/guibranco)
- 2022-02-16: Adicionado 1 bancos (468 - PORTOSEG S.A. CFI). Atualizado 6 bancos (190 - SERVICOOP, 197 - STONE IP S.A., 290 - PAGSEGURO INTERNET IP S.A., 428 - CRED-SYSTEM SCD S.A., 430 - CCR SEARA, 450 - FITBANK PAGAMENTOS ELETRONICOS S.A.). - [@guibranco](https://github.com/guibranco)
- 2022-02-01: Adicionado 2 bancos (451 - J17 - SCD S/A, 460 - UNAVANTI SCD S/A). Atualizado 3 bancos (197 - STONE PAGAMENTOS S.A., 269 - BCO HSBC S.A., 323 - MERCADO PAGO IP LTDA.). - [@guibranco](https://github.com/guibranco)
- 2022-01-05: Adicionado 1 bancos (463 - AZUMI DTVM). Atualizado 6 bancos (350 - CREHNOR LARANJEIRAS, 378 - BCO BRASILEIRO DE CRÉDITO S.A., 412 - SOCIAL BANK S/A, 419 - NUMBRS SCD S.A., 600 - BCO LUSO BRASILEIRO S.A., 743 - BANCO SEMEAR). - [@guibranco](https://github.com/guibranco)
- 2021-12-13: Adicionado 2 bancos (467 - MASTER S/A CCTVM, 465 - CAPITAL CONSIG SCD S.A.). Atualizado 4 bancos (382 - FIDUCIA SCMEPP LTDA, 383 - EBANX IP LTDA., 402 - COBUCCIO SCD S.A., 462 - STARK SCD S.A.). - [@guibranco](https://github.com/guibranco)
- 2021-11-22: Adicionado 4 bancos (459 - CCM SERV. PÚBLICOS SP, 461 - ASAAS IP S.A., 443 - CREDIHOME SCD, 454 - MÉRITO DTVM LTDA.). Atualizado 2 bancos (380 - PICPAY, 457 - UY3 SCD S/A). - [@guibranco](https://github.com/guibranco)
- 2021-10-23: Adicionado 3 bancos (449 - DMCARD SCD S.A., 457 - PLATACRED SCD S.A., 462 - STARK SCD S.A.). Atualizado 3 bancos (14 - STATE STREET BR S.A. BCO COMERCIAL, 84 - UNIPRIME DO BRASIL - CC LTDA., 440 - CREDIBRF COOP). - [@guibranco](https://github.com/guibranco)
- 2021-09-28: Adicionado 2 bancos (447 - MIRAE ASSET CCTVM LTDA, 439 - ID CTVM). Atualizado 4 bancos (14 - STATE STREET BR S.A. BCO COMERCIAL, 113 - MAGLIANO S A  CTVM, 140 - NU INVEST CORRETORA DE VALORES S.A., 260 - NU PAGAMENTOS - IP). - [@guibranco](https://github.com/guibranco)
- 2021-09-13: Adicionado 6 bancos (429 - CREDIARE CFI S.A., 458 - HEDGE INVESTMENTS DTVM LTDA., 452 - CREDIFIT SCD S.A., 444 - TRINUS SCD S.A., 440 - CECM BRF, 442 - MAGNETIS - DTVM). Atualizado 2 bancos (352 - TORO CTVM S.A., 630 - BCO LETSBANK S.A.). - [@guibranco](https://github.com/guibranco)
- 2021-08-24: - Adicionado 5 bancos (430 - CCR SEARA, 195 - VALOR SCD S.A., 418 - ZIPDIN SCD S.A., 435 - DELCRED SCD S.A., 448 - HEMERA DTVM LTDA.) - Atualizado 3 bancos (174 - PEFISA S.A. - C.F.I., 400 - COOP CREDITAG, 745 - BCO CITIBANK S.A.) - [@guibranco](https://github.com/guibranco)
- 2021-08-02: Adicionado 2 novos bancos (421 - LAR CREDI e 425 - SOCINAL), atualizado 2 novos participantes do SPI (PIX) e atualizado nome de 2 bancos - [@guibranco](https://github.com/guibranco)
- 2021-06-22: Adicionado 2 novos bancos e atualizado 4 novos participantes do SPI (PIX) - [@guibranco](https://github.com/guibranco)
- 2021-06-09: [Issue #82](https://github.com/guibranco/BancosBrasileiros/issues/82) - Corrigido caracter inválido no nome do banco COMPE 014 - [@mdapper](https://github.com/mdapper)
- 2021-05-21: [Issue #75](https://github.com/guibranco/BancosBrasileiros/milestone/75) - Adicionado BIORC - [@guibranco](https://github.com/guibranco)
- 2021-05-21: [Issue #74](https://github.com/guibranco/BancosBrasileiros/milestone/74) - Adicionado BV - [@guibranco](https://github.com/guibranco)
- 2021-05-05: [Issue #50](https://github.com/guibranco/BancosBrasileiros/milestone/50) - Dados do PIX - [@guibranco](https://github.com/guibranco)
- 2021-04-28: [Milestone #1](https://github.com/guibranco/BancosBrasileiros/milestone/1) - Versão 2 - [@guibranco](https://github.com/guibranco)
- 2021-04-27: [Issue #45](http://github.com/guibranco/BancosBrasileiros/issues/45) - Adicionado schemas/classes - [@guibranco](https://github.com/guibranco)
- 2021-04-27: [Issue #44](http://github.com/guibranco/BancosBrasileiros/issues/44) - Adicionado lista Markdown - [@guibranco](https://github.com/guibranco)
- 2021-04-27: [Issue #42](http://github.com/guibranco/BancosBrasileiros/issues/42) - Código COMPE no arquivo Bancos.sql convertido de integer para string/varchar - [@silverio27](https://github.com/silverio27)
- 2021-04-27: [Issue #36](http://github.com/guibranco/BancosBrasileiros/issues/36) - Listas normalizadas (dados e estrutura) - [@guibranco](https://github.com/guibranco)
- 2021-04-27: [Issue #31](http://github.com/guibranco/BancosBrasileiros/issues/31) - Adicionado ISP nas listas - [@guibranco](https://github.com/guibranco)
- 2021-04-27: [Issue #9](http://github.com/guibranco/BancosBrasileiros/issues/9) - Adicionado sites nas listas - [@guibranco](https://github.com/guibranco)
- 2021-04-27: [Issue #4](http://github.com/guibranco/BancosBrasileiros/issues/4) - Adicionado CNPJ nas listas - [@guibranco](https://github.com/guibranco)
- 2021-01-20: [Issue #53](http://github.com/guibranco/BancosBrasileiros/issues/53) - Adicionado Digio - [@gslvrp](https://github.com/gslvrp)
- 2021-01-06: [Issue #51](http://github.com/guibranco/BancosBrasileiros/issues/51) - Adicionado PicPay - [@kingaspx](https://github.com/kingaspx)
- 2020-06-18: [Issue #46](http://github.com/guibranco/BancosBrasileiros/issues/46) - Corrige dados do Santander - [@raframil](https://github.com/raframil)
- 2020-05-12: [Issue #41](http://github.com/guibranco/BancosBrasileiros/issues/41) - Corrige data de atualização do Banco Neon - [@silverio27](https://github.com/silverio27)
- 2020-05-12: [Issue #41](http://github.com/guibranco/BancosBrasileiros/issues/41) - Corrigido data de atualização do Banco Neon - [@silverio27](https://github.com/silverio27)
- 2020-04-29: [Issue #40](http://github.com/guibranco/BancosBrasileiros/issues/40) - Corrigido nome do Banco Inter - [@iurisilvio](https://github.com/iurisilvio)
- 2020-04-28: Removido vírgula em excesso no arquivo bancos.json - [@wesleydeveloper](https://github.com/wesleydeveloper)
- 2020-04-24: [Issue #35](https://github.com/guibranco/BancosBrasileiros/issues/35) - Adicionado Stone Pagamentos S.A. - [@lucastorress](https://github.com/lucastorress)
- 2020-04-23: [Issue #34](https://github.com/guibranco/BancosBrasileiros/issues/34) - Publicação automática do pacote NPM - [@guibranco](https://github.com/guibranco)
- 2020-04-23: [Issue #32](https://github.com/guibranco/BancosBrasileiros/issues/32) - Corrigido dados do Banco Órama em bancos.sql - [@VGsss](https://github.com/VGsss)
- 2020-04-23: [Issue #33](https://github.com/guibranco/BancosBrasileiros/issues/33) - Corrigido dados do RaboBank - [@rpenha](https://github.com/rpenha)
- 2020-04-17: Atualização do readme.md e do readme.en.md, publicação do github.io pages
- 2020-04-15: [Issue #30](https://github.com/guibranco/BancosBrasileiros/issues/30) - Adicionado package.json para pacote NPM - [@RauppRafael](https://github.com/RauppRafael)
- 2020-04-15: Adicionado badges - [@guibranco](https://github.com/guibranco)
- 2020-03-20: [Issue #25](https://github.com/guibranco/BancosBrasileiros/issues/25) - Corrigido acentuação do Banco de Brasília - [@luisccf](https://github.com/luisccf)
- 2020-03-20: [Issue #28](https://github.com/guibranco/BancosBrasileiros/issues/28) - Adicionado Banco Brasil Plural - [@lucastorress](https://github.com/lucastorress)
- 2020-03-20: [Issue #27](https://github.com/guibranco/BancosBrasileiros/issues/27) - Adicionado Cooperativa Central de Crédito - AILOS - [@olvsamuel](https://github.com/olvsamuel)
- 2020-03-20: [Issue #29](https://github.com/guibranco/BancosBrasileiros/issues/29) - Adicionado coluna "UpdatedAt" em bancos.sql - [@guibranco](https://github.com/guibranco)
- 2020-03-20: [Issue #22](https://github.com/guibranco/BancosBrasileiros/issues/22) - Adicionado Banco Máxima - [@guibranco](https://github.com/guibranco)
- 2020-02-19: [Issue #23](https://github.com/guibranco/BancosBrasileiros/issues/23) - Corrigido dados do NuBank - [@rodrigondec](https://github.com/rodrigondec)
- 2020-01-15: [Issue #21](https://github.com/guibranco/BancosBrasileiros/issues/21) - Adicionado Órama DTVM S.A. - [@guibranco](https://github.com/guibranco)
- 2019-12-26: [Issue #19](https://github.com/guibranco/BancosBrasileiros/issues/19) - Adicionado Acesso Soluções e Pagamento S.A. - [@baldini](https://github.com/Baldini)
- 2019-11-12: [Issue #17](https://github.com/guibranco/BancosBrasileiros/issues/17) - Adicionado coluna IsDeleted no arquivo .sql - [@guibranco](https://github.com/guibranco)
- 2019-11-12: [Issue #16](https://github.com/guibranco/BancosBrasileiros/issues/16) - Substituido Banco Potencial pelo Neon. Removido banco Neon - [@RauppAndPony](https://github.com/RauppAndPony)
- 2019-08-02: [Issue #11](https://github.com/guibranco/BancosBrasileiros/issues/11) - Adicionado Banco C6 - [@guibranco](https://github.com/guibranco)
- 2019-05-21: [Issue #10](https://github.com/guibranco/BancosBrasileiros/issues/10) - Adicionado versão inglês do **README.md** - [@guibranco](https://github.com/guibranco)
- 2019-05-21: [Issue #5](https://github.com/guibranco/BancosBrasileiros/issues/5) e [Issue #6](https://github.com/guibranco/BancosBrasileiros/issues/6) - Adicionado listas **CSV** e **XML** dos dados - [@guibranco](https://github.com/guibranco)
- 2019-05-21: [Issue #8](https://github.com/guibranco/BancosBrasileiros/issues/8) - Adicionado Banco BS2 - [@guibranco](https://github.com/guibranco)
- 2019-04-03: [PR #7](https://github.com/guibranco/BancosBrasileiros/pull/7) - Corrigido nome do Bradesco em bancos.json - [@jesobreira](https://github.com/jesobreira)
- 2019-01-15: [Issue #3](https://github.com/guibranco/BancosBrasileiros/issues/3) - Adicionado Banco Inter em bancos.sql - [@diegolourenco](https://github.com/DiegoLourenco)
- 2019-01-15: Renomeado arquivos para **bancos.formato** - [@guibranco](https://github.com/guibranco)
- 2018-01-28: Adicionado formato **JSON** - [@raphaelcunha](https://github.com/raphaelcunha)
- 2018-01-28: Adicionado XP Investimentos e NuBank - [@raphaelcunha](https://github.com/raphaelcunha)
- 2017-10-26: Adicionado 248 bancos no formato **T-SQL** - [@guibranco](https://github.com/guibranco)
