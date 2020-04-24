# Bancos Brasileiros 
Listagem de bancos comerciais brasileiros 

![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)
![GitHub license](https://img.shields.io/github/license/guibranco/BancosBrasileiros)
[![GitHub issues by-label](https://img.shields.io/github/issues/guibranco/BancosBrasileiros/help%20wanted.svg)](https://github.com/guibranco/BancosBrasileiros/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)
[![time tracker](https://wakatime.com/badge/github/guibranco/BancosBrasileiros.svg)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)

***For a english version of README.md, please [follow me](/README.en.md)***

--- 

## Lista de bancos

### Formatos

Esta lista contém 259 bancos cadastrados, nos seguintes formatos:

- **CSV**: [bancos.csv](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.csv)
- **JSON**: [bancos.json](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.json)
- **SQL**: [bancos.sql](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.sql)
- **XML**: [bancos.xml](https://github.com/guibranco/BancosBrasileiros/blob/master/bancos.xml)

### Dados disponíves

Cada uma das listas possui as seguintes informações:

| Coluna | Descrição | Observações |
|-------------------|:---------------------------------------:|:--------------------------------------------------------------------------:|
| COMPE | Código do Banco - COMPE | 3 dígitos |
| ISPB | Código do Banco - ISPB | 8 dígitos (TODO [Issue #31](https://github.com/guibranco/BancosBrasileiros/issues/31)) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Name | Razão Social ou Nome Fantasia do Banco | - |
| CNPJ | Documento do Banco | (TODO [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4)) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Url  | Url do website | (TODO [Issue #9](https://github.com/guibranco/BancosBrasileiros/issues/9)) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Data de cadastro | Data de cadastro no schema | (TODO bancos.sql) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Data de alteração | Data de alteração no schema | - |
| Data de remoção | Data de remoção no schema | (TODO bancos.sql) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted) |
| Removido | Flag indicativa se este banco foi removido ou não | DELETE lógico |

---

## NPM - Node Package Manager

Este repositório está disponível no NPM com o nome [bancos-brasileiros](https://www.npmjs.com/package/bancos-brasileiros).
Um agradecimento ao [@RauppRafael](https://github.com/RauppRafael) por ter idealizado e criado a versão 1.0.0 no NPM.

```bash

npm i bancos-brasileiros

```

---

## Siglas e abreviações

Para aqueles que não estão familiarizados com entidades brasileiras:

- **ABBC** - Associação Brasileira de Bancos
- **BCB** - Banco Central do Brasil (autoridade reguladora)
- **CIP** - Câmara Interbancária de Pagamentos
- **CNPJ** - Cadastro Nacional de Pessoa Juridica
- **COMPE** - Sistema de Compensação de Cheques e Outros Papéis
- **CPF** - Cadastro Pessoa Física
- **FEBRABAN** - Federação Brasileira de Bancos
- **ISPB** - Identificação do SPB
- **PIX** - Pagamentos Instantâneos
- **RSFN** - Rede do SFN
- **SFN** - Sistema Financeiro Nacional
- **SPB** - Sistema de Pagamentos Brasileiro
- **STR** - Sistema de Transferência de Reserva

---

## TODO ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted)

- Obter CNPJ dos bancos: [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4).
- Obter sites dos bancos: [Issue #9](https://github.com/guibranco/BancosBrasileiros/issues/9).
- Obter código ISPB: [Issue #31](https://github.com/guibranco/BancosBrasileiros/issues/31).

---

## Changelog

- 2020-04-23: [Issue #32](https://github.com/guibranco/BancosBrasileiros/issues/32) - Corrigido dados do Banco Órama em bancos.sql - [@VGsss](https://github.com/VGsss)
- 2020-04-23: [Issue #33](https://github.com/guibranco/BancosBrasileiros/issues/33) - Corrigido dados do RaboBank - [@rpenha](https://github.com/rpenha)
- 2020-04-17: Atualização do readme.md e do readme.en.md, publicação do github.io pages
- 2020-04-15: [Issue #30](https://github.com/guibranco/BancosBrasileiros/issues/30) - Adicionado package.json para listar no NPM - [@RauppRafael](https://github.com/RauppRafael)
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
- 2019-05-21: [Issue #5](https://github.com/guibranco/BancosBrasileiros/issues/5) e [Issue #6](https://github.com/guibranco/BancosBrasileiros/issues/6) - Adicionado versões **CSV** e **XML** dos dados - [@guibranco](https://github.com/guibranco)
- 2019-05-21: [Issue #8](https://github.com/guibranco/BancosBrasileiros/issues/8) - Adicionado Banco BS2 - [@guibranco](https://github.com/guibranco)
- 2019-04-03: [PR #7](https://github.com/guibranco/BancosBrasileiros/pull/7) - Corrigido nome do Bradesco em bancos.json - [@jesobreira](https://github.com/jesobreira)
- 2019-01-15: [Issue #3](https://github.com/guibranco/BancosBrasileiros/issues/3) - Adicionado Banco Inter em bancos.sql - [@diegolourenco](https://github.com/DiegoLourenco)
- 2019-01-15: Renomeado arquivos para **bancos.formato** - [@guibranco](https://github.com/guibranco)
- 2018-01-28: Adicionado formato **JSON** - [@raphaelcunha](https://github.com/raphaelcunha)
- 2018-01-28: Adicionado XP Investimentos e NuBank - [@raphaelcunha](https://github.com/raphaelcunha)
- 2017-10-26: Adicionado 248 bancos no formato **T-SQL** - [@guibranco](https://github.com/guibranco)
