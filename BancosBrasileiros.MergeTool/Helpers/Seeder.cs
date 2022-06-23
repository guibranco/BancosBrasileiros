// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-01-2022
// ***********************************************************************
// <copyright file="Seeder.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Helpers
{
    using System;
    using CrispyWaffle.Extensions;
    using Dto;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class Seeder.
    /// </summary>
    internal class Seeder
    {
        /// <summary>
        /// The source
        /// </summary>
        private readonly IList<Bank> _source;

        /// <summary>
        /// Initializes a new instance of the <see cref="Seeder" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <exception cref="System.ArgumentNullException">source</exception>
        public Seeder(IList<Bank> source) => _source = source ?? throw new ArgumentNullException(nameof(source));

        /// <summary>
        /// Generates the missing document.
        /// </summary>
        /// <returns>Seeder.</returns>
        public Seeder GenerateMissingDocument()
        {
            var existing = 0;
            var missing = 0;

            foreach (var bank in _source)
            {
                if (bank.Document is { Length: 18 })
                {
                    existing++;
                    continue;
                }

                bank.Document = bank.IspbString;
                bank.DateUpdated = DateTimeOffset.UtcNow;
                missing++;
            }

            Logger.Log($"\r\nGenerate document | Existing: {existing} | Missing: {missing}\r\n", ConsoleColor.DarkYellow);
            return this;
        }

        /// <summary>
        /// Seeds the string.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Seeder.</returns>
        public Seeder SeedStr(IEnumerable<Bank> items)
        {
            var updated = 0;
            var nameFixed = 0;

            Logger.Log("STR\r\n", ConsoleColor.DarkYellow);

            foreach (var str in items)
            {
                var bank = _source.SingleOrDefault(b => b.Compe == str.Compe);

                if (bank == null)
                {
                    Logger.Log($"Adding bank by STR List | {str.Compe} | {str.LongName}", ConsoleColor.DarkGreen);

                    if (str.Document is not { Length: 18 })
                        str.Document = str.IspbString;

                    _source.Add(str);
                    bank = str;
                }

                if (bank.LongName.RemoveDiacritics().Equals(str.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase) &&
                    bank.ShortName.RemoveDiacritics().Equals(str.ShortName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase))
                {
                    Logger.Log($"STR | Bank updated: {str.LongName}", ConsoleColor.DarkGreen);
                    updated++;
                    continue;
                }

                Logger.Log($"STR | Bank with name different: {bank.LongName} <-> {str.LongName} | {bank.ShortName} <-> {str.ShortName}", ConsoleColor.DarkYellow);
                bank.LongName = str.LongName;
                bank.ShortName = str.ShortName;
                bank.DateUpdated = DateTimeOffset.UtcNow;
                nameFixed++;
            }

            Logger.Log($"\r\nSTR | Updated: {updated} | Fixed: {nameFixed}\r\n", ConsoleColor.DarkYellow);
            return this;
        }

        /// <summary>
        /// Seeds the sitraf.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Seeder.</returns>
        public Seeder SeedSitraf(IEnumerable<Bank> items)
        {
            var updated = 0;
            var nameFixed = 0;
            var notFound = 0;

            Logger.Log("SITRAF\r\n", ConsoleColor.DarkYellow);

            foreach (var sitraf in items)
            {
                var bank = _source.SingleOrDefault(b => b.Compe == sitraf.Compe);

                if (bank == null)
                {
                    Logger.Log($"Adding bank by SITRAF List | {sitraf.Compe} | {sitraf.LongName}", ConsoleColor.DarkGreen);

                    if (sitraf.Document is not { Length: 18 })
                        sitraf.Document = sitraf.IspbString;

                    _source.Add(sitraf);
                    bank = sitraf;
                }


                if (bank.LongName.RemoveDiacritics().Equals(sitraf.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase))
                {
                    Logger.Log($"SITRAF | Bank updated: {sitraf.LongName}", ConsoleColor.DarkGreen);
                    updated++;
                    continue;
                }

                if (bank.LongName.RemoveDiacritics().Equals(sitraf.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase))
                {
                    Logger.Log($"SITRAF | Bank not found: {sitraf.LongName}", ConsoleColor.DarkRed);

                    notFound++;
                    continue;
                }

                //Logger.Log($"SITRAF | Bank with name different: {bank.LongName} <-> {sitraf.LongName}", ConsoleColor.DarkYellow);
                //bank.LongName = sitraf.LongName;
                //bank.DateUpdated = DateTimeOffset.UtcNow;
                //nameFixed++;
            }

            Logger.Log($"\r\nSTR | Updated: {updated} | Fixed: {nameFixed} | Not found: {notFound}\r\n", ConsoleColor.DarkYellow);

            return this;
        }

        /// <summary>
        /// Seeds the SLC.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Seeder.</returns>
        public Seeder SeedSlc(IEnumerable<Bank> items)
        {
            var found = 0;
            var notFound = 0;

            Logger.Log("SLC\r\n", ConsoleColor.DarkYellow);

            foreach (var slc in items)
            {
                var bank = _source.SingleOrDefault(b => b.Document != null && b.Document.Equals(slc.Document));

                if (bank == null)
                {
                    bank = _source.SingleOrDefault(b =>
                        b.LongName.RemoveDiacritics().Equals(slc.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase) ||
                        (b.ShortName != null && b.ShortName.RemoveDiacritics().Equals(slc.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase)));
                }

                if (bank == null)
                {
                    var ispb = int.Parse(slc.Document.RemoveNonNumeric()[..8]);

                    if (ispb == 0 && !slc.LongName.Equals("Banco do Brasil", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Logger.Log($"SLC | ISPB nulled: {slc.LongName} | {slc.Document.Trim()}", ConsoleColor.DarkRed);
                        continue;
                    }

                    bank = _source.SingleOrDefault(b => b.Ispb.Equals(ispb) && b.LongName.Contains(slc.LongName, StringComparison.InvariantCultureIgnoreCase));
                }

                if (bank == null)
                {
                    Logger.Log($"SLC | Bank not found: {slc.LongName} | {slc.Document.Trim()}", ConsoleColor.DarkRed);

                    notFound++;
                    continue;
                }

                if ((string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18) &&
                    !string.IsNullOrWhiteSpace(slc.Document))
                {
                    bank.Document = slc.Document;
                    bank.DateUpdated = DateTimeOffset.UtcNow;
                }

                else if (string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18)
                {
                    Logger.Log($"SLC | Invalid document {slc.Compe} | {bank.Document} | {slc.Document}", ConsoleColor.DarkRed);
                }

                if (string.IsNullOrWhiteSpace(bank.ShortName))
                {
                    bank.ShortName = slc.LongName;
                    bank.DateUpdated = DateTimeOffset.UtcNow;
                }

                found++;
            }

            Logger.Log($"\r\nSLC | Found: {found} | Not found: {notFound}\r\n", ConsoleColor.DarkYellow);
            return this;
        }

        /// <summary>
        /// Seeds the SPI.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Seeder.</returns>
        public Seeder SeedSpi(IEnumerable<Bank> items)
        {
            var found = 0;
            var upToDate = 0;
            var notFound = 0;

            Logger.Log("SPI\r\n", ConsoleColor.DarkYellow);

            foreach (var spi in items)
            {
                var bank = _source.SingleOrDefault(b =>
                    b.LongName.RemoveDiacritics().Equals(spi.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase) ||
                    (b.ShortName != null && b.ShortName.RemoveDiacritics().Equals(spi.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase)));

                if (bank == null)
                    bank = _source.SingleOrDefault(b => b.Ispb.Equals(spi.Ispb));

                if (bank == null)
                {
                    Logger.Log($"SPI | PSP not found: {spi.LongName}", ConsoleColor.DarkRed);

                    notFound++;
                    continue;
                }

                if (bank.PixType != null &&
                    bank.PixType.Equals(spi.PixType) &&
                    bank.DatePixStarted != null &&
                    bank.DatePixStarted.Equals(spi.DatePixStarted))
                {
                    Logger.Log($"SPI | PSP updated: {spi.LongName}", ConsoleColor.DarkGreen);

                    upToDate++;
                    continue;
                }

                bank.PixType = spi.PixType;
                bank.DatePixStarted = spi.DatePixStarted;
                bank.DateUpdated = DateTimeOffset.UtcNow;

                found++;
            }

            Logger.Log($"\r\nSPI | Found: {found} | Not found: {notFound} | Up to Date: {upToDate}\r\n", ConsoleColor.DarkYellow);

            return this;
        }

        /// <summary>
        /// Seeds the CTC.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Seeder.</returns>
        public Seeder SeedCtc(IEnumerable<Bank> items)
        {
            var found = 0;
            var upToDate = 0;
            var notFound = 0;

            Logger.Log("CTC\r\n", ConsoleColor.DarkYellow);

            foreach (var ctc in items)
            {
                var bank = _source.SingleOrDefault(b => b.Document != null && b.Document.Equals(ctc.Document));

                if (bank == null)
                {
                    bank = _source.SingleOrDefault(b =>
                        b.LongName.RemoveDiacritics().Equals(ctc.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase) ||
                        (b.ShortName != null && b.ShortName.RemoveDiacritics().Equals(ctc.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase)));
                }

                if (bank == null)
                {
                    var ispb = int.Parse(ctc.Document.RemoveNonNumeric()[..8]);

                    if (ispb == 0 && !ctc.LongName.Equals("Banco do Brasil", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Logger.Log($"CTC | ISPB nulled: {ctc.LongName} | {ctc.Document.Trim()}", ConsoleColor.DarkRed);
                        continue;
                    }

                    bank = _source.SingleOrDefault(b => b.Ispb.Equals(ispb) && b.LongName.Contains(ctc.LongName, StringComparison.InvariantCultureIgnoreCase));
                }

                if (bank == null)
                {
                    Logger.Log($"CTC | Bank not found: {ctc.LongName} | {ctc.Document.Trim()}", ConsoleColor.DarkRed);
                    notFound++;
                    continue;
                }

                if ((string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18) &&
                    !string.IsNullOrWhiteSpace(ctc.Document))
                {
                    bank.Document = ctc.Document;
                    bank.DateUpdated = DateTimeOffset.UtcNow;
                }

                else if (string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18)
                {
                    Logger.Log($"CTC | Invalid document {ctc.Compe} | {bank.Document} | {ctc.Document}", ConsoleColor.DarkRed);
                }

                if (bank.Products != null && !bank.Products.Except(ctc.Products).Any())
                {
                    Logger.Log($"CTC | Products updated: {ctc.LongName}", ConsoleColor.DarkGreen);
                    upToDate++;
                    continue;
                }

                bank.Products = ctc.Products;
                bank.DateUpdated = DateTimeOffset.UtcNow;

                found++;
            }

            Logger.Log($"\r\nCTC | Found: {found} | Not found: {notFound} | Up to date: {upToDate}\r\n", ConsoleColor.DarkYellow);
            return this;
        }

        /// <summary>
        /// Seeds the siloc.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Seeder.</returns>
        public Seeder SeedSiloc(IEnumerable<Bank> items)
        {
            var found = 0;
            var upToDate = 0;
            var notFound = 0;

            Logger.Log("SILOC\r\n", ConsoleColor.DarkYellow);

            foreach (var siloc in items)
            {
                var bank = _source.SingleOrDefault(b => b.IspbString != null && b.IspbString.Equals(siloc.IspbString));

                if (bank == null)
                {
                    bank = _source.SingleOrDefault(b =>
                        b.LongName.RemoveDiacritics().Equals(siloc.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase) ||
                        (b.ShortName != null && b.ShortName.RemoveDiacritics().Equals(siloc.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase)));
                }

                if (bank == null)
                {
                    Logger.Log($"SILOC | Bank not found: {siloc.LongName} | {siloc.Document.Trim()}", ConsoleColor.DarkRed);
                    notFound++;
                    continue;
                }

                if ((string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18) &&
                    !string.IsNullOrWhiteSpace(siloc.Document))
                {
                    bank.Document = siloc.Document;
                    bank.DateUpdated = DateTimeOffset.UtcNow;
                }

                else if (string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18)
                {
                    Logger.Log($"SILOC | Invalid document {siloc.Compe} | {bank.Document} | {siloc.Document}", ConsoleColor.DarkRed);
                }

                if (bank.Charge != null && bank.Charge.Equals(siloc.Charge) &&
                    bank.CreditDocument != null && bank.CreditDocument.Equals(siloc.CreditDocument))
                {
                    Logger.Log($"SILOC | COB/DOC updated: {siloc.LongName}",ConsoleColor.DarkGreen);
                    upToDate++;
                    continue;
                }

                bank.Charge = siloc.Charge;
                bank.CreditDocument = siloc.CreditDocument;
                bank.DateUpdated = DateTimeOffset.UtcNow;

                found++;
            }
            
            Logger.Log($"\r\nSILOC | Found: {found} | Not found: {notFound} | Up to date: {upToDate}\r\n", ConsoleColor.DarkYellow);
            return this;
        }

        /// <summary>
        /// Seeds the PCPS.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>Seeder.</returns>
        public void SeedPcps(IEnumerable<Bank> items)
        {
            var found = 0;
            var upToDate = 0;
            var notFound = 0;
            
            Logger.Log("PCPS\r\n", ConsoleColor.DarkYellow);

            foreach (var pcps in items)
            {
                var bank = _source.SingleOrDefault(b => b.Document != null && b.Document.Equals(pcps.Document));

                if (bank == null)
                {
                    bank = _source.SingleOrDefault(b =>
                        b.LongName.RemoveDiacritics().Equals(pcps.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase) ||
                        (b.ShortName != null && b.ShortName.RemoveDiacritics().Equals(pcps.LongName.RemoveDiacritics(), StringComparison.InvariantCultureIgnoreCase)));
                }

                if (bank == null)
                {
                    var ispb = int.Parse(pcps.Document.RemoveNonNumeric()[..8]);

                    if (ispb == 0 && !pcps.LongName.Equals("Banco do Brasil", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Logger.Log($"PCPS | ISPB nulled: {pcps.LongName} | {pcps.Document.Trim()}", ConsoleColor.DarkRed);
                        continue;
                    }

                    bank = _source.SingleOrDefault(b => b.Ispb.Equals(ispb) && b.LongName.Contains(pcps.LongName, StringComparison.InvariantCultureIgnoreCase));
                }

                if (bank == null)
                {
                    Logger.Log($"PCPS | Bank not found: {pcps.LongName} | {pcps.Document.Trim()}", ConsoleColor.DarkRed);
                    notFound++;
                    continue;
                }

                if ((string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18) &&
                    !string.IsNullOrWhiteSpace(pcps.Document))
                {
                    bank.Document = pcps.Document;
                    bank.DateUpdated = DateTimeOffset.UtcNow;
                }

                else if (string.IsNullOrWhiteSpace(bank.Document) || bank.Document.Length != 18)
                {
                    Logger.Log($"SILOC | Invalid document {pcps.Compe} | {bank.Document} | {pcps.Document}", ConsoleColor.DarkRed);
                }

                if (bank.SalaryPortability != null && bank.SalaryPortability.Equals(pcps.SalaryPortability))
                {
                    Logger.Log($"PCPS | Salary portability updated: {pcps.LongName}", ConsoleColor.DarkGreen);
                    upToDate++;
                    continue;
                }

                bank.SalaryPortability = pcps.SalaryPortability;
                bank.DateUpdated = DateTimeOffset.UtcNow;

                found++;
            }

            Logger.Log($"\r\nPCPS | Found: {found} | Not found: {notFound} | Up to date: {upToDate}\r\n", ConsoleColor.DarkYellow);
        }
    }
}
