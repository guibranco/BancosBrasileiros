# Bancos Brasileiros
Listagem de bancos comerciais brasileiros

![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)
![GitHub](https://img.shields.io/github/license/guibranco/BancosBrasileiros)

***For a english version of README.md, please [follow me](https://github.com/guibranco/BancosBrasileiros/blob/master/README.en.md)***

Para aqueles que não estão familiarizados com entidades brasileiras:

- **BCB** - Banco Central do Brasil
- **FEBRABAN** - Federação Brasileira de Bancos (autoridade reguladora)
- **CNPJ** - Cadastro Nacional de Pessoa Juridica

Esta lista contém mais de 255 bancos cadastrados, nos seguintes formatos e informações disponíveis:

- **T-SQL**
  - Código do banco - FEBRABAN / BCB
  - Razão Social
  - Documento (CNPJ) (**TODO**) [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4)
  - Data de alteração no schema
  - Flag indicativa se está deletado ou não
- **JSON**
  - Código do banco - FEBRABAN / BCB
  - Razão Social / Nome fantasia
  - Documento (CNPJ) (**TODO**) [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4)
  - Data de cadastro no schema
  - Data de alteração no schema
  - Data de remoção no schema
  - Flag indicativa se está deletado ou não
- **CSV**
  - Código do banco - FEBRABAN / BCB
  - Razão Social / Nome fantasia
  - Documento (CNPJ) (**TODO**) [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4)
  - Data de cadastro no schema
  - Data de alteração no schema
  - Data de remoção no schema
  - Flag indicativa se está deletado ou não
- **XML**
  - Código do banco - FEBRABAN / BCB
  - Razão Social / Nome fantasia
  - Documento (CNPJ) (**TODO**) [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4)
  - Data de cadastro no schema
  - Data de alteração no schema
  - Data de remoção no schema
  - Flag indicativa se está deletado ou não

---

## TODO

- Obter CNPJ dos bancos [Issue #4](https://github.com/guibranco/BancosBrasileiros/issues/4)
- Obter sites dos bancos [Issue #9](https://github.com/guibranco/BancosBrasileiros/issues/9)

---

## Changelog

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
