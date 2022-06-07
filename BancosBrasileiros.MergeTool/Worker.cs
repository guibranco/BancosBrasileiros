// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-01-2022
// ***********************************************************************
// <copyright file="Worker.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool
{
    using Newtonsoft.Json;
    using BancosBrasileiros.MergeTool.Helpers;
    using BancosBrasileiros.MergeTool.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class Worker.
    /// </summary>
    internal class Worker
    {

        /// <summary>
        /// Works this instance.
        /// </summary>
        public void Work()
        {
            Logger.Log("Reading data files", ConsoleColor.White);

            var reader = new Reader();

            var source = reader.LoadBase();
            var initial = source.ToArray().ToList();

            var ctc = reader.LoadCtc();
            var siloc = reader.LoadSiloc();
            var sitraf = reader.LoadSitraf();
            var slc = reader.LoadSlc();
            var spi = reader.LoadSpi();
            var str = reader.LoadStr();
            var pcps = reader.LoadPcps();

            var original = DeepClone(source);

            Logger.Log($"Source: {source.Count} | CTC: {ctc.Count} | SILOC: {siloc.Count} | SITRAF: {sitraf.Count} | SLC: {slc.Count} | SPI: {spi.Count} | STR: {str.Count} | PCPS: {pcps.Count} \r\n", ConsoleColor.DarkGreen);

            new Seeder(source)
                .GenerateMissingDocument()
                .SeedStr(str)
                .SeedSitraf(sitraf)
                .SeedSlc(slc)
                .SeedSpi(spi)
                .SeedCtc(ctc)
                .SeedSiloc(siloc)
                .SeedPcps(pcps);

            foreach (var bank in source)
            {
                bank.DateRegistered ??= DateTimeOffset.UtcNow;
                bank.DateUpdated ??= DateTimeOffset.UtcNow;
            }

            var types = source.GroupBy(b => b.Type);

            Logger.Log($"Type: All | Total: {source.Count}", ConsoleColor.Yellow);

            foreach (var type in types.OrderBy(g => g.Key))
            {
                Logger.Log($"Type: {(string.IsNullOrWhiteSpace(type.Key) ? "-" : type.Key)} | Total: {type.Count()}", ConsoleColor.DarkYellow);
            }

            source = source.Where(b => b.Ispb != 0 || b.Compe == 1).ToList();

            var except = source.Except(original).ToList();

            if (!except.Any())
            {
                Logger.Log("No new data or updated information", ConsoleColor.DarkMagenta);
                Environment.Exit(1);
                return;
            }

            var added = new List<Bank>();
            var updated = new List<Bank>();

            foreach (var exc in except)
            {
                var isUpdated = initial.Any(b => b.Ispb == exc.Ispb);

                if (isUpdated)
                    updated.Add(exc);
                else
                    added.Add(exc);
            }

            var changeLog = new StringBuilder();
            var pullRequestText = new StringBuilder();

            var color = ConsoleColor.DarkGreen;

            changeLog.AppendLine($"### {DateTime.Now:yyyy-MM-dd} - [@guibranco](https://github.com/guibranco):\r\n");

            if (added.Any())
            {
                changeLog.AppendLine($"- Added {added.Count} banks");

                pullRequestText.AppendLine($"Added banks: {added.Count}\r\n");

                Logger.Log($"\r\nAdded items: {added.Count}\r\n\r\n", ConsoleColor.White);
                
                foreach (var item in added)
                {
                    changeLog.AppendLine($"\t- {item.Compe} - {item.ShortName} - {item.Document}");

                    pullRequestText.AppendLine($"- [X] {item.Compe} - {item.LongName} - {item.Document}");

                    color = color == ConsoleColor.DarkGreen ? ConsoleColor.Cyan : ConsoleColor.DarkGreen;
                    Logger.Log($"Added: {item}\r\n", color);
                }

                pullRequestText.AppendLine("");
            }

            color = ConsoleColor.DarkBlue;

            if (updated.Any())
            {
                changeLog.AppendLine($"- Updated {updated.Count} banks");

                pullRequestText.AppendLine($"Updated banks: {updated.Count}\r\n");

                Logger.Log($"\r\nUpdated items: {updated.Count}\r\n\r\n", ConsoleColor.White);

                foreach (var item in updated)
                {
                    changeLog.AppendLine($"\t- {item.Compe} - {item.ShortName} - {item.Document}");

                    pullRequestText.AppendLine($"- [X] {item.Compe} - {item.LongName} - {item.Document}");
                    
                    color = color == ConsoleColor.DarkBlue ? ConsoleColor.Blue : ConsoleColor.DarkBlue;
                    Logger.Log($"Updated: {item}\r\n", color);
                }
            }

            Logger.Log("\r\nSaving result files", ConsoleColor.White);

            Writer.WriteChangeLog(changeLog.ToString());
            Writer.WritePullRequest(pullRequestText.ToString());
            Writer.SaveBanks(source);

            Console.WriteLine($"Merge done. Banks: {source.Count}");
        }

        /// <summary>
        /// Deeps the clone.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns>T.</returns>
        private static T DeepClone<T>(T item)
        {
            var json = JsonConvert.SerializeObject(item);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
