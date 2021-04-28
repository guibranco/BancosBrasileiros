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
    using CrispyWaffle.Extensions;
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
            var found = 0;
            var notFound = 0;

            foreach (var site in sites)
            {
                var bank = normalized.SingleOrDefault(b => b.Compe == site.Compe);

                if (bank == null)
                    bank = normalized.SingleOrDefault(b =>
                                                          b.LongName.Equals(site.LongName, StringComparison.InvariantCultureIgnoreCase) ||
                                                          b.ShortName.Equals(site.LongName, StringComparison.InvariantCultureIgnoreCase));
                if (bank == null)
                {
                    Console.WriteLine($"Adding bank by site list | {site.Compe} | {site.LongName}");
                    if (string.IsNullOrWhiteSpace(site.ShortName))
                        site.ShortName = site.LongName;
                    site.DateRegistered ??= DateTimeOffset.Now;
                    normalized.Add(site);
                    bank = site;
                }

                if (string.IsNullOrWhiteSpace(bank.Url) && !string.IsNullOrWhiteSpace(site.Url))
                    bank.Url = site.Url.ToLower();
                else if (!string.IsNullOrWhiteSpace(bank.Url) &&
                    !bank.Url.Equals(site.Url, StringComparison.InvariantCultureIgnoreCase))
                    bank.Url = site.Url;

                if (bank.LongName.Equals(site.LongName, StringComparison.InvariantCultureIgnoreCase))
                {
                    notFound++;
                    continue;
                }

                bank.LongName = site.LongName;

                found++;
            }

            Console.WriteLine($"\r\nSite | Found: {found} | Not found: {notFound}\r\n");
        }

        /// <summary>
        /// Seeds the document.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="documents">The documents.</param>
        public void SeedDocument(IList<Bank> normalized, IEnumerable<Bank> documents)
        {
            var found = 0;
            var notFound = 0;

            foreach (var document in documents)
            {
                var bank = normalized.SingleOrDefault(b =>
                                                          b.LongName.Equals(document.LongName, StringComparison.InvariantCultureIgnoreCase) ||
                                                          b.ShortName.Equals(document.LongName, StringComparison.InvariantCultureIgnoreCase));
                if (bank == null)
                {
                    Console.WriteLine($"CNPJ | Banco não encontrado: {document.LongName}");
                    notFound++;
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

                found++;
            }

            Console.WriteLine($"\r\nDocument | Found: {found} | Not found: {notFound}\r\n");
        }

        /// <summary>
        /// Seeds the SLC.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="slcs">The SLCS.</param>
        public void SeedSlc(IList<Bank> normalized, IEnumerable<Bank> slcs)
        {
            var found = 0;
            var notFound = 0;

            foreach (var slc in slcs)
            {
                var bank = normalized.SingleOrDefault(b =>
                    b.LongName.EndsWith(slc.LongName, StringComparison.InvariantCultureIgnoreCase) ||
                    b.ShortName.Equals(slc.LongName, StringComparison.InvariantCultureIgnoreCase));

                if (bank == null)
                {
                    var ispb = int.Parse(slc.Document.RemoveNonNumeric().Substring(0, 8));
                    if (ispb == 0)
                    {
                        Console.WriteLine($"SLC | Banco com ISPB zerado: {slc.LongName} | {slc.Document.Trim()}");
                        continue;
                    }
                    bank = normalized.SingleOrDefault(b => b.Ispb.Equals(ispb));
                }

                if (bank == null)
                {
                    Console.WriteLine($"SLC | Banco não encontrado: {slc.LongName} | {slc.Document.Trim()}");
                    notFound++;
                    continue;
                }

                bank.Document = slc.Document;

                if (string.IsNullOrEmpty(bank.LongName) || !bank.LongName.Equals(slc.LongName))
                    bank.ShortName = slc.LongName;

                if (string.IsNullOrWhiteSpace(bank.ShortName))
                    bank.ShortName = bank.LongName;

                found++;

            }

            Console.WriteLine($"\r\nSLC | Found: {found} | Not found: {notFound}\r\n");
        }
    }
}
