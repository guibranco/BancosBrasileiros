// ***********************************************************************
// Assembly         : MergeBancosBrasileiros
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 19/05/2020
// ***********************************************************************
// <copyright file="Writter.cs" company="MergeBancosBrasileiros">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.IO;
using System.Linq;
using CrispyWaffle.Serialization;

namespace BancosBrasileiros.MergeTool
{
    /// <summary>
    /// Class Writter.
    /// </summary>
    internal class Writer
    {

        /// <summary>
        /// Saves the specified banks.
        /// </summary>
        /// <param name="banks">The banks.</param>
        public void Save(IList<Bank> banks)
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
        private void SaveCsv(IList<Bank> banks)
        {
            var lines = new List<string>
            {
                "COMPE,ISPB,Document,FiscalName,FantasyName,Network,Type,Url,DateOperationStarted,DateRegistered,DateUpdated,DateRemoved,IsRemoved"
            };

            lines.AddRange(banks.Select(bank => $"{bank.Compe:000},{bank.Ispb:00000000},{bank.Document},{bank.FiscalName},{bank.FantasyName},{bank.Type},{bank.Network},{bank.Url},{bank.DateOperationStarted},{bank.DateRegistered:O},{bank.DateUpdated:O},{bank.DateRemoved:O},{bank.IsRemoved.ToString().ToLower()}"));

            File.WriteAllLines("result\\bancos.csv", lines);
        }

        /// <summary>
        /// Saves the markdown.
        /// </summary>
        /// <param name="banks">The banks.</param>
        private void SaveMarkdown(IList<Bank> banks)
        {
            var lines = new List<string>
            {
                "# Bancos Brasileiros",
                string.Empty,
                "COMPE | ISPB | Document | Fiscal Name | Fantasy Name | Network | Type | Url | Date Operation Started | Date Registered | Date Updated | Date Removed | Is Removed",
                "-- | -- | -- | -- | -- | -- | -- | -- | -- | -- | -- | -- | --"
            };

            lines.AddRange(banks.Select(bank => $"{bank.Compe:000} | {bank.Ispb:00000000} | {bank.Document} | {bank.FiscalName} | {bank.FantasyName} | {(string.IsNullOrWhiteSpace(bank.Network) ? "-" : bank.Network)} | {(string.IsNullOrWhiteSpace(bank.Type) ? "-" : bank.Type)} | {(string.IsNullOrWhiteSpace(bank.Url) ? "-" : bank.Url)} | {(string.IsNullOrWhiteSpace(bank.DateOperationStarted) ? "-" : bank.DateOperationStarted)} | {bank.DateUpdated:O} | {(bank.DateRemoved.HasValue ? bank.DateRemoved.Value.ToString("O") : "-")} | {bank.IsRemoved.ToString().ToLower()}"));

            File.WriteAllLines("result\\bancos.md", lines);
        }

        /// <summary>
        /// Saves the SQL.
        /// </summary>
        /// <param name="banks">The banks.</param>
        private void SaveSql(IList<Bank> banks)
        {
            var lines = new List<string>();

            const string prefix = "INSERT INTO Banks (Compe, Ispb, Document, FiscalName, FantasyName, Network, Type, Url, DateOperationStarted, DateRegistered, DateUpdated, DateRemoved, IsRemoved) VALUES(";
            lines.AddRange(banks.Select(bank => $"{prefix}'{bank.Compe:000}','{bank.Ispb:00000000}','{bank.Document}','{bank.FiscalName}','{bank.FantasyName}',{(string.IsNullOrWhiteSpace(bank.Type) ? "NULL" : $"'{bank.Type}'")},{(string.IsNullOrWhiteSpace(bank.Network) ? "NULL" : $"'{bank.Network}'")},{(string.IsNullOrWhiteSpace(bank.Url) ? "NULL" : $"'{bank.Url}'")},{(string.IsNullOrWhiteSpace(bank.DateOperationStarted) ? "NULL" : $"'{bank.DateOperationStarted}'")},'{bank.DateRegistered:O}','{bank.DateUpdated:O}',{(bank.DateRemoved.HasValue ? $"'{bank.DateRemoved:O}'" : "NULL")},{(bank.IsRemoved ? 1 : 0)});"));

            File.WriteAllLines("result\\bancos.sql", lines);
        }
    }
}
