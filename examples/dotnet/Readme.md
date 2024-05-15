# Bancos Brasileiros

Brazilian commercial banks list

### Available data

Each of the Collection has the following information (schema):

| Column | Description | Observations |
|:------:|:-----------:|:------------:|
| COMPE | Code - COMPE | 3 digits |
| ISPB | Code - ISPB | 8 digits |
| Document | Document - CNPJ | 14 numbers - 18 digits (formatted) |
| LongName | Long name | According to BACEN - STR |
| ShortName | Short name | According to BACEN - STR|
| Network | Network | RSFN, Internet, null |
| Type | Type | commercial, multiple, savings, null |
| PixType | Type of PIX/SPI participant | DRCT - Directly, INDR - Indirectly, null |
| Charge | If does charge operations | true, false, null |
| CreditDocument | If does DOC/TED operations | true, false, null |
| LegalCheque | If it belongs to the "Cheque Legal"  | true, false |
| Detecta Flow | If it belongs to the "Detecta Flow" | true, false |
| PCR | If it belongs to the "PCR" | true, false |
| PCRP | If it belongs to the "PCRP" | true, false |
| SalaryPortability | If does/accept salary portability | "Banco folha e Destinatário" - both operations, "Destinatário" - only receive, null |
| Products | List of products offered | In Portuguese only |
| Url | Website | - |
| DateOperationStarted | Commercial operation start date | - |
| DatePixStarted | PIX operation start date | Only for those PSP of SPI |
| DateRegistered | Registration date on schema | - |
| DateUpdated | Change date on schema | - |

---
