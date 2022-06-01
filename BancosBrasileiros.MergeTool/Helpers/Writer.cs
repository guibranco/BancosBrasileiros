// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-01-2022
// ***********************************************************************
// <copyright file="Writer.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Helpers
{
    using CrispyWaffle.Serialization;
    using Dto;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class Writer.
    /// </summary>
    internal static class Writer
    {
        /// <summary>
        /// Writes the change log.
        /// </summary>
        /// <param name="changeLog">The change log.</param>
        public static void WriteChangeLog(string changeLog)
        {
            if (!Directory.Exists("result"))
                Directory.CreateDirectory("result");

            var changeLogFile = new Reader().LoadChangeLog();

            var result = changeLogFile.Replace("## Changelog\n\n", $"## Changelog\n\n{changeLog}\n");

            File.WriteAllText("result\\CHANGELOG.md", result);
        }

        /// <summary>
        /// Writes the pull request.
        /// </summary>
        /// <param name="pullRequest">The pull request.</param>
        public static void WritePullRequest(string pullRequest)
        {
            if (!Directory.Exists("result"))
                Directory.CreateDirectory("result");

            File.WriteAllText("result\\pullRequest.txt", pullRequest);
        }

        /// <summary>
        /// Saves the specified banks.
        /// </summary>
        /// <param name="banks">The banks.</param>
        public static void Save(IList<Bank> banks)
        {
            if (!Directory.Exists("result"))
                Directory.CreateDirectory("result");

            banks = banks.OrderBy(b => b.Compe).ToList();

            SaveCsv(banks);
            banks.GetCustomSerializer(SerializerFormat.JSON).Save("result\\bancos.json");
            SaveMarkdown(banks);
            SaveSql(banks);
            new Banks { Bank = banks.ToArray() }.GetCustomSerializer(SerializerFormat.XML).Save("result\\bancos.xml");
        }

        /// <summary>
        /// Saves the CSV.
        /// </summary>
        /// <param name="banks">The banks.</param>
        private static void SaveCsv(IList<Bank> banks)
        {
            var lines = new List<string>
            {
                "COMPE,ISPB,Document,LongName,ShortName,Network,Type,PixType,Url,DateOperationStarted,DatePixStarted,DateRegistered,DateUpdated"
            };

            lines.AddRange(banks.Select(bank => $"{bank.Compe:000},{bank.Ispb:00000000},{bank.Document},{bank.LongName.Replace(",", "")},{bank.ShortName.Replace(",", "")},{bank.Type},{bank.PixType},{bank.Network},{bank.Url},{bank.DateOperationStarted},{bank.DatePixStarted},{bank.DateRegistered:O},{bank.DateUpdated:O}"));

            File.WriteAllLines("result\\bancos.csv", lines, Encoding.UTF8);
        }

        /// <summary>
        /// Saves the markdown.
        /// </summary>
        /// <param name="banks">The banks.</param>
        private static void SaveMarkdown(IList<Bank> banks)
        {
            var lines = new List<string>
            {
                "# Bancos Brasileiros",
                string.Empty,
                "COMPE | ISPB | Document | Long Name | Short Name | Network | Type | PIX Type | Url | Date Operation Started | Date PIX Started | Date Registered | Date Updated",
                "--- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- "
            };

            lines.AddRange(banks.Select(bank => $"{bank.Compe:000} | {bank.Ispb:00000000} | {bank.Document} | {bank.LongName} | {bank.ShortName} | {(string.IsNullOrWhiteSpace(bank.Network) ? "-" : bank.Network)} | {(string.IsNullOrWhiteSpace(bank.Type) ? "-" : bank.Type)} | {(string.IsNullOrWhiteSpace(bank.PixType) ? "-" : bank.PixType)} | {(string.IsNullOrWhiteSpace(bank.Url) ? "-" : bank.Url)} | {(string.IsNullOrWhiteSpace(bank.DateOperationStarted) ? "-" : bank.DateOperationStarted)} | {(string.IsNullOrWhiteSpace(bank.DatePixStarted) ? "-" : bank.DatePixStarted)} | {bank.DateRegistered:O} | {bank.DateUpdated:O}"));

            File.WriteAllLines("result\\bancos.md", lines, Encoding.UTF8);
        }

        /// <summary>
        /// Saves the SQL.
        /// </summary>
        /// <param name="banks">The banks.</param>
        private static void SaveSql(IList<Bank> banks)
        {
            var lines = new List<string>();

            const string prefix = "INSERT INTO Banks (Compe, Ispb, Document, LongName, ShortName, Network, Type, PixType, Url, DateOperationStarted, DatePixStarted, DateRegistered, DateUpdated) VALUES(";
            lines.AddRange(banks.Select(bank => $"{prefix}'{bank.Compe:000}','{bank.Ispb:00000000}','{bank.Document}','{bank.LongName.Replace("'", "\\\'")}','{bank.ShortName}',{(string.IsNullOrWhiteSpace(bank.Type) ? "NULL" : $"'{bank.Type}'")},{(string.IsNullOrWhiteSpace(bank.PixType) ? "NULL" : $"'{bank.PixType}'")},{(string.IsNullOrWhiteSpace(bank.Network) ? "NULL" : $"'{bank.Network}'")},{(string.IsNullOrWhiteSpace(bank.Url) ? "NULL" : $"'{bank.Url}'")},{(string.IsNullOrWhiteSpace(bank.DateOperationStarted) ? "NULL" : $"'{bank.DateOperationStarted}'")},{(string.IsNullOrWhiteSpace(bank.DatePixStarted) ? "NULL" : $"'{bank.DatePixStarted}'")},'{bank.DateRegistered:O}','{bank.DateUpdated:O}');"));

            File.WriteAllLines("result\\bancos.sql", lines, Encoding.UTF8);
        }
    }
}
