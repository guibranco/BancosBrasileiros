# Bancos Brasileiros
Listagem de bancos comerciais brasileiros

A listagem contém 250 bancos cadastrados, nos seguintes formatos e informações disponíveis:

 - **T-SQL**
    - Código do banco - FEBRABAN / BCB
    - Razão Social
    - CNPJ (**TODO**)
 - **JSON**
    - Código sequencial
    - Código do banco - FEBRABAN / BCB
    - Razão Social
    - Data de cadastro no schema
    - Data de alteração no schema
    - Data de remoção no schema
    - Flag indicativa se está deletado ou não

---
### TODO

- Adicionar os formatos: **CSV** e **XML**

---
### Changelog

- 2019-04-03 - [PR #7](https://github.com/guibranco/BancosBrasileiros/pull/7) - Corrigido nome do Bradesco no arquivo bancos.json) - [@jesobreira](https://github.com/jesobreira)
- 2019-01-15: [Issue #3](https://github.com/guibranco/BancosBrasileiros/issues/3) - Adicionado banco Inter (77) ao arquivo bancos.sql - [@diegolourenco](https://github.com/DiegoLourenco)
- 2019-01-15: Renomeado arquivos para bancos.extensão - [@guibranco](https://github.com/guibranco)
- 2018-01-28: Adicionado 250 bancos no formato **JSON** - [@raphaelcunha](https://github.com/raphaelcunha)
- 2018-01-28: Adicionado 2 bancos (XP Investimentos & NuBank), totalizando 250 bancos - [@raphaelcunha](https://github.com/raphaelcunha)
- 2017-10-26: Adicionado 248 bancos no formato **T-SQL** - [@guibranco](https://github.com/guibranco)
