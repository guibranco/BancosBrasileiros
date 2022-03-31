# Bancos Brasileiros

Brazilian commercial banks list

[![Build status](https://ci.appveyor.com/api/projects/status/f9sx7ux82epp8bd6?svg=true)](https://ci.appveyor.com/project/guibranco/bancosbrasileiros)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)
[![GitHub license](https://img.shields.io/github/license/guibranco/BancosBrasileiros)](https://wakatime.com/badge/github/guibranco/BancosBrasileiros)

---

## Available data

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
| Url | Website | - |
| DateOperationStarted | Commercial operation start date | - |
| DatePixStarted | PIX operation start date | Only for those PSP of SPI |
| DateRegistered | Registration date on schema | - |
| DateUpdated | Change date on schema | - |

---

## How to use

```cs
class Program
{
    static void Main(string[] _)
    {
        var fileContent = System.IO.File.ReadAllText("banks.json");
        var banks = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<BancosBrasileiros.Bank>>(fileContent);

        System.Console.WriteLine($"Banks: {banks.Count}");
        System.Console.ReadKey();
    }
}
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

[Changelog](https://guibranco.github.io/BancosBrasileiros/CHANGELOG.html)
