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
        /// Generates the missing document.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <returns>Seeder.</returns>
        public Seeder GenerateMissingDocument(IEnumerable<Bank> normalized)
        {
            var existing = 0;
            var missing = 0;

            foreach (var bank in normalized)
            {
                if (bank.Document != null && bank.Document.Length == 18)
                {
                    existing++;
                    continue;
                }

                bank.Document = bank.IspbString;
                missing++;
            }

            Console.WriteLine($"\r\nGenerate document | Existing: {existing} | Missing: {missing}\r\n");

            return this;
        }

        /// <summary>
        /// Seeds the site.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="sites">The sites.</param>
        public Seeder SeedSite(IList<Bank> normalized, IEnumerable<Bank> sites)
        {
            var found = 0;
            var notFound = 0;

            foreach (var site in sites)
            {
                var bank = normalized.SingleOrDefault(b => b.Compe == site.Compe);

                if (bank == null)
                    bank = normalized.SingleOrDefault(b =>
                        b.LongName.RemoveDiacritics().Equals(site.LongName.RemoveDiacritics(),
                            StringComparison.InvariantCultureIgnoreCase) ||
                        b.ShortName.RemoveDiacritics().Equals(site.LongName.RemoveDiacritics(),
                            StringComparison.InvariantCultureIgnoreCase));
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
                else if (!string.IsNullOrWhiteSpace(bank.Url) && !bank.Url.Equals(site.Url, StringComparison.InvariantCultureIgnoreCase))
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

            return this;
        }

        /// <summary>
        /// Seeds the document.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="documents">The documents.</param>
        public Seeder SeedDocument(IList<Bank> normalized, IEnumerable<Bank> documents)
        {
            var found = 0;
            var notFound = 0;

            foreach (var document in documents)
            {
                var bank = normalized.SingleOrDefault(b =>
                    b.LongName.RemoveDiacritics().Equals(document.LongName.RemoveDiacritics(),
                        StringComparison.InvariantCultureIgnoreCase) ||
                    b.ShortName.RemoveDiacritics().Equals(document.LongName.RemoveDiacritics(),
                        StringComparison.InvariantCultureIgnoreCase));
                if (bank == null)
                {
                    Console.WriteLine($"Documento | Banco não encontrado: {document.LongName}");
                    notFound++;
                    continue;
                }

                if ((string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18) && !string.IsNullOrWhiteSpace(document.Document))
                    bank.Document = document.Document;
                else if (string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18)
                    Console.WriteLine($"Documento | Documento inválido {document.Compe} | {bank.Document} | {document.Document}");

                if (string.IsNullOrWhiteSpace(bank.Type) && !string.IsNullOrWhiteSpace(document.Type))
                    bank.Type = document.Type;
                else
                    Console.WriteLine($"Documento | Tipo inválido {document.Compe} | {bank.Type} <-> {document.Type}");

                if (string.IsNullOrWhiteSpace(bank.Url) && !string.IsNullOrWhiteSpace(document.Url))
                    bank.Url = document.Url.ToLower();

                found++;
            }

            Console.WriteLine($"\r\nDocumento | Found: {found} | Not found: {notFound}\r\n");

            return this;
        }

        /// <summary>
        /// Seeds the SLC.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="slcs">The SLCS.</param>
        public Seeder SeedSlc(IList<Bank> normalized, IEnumerable<Bank> slcs)
        {
            var found = 0;
            var notFound = 0;

            foreach (var slc in slcs)
            {
                var bank = normalized.SingleOrDefault(b => b.Document != null && b.Document.Equals(slc.Document));

                if (bank == null)
                {
                    bank = normalized.SingleOrDefault(b =>
                        b.LongName.RemoveDiacritics().Equals(slc.LongName.RemoveDiacritics(),
                            StringComparison.InvariantCultureIgnoreCase) ||
                        b.ShortName.RemoveDiacritics().Equals(slc.LongName.RemoveDiacritics(),
                            StringComparison.InvariantCultureIgnoreCase));
                }

                if (bank == null)
                {
                    var ispb = int.Parse(slc.Document.RemoveNonNumeric()[..8]);

                    if (ispb == 0 && !slc.LongName.Equals("Banco do Brasil", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine($"SLC | ISPB zerado: {slc.LongName} | {slc.Document.Trim()}");
                        continue;
                    }

                    bank = normalized.SingleOrDefault(b => b.Ispb.Equals(ispb) && b.LongName.Contains(slc.LongName, StringComparison.InvariantCultureIgnoreCase));
                }

                if (bank == null)
                {
                    Console.WriteLine($"SLC | Banco não encontrado: {slc.LongName} | {slc.Document.Trim()}");
                    notFound++;
                    continue;
                }

                if ((string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18) && !string.IsNullOrWhiteSpace(slc.Document))
                    bank.Document = slc.Document;
                else if (string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18)
                    Console.WriteLine($"SLC | Documento inválido {slc.Compe} | {bank.Document} | {slc.Document}");

                if (string.IsNullOrEmpty(bank.LongName) || !bank.LongName.Equals(slc.LongName))
                    bank.ShortName = slc.LongName;

                if (string.IsNullOrWhiteSpace(bank.ShortName))
                    bank.ShortName = bank.LongName;

                found++;

            }

            Console.WriteLine($"\r\nSLC | Found: {found} | Not found: {notFound}\r\n");

            return this;
        }

        /// <summary>
        /// Seeds the pix.
        /// </summary>
        /// <param name="normalized">The normalized.</param>
        /// <param name="pixs">The pixs.</param>
        /// <returns>Seeder.</returns>
        public Seeder SeedPix(IList<Bank> normalized, IEnumerable<Bank> pixs)
        {
            var found = 0;
            var notFound = 0;


            foreach (var pix in pixs)
            {
                var bank = normalized.SingleOrDefault(b =>
                    b.LongName.RemoveDiacritics().Equals(pix.LongName.RemoveDiacritics(),
                        StringComparison.InvariantCultureIgnoreCase) ||
                    b.ShortName.RemoveDiacritics().Equals(pix.LongName.RemoveDiacritics(),
                        StringComparison.InvariantCultureIgnoreCase));

                if (bank == null)
                    bank = normalized.SingleOrDefault(b => b.Ispb.Equals(pix.Ispb));

                if (bank == null)
                {
                    Console.WriteLine($"PIX | Participante não encontrado: {pix.LongName}");
                    notFound++;
                    continue;
                }

                bank.PixType = pix.PixType;
                bank.DatePixStarted = pix.DatePixStarted;

                found++;
            }

            Console.WriteLine($"\r\nPIX | Found: {found} | Not found: {notFound}\r\n");

            return this;
        }
    }
}
