// ***********************************************************************
// Assembly         : MergeBancosBrasileiros
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 19/05/2020
// ***********************************************************************
// <copyright file="Seeder.cs" company="MergeBancosBrasileiros">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

namespace BancosBrasileiros.MergeTool
{
    /// <summary>
    /// Class Seeder.
    /// </summary>
    internal class Seeder
    {
        /// <summary>
        /// Seeds the data.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="documents">The documents.</param>
        /// <param name="codes">The codes.</param>
        /// <param name="sites">The sites.</param>
        public void Seed(
            IList<Bank> normalized,
            IList<Bank> documents,
            IList<Bank> codes,
            IList<Bank> sites)
        {
            foreach (var document in documents)
            {
                var bank = normalized.SingleOrDefault(b =>
                                                          b.FiscalName.Equals(document.FiscalName) ||
                                                          b.FantasyName.Equals(document.FiscalName));
                if (bank == null)
                {
                    Console.WriteLine($"CNPJ | Banco não encontrado: {document.FiscalName}");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(bank.Document) && !string.IsNullOrWhiteSpace(document.Document))
                    bank.Document = document.Document;
                else
                    Console.WriteLine($"CNPJ | Documento inválido {document.Compe}");

                if (string.IsNullOrWhiteSpace(bank.Type) && !string.IsNullOrWhiteSpace(document.Type))
                    bank.Type = document.Type;
                else
                    Console.WriteLine($"CNPJ |Tipo inválido {document.Compe}");

                if (string.IsNullOrWhiteSpace(bank.Url) && !string.IsNullOrWhiteSpace(document.Url))
                    bank.Url = document.Url;
            }

            foreach (var code in codes)
            {
                var bank = normalized.SingleOrDefault(b =>
                                                          b.FiscalName.Equals(code.FiscalName) ||
                                                          b.FantasyName.Equals(code.FiscalName));
                if (bank == null)
                    bank = normalized.SingleOrDefault(b =>
                                                          b.FiscalName.Equals(code.FantasyName) ||
                                                          b.FantasyName.Equals(code.FantasyName));

                if (bank == null)
                    bank = normalized.SingleOrDefault(b => b.Ispb == code.Ispb);

                if (bank == null)
                {
                    Console.WriteLine($"ISPB | Banco não encontrado: {code.Compe}");
                    continue;
                }

                if (bank.Ispb == 0 || bank.Ispb != code.Ispb)
                    bank.Ispb = code.Ispb;

                if (string.IsNullOrWhiteSpace(bank.Network) && !string.IsNullOrWhiteSpace(code.Network))
                    bank.Network = code.Network;

                if (!bank.FiscalName.Equals(code.FiscalName))
                    Console.WriteLine($"ISPB | Razão social inválida {code.Compe}");

                if (!bank.FantasyName.Equals(code.FantasyName))
                    Console.WriteLine($"ISPB | Nome fantasia inválido {code.Compe}");

                if (string.IsNullOrWhiteSpace(bank.DateOperationStarted) &&
                    !string.IsNullOrWhiteSpace(code.DateOperationStarted))
                    bank.DateOperationStarted = code.DateOperationStarted;
            }

            foreach (var site in sites)
            {
                var bank = normalized.SingleOrDefault(b => b.Compe == site.Compe);

                if (bank == null)
                    bank = normalized.SingleOrDefault(b =>
                                                          b.FiscalName.Equals(site.FiscalName) ||
                                                          b.FantasyName.Equals(site.FiscalName));
                if (bank == null)
                {
                    Console.WriteLine($"Site | Banco não encontrado: {site.Compe}");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(bank.Url) && !string.IsNullOrWhiteSpace(site.Url))
                    bank.Url = site.Url;
                else if (!string.IsNullOrWhiteSpace(bank.Url) && !bank.Url.Equals(site.Url))
                    Console.WriteLine($"Site | Url divergente {site.Compe}");

                if (!bank.FiscalName.Equals(site.FiscalName))
                    Console.WriteLine($"Site | Razão social inválida {site.Compe}");
            }


        }
    }
}
