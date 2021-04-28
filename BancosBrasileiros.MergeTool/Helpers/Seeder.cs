// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 04-27-2021
// ***********************************************************************
// <copyright file="Seeder.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Helpers
{
    using Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class Seeder.
    /// </summary>
    internal class Seeder
    {
        /// <summary>
        /// Seeds the site.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="sites">The sites.</param>
        public void SeedSite(IList<Bank> normalized, IEnumerable<Bank> sites)
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
                    Console.WriteLine($"Adding bank by site list | {site.Compe} | {site.FiscalName}");
                    if (string.IsNullOrWhiteSpace(site.FantasyName))
                        site.FantasyName = site.FiscalName;
                    site.DateRegistered ??= DateTimeOffset.Now;
                    normalized.Add(site);
                    bank = site;
                }

                if (string.IsNullOrWhiteSpace(bank.Url) && !string.IsNullOrWhiteSpace(site.Url))
                    bank.Url = site.Url.ToLower();
                else if (!string.IsNullOrWhiteSpace(bank.Url) &&
                    !bank.Url.Equals(site.Url, StringComparison.InvariantCultureIgnoreCase))
                    bank.Url = site.Url;

                if (bank.FiscalName.Equals(site.FiscalName, StringComparison.InvariantCultureIgnoreCase))
                    continue;

                bank.FiscalName = site.FiscalName;
            }
        }

        /// <summary>
        /// Seeds the ispb.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="codes">The codes.</param>
        public void SeedIspb(IList<Bank> normalized, IEnumerable<Bank> codes)
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
                    Console.WriteLine($"ISPB | Banco não encontrado: {code.Compe} | {code.FiscalName} | {code.FantasyName}");
                    continue;
                }

                if (bank.Ispb == 0 || bank.Ispb != code.Ispb)
                    bank.Ispb = code.Ispb;

                if (string.IsNullOrWhiteSpace(bank.Network) && !string.IsNullOrWhiteSpace(code.Network))
                    bank.Network = code.Network;

                if (!bank.FiscalName.Equals(code.FiscalName, StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine($"ISPB | Razão social inválida {code.Compe} | {bank.FiscalName} <-> {code.FiscalName}");

                if (!bank.FantasyName.Equals(code.FantasyName, StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine($"ISPB | Nome fantasia inválido {code.Compe} | {bank.FantasyName} <-> {code.FantasyName}");

                if (string.IsNullOrWhiteSpace(bank.DateOperationStarted) &&
                    !string.IsNullOrWhiteSpace(code.DateOperationStarted))
                    bank.DateOperationStarted = code.DateOperationStarted;
            }
        }


        /// <summary>
        /// Seeds the document.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="documents">The documents.</param>
        public void SeedDocument(IList<Bank> normalized, IEnumerable<Bank> documents)
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
                else if (string.IsNullOrWhiteSpace(bank.Document))
                    Console.WriteLine($"CNPJ | Documento inválido {document.Compe} | {bank.Document} | {document.Document}");

                if (string.IsNullOrWhiteSpace(bank.Type) && !string.IsNullOrWhiteSpace(document.Type))
                    bank.Type = document.Type;
                else
                    Console.WriteLine($"CNPJ | Tipo inválido {document.Compe} | {bank.Type} <-> {document.Type}");

                if (string.IsNullOrWhiteSpace(bank.Url) && !string.IsNullOrWhiteSpace(document.Url))
                    bank.Url = document.Url.ToLower();
            }
        }

        /// <summary>
        /// Seeds the SLC.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="slcs">The SLCS.</param>
        public void SeedSlc(IList<Bank> normalized, IEnumerable<Bank> slcs)
        {
            foreach (var slc in slcs)
            {
                var bank = normalized.SingleOrDefault(b =>
                    b.FiscalName.EndsWith(slc.FiscalName, StringComparison.InvariantCultureIgnoreCase) ||
                    b.FantasyName.Equals(slc.FiscalName, StringComparison.InvariantCultureIgnoreCase));

                if (bank == null)
                {
                    var ispb = int.Parse(slc.Document.Replace(".", "").Replace("/", "").Substring(0, 8));
                    if (ispb == 0)
                    {
                        Console.WriteLine($"SLC | Banco com ISPB zerado: {slc.FiscalName} | {slc.Document.Trim()}");
                        continue;
                    }
                    bank = normalized.SingleOrDefault(b => b.Ispb.Equals(ispb));
                }

                if (bank == null)
                {
                    Console.WriteLine($"SLC | Banco não encontrado: {slc.FiscalName} | {slc.Document.Trim()}");
                    continue;
                }

                bank.Document = slc.Document;

                if (string.IsNullOrEmpty(bank.FiscalName) || !bank.FiscalName.Equals(slc.FiscalName))
                    bank.FantasyName = slc.FiscalName;

                if (string.IsNullOrWhiteSpace(bank.FantasyName))
                    bank.FantasyName = bank.FiscalName;

            }
        }
    }
}
