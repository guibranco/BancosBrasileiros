// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 19/05/2020
// ***********************************************************************
// <copyright file="Seeder.cs" company="BancosBrasileiros.MergeTool">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using BancosBrasileiros.MergeTool.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancosBrasileiros.MergeTool.Helpers
{
    /// <summary>
    /// Class Seeder.
    /// </summary>
    internal class Seeder
    {
        /// <summary>
        /// Seeds the document.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="documents">The documents.</param>
        public void SeedDocument(IList<Bank> normalized, IList<Bank> documents)
        {
            foreach (var document in documents)
            {
                var bank = normalized.SingleOrDefault(b =>
                                                          b.FiscalName.Equals(document.FiscalName, StringComparison.InvariantCultureIgnoreCase) ||
                                                          b.FantasyName.Equals(document.FiscalName, StringComparison.InvariantCultureIgnoreCase));
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
                    Console.WriteLine($"CNPJ |Tipo inválido {document.Compe} | {bank.Type} <-> {document.Type}");

                if (string.IsNullOrWhiteSpace(bank.Url) && !string.IsNullOrWhiteSpace(document.Url))
                    bank.Url = document.Url.ToLower();
            }
        }

        /// <summary>
        /// Seeds the ispb.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="codes">The codes.</param>
        public void SeedIspb(IList<Bank> normalized, IList<Bank> codes)
        {
            foreach (var code in codes)
            {

                var bank = normalized.SingleOrDefault(b => b.Compe == code.Compe && code.Compe > 0);

                if (bank == null)
                    bank = normalized.SingleOrDefault(b =>
                                                             b.FiscalName.Equals(code.FiscalName, StringComparison.InvariantCultureIgnoreCase) ||
                                                             b.FantasyName.Equals(code.FiscalName, StringComparison.InvariantCultureIgnoreCase));
                if (bank == null)
                    bank = normalized.SingleOrDefault(b =>
                                                          b.FiscalName.Equals(code.FantasyName, StringComparison.InvariantCultureIgnoreCase) ||
                                                          b.FantasyName.Equals(code.FantasyName, StringComparison.InvariantCultureIgnoreCase));

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

                if (!bank.FiscalName.Equals(code.FiscalName, StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine(
                        $"ISPB | Razão social inválida {code.Compe} | {bank.FiscalName} <-> {code.FiscalName}");

                if (!bank.FantasyName.Equals(code.FantasyName, StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine(
                        $"ISPB | Nome fantasia inválido {code.Compe} | {bank.FantasyName} <-> {code.FantasyName}");

                if (string.IsNullOrWhiteSpace(bank.DateOperationStarted) &&
                    !string.IsNullOrWhiteSpace(code.DateOperationStarted))
                    bank.DateOperationStarted = code.DateOperationStarted;
            }
        }

        /// <summary>
        /// Seeds the site.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="sites">The sites.</param>
        public void SeedSite(IList<Bank> normalized, IList<Bank> sites)
        {
            foreach (var site in sites)
            {
                var bank = normalized.SingleOrDefault(b => b.Compe == site.Compe);

                if (bank == null)
                    bank = normalized.SingleOrDefault(b =>
                                                          b.FiscalName.Equals(site.FiscalName, StringComparison.InvariantCultureIgnoreCase) ||
                                                          b.FantasyName.Equals(site.FiscalName, StringComparison.InvariantCultureIgnoreCase));
                if (bank == null)
                {
                    Console.WriteLine($"Site | Banco não encontrado: {site.Compe}");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(bank.Url) && !string.IsNullOrWhiteSpace(site.Url))
                    bank.Url = site.Url.ToLower();
                else if (!string.IsNullOrWhiteSpace(bank.Url) && !bank.Url.Equals(site.Url, StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine($"Site | Url divergente {site.Compe} | {bank.Url} <-> {site.Url}");

                if (!bank.FiscalName.Equals(site.FiscalName, StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine($"Site | Razão social inválida {site.Compe} | {bank.FiscalName} <-> {site.FiscalName}");
            }
        }
    }
}
