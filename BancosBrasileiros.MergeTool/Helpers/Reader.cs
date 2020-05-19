// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 19/05/2020
// ***********************************************************************
// <copyright file="Reader.cs" company="BancosBrasileiros.MergeTool">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using BancosBrasileiros.MergeTool.Dto;
using CrispyWaffle.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BancosBrasileiros.MergeTool.Helpers
{
    /// <summary>
    /// Class Reader.
    /// </summary>
    internal class Reader
    {

        /// <summary>
        /// Loads the CSV.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadCsv()
        {
            var result = new List<Bank>();
            var lines = File.ReadAllLines("data\\bancos.csv").Skip(1).ToArray();
            foreach (var line in lines)
            {
                var columns = line.Split(",");
                var bank = new Bank
                {
                    Compe = int.Parse(columns[0]),
                    Ispb = int.Parse(columns[1]),
                    Document = columns[2],
                    FiscalName = columns[3],
                    FantasyName = columns[4],
                    Url = string.IsNullOrWhiteSpace(columns[5]) ? string.Empty : columns[5],
                    IsRemoved = columns[9].Equals("true")
                };

                if (!string.IsNullOrWhiteSpace(columns[6]))
                    bank.DateRegistered = DateTime.Parse(columns[6], null, System.Globalization.DateTimeStyles.RoundtripKind);

                bank.DateUpdated = !string.IsNullOrWhiteSpace(columns[7])
                    ? DateTime.Parse(columns[7], null, System.Globalization.DateTimeStyles.RoundtripKind)
                    : DateTimeOffset.Now;

                if (!string.IsNullOrWhiteSpace(columns[8]) && bank.IsRemoved)
                    bank.DateRemoved = DateTime.Parse(columns[8], null, System.Globalization.DateTimeStyles.RoundtripKind);

                result.Add(bank);
            }

            return result;
        }

        /// <summary>
        /// Loads the json.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadJson() => SerializerFactory.GetCustomSerializer<List<Bank>>(SerializerFormat.JSON).Load("data\\bancos.json");

        /// <summary>
        /// Loads the markdown.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadMarkdown()
        {
            var result = new List<Bank>();
            var lines = File.ReadAllLines("data\\bancos.md").Skip(4).ToArray();
            foreach (var line in lines)
            {
                var columns = line.Split("|");
                for (var l = 0; l < columns.Length; l++)
                    columns[l] = columns[l].Equals(" - ")
                        ? string.Empty
                        : columns[l].Trim();

                var bank = new Bank
                {
                    Compe = int.Parse(columns[0]),
                    Ispb = int.Parse(columns[1]),
                    Document = columns[2],
                    FiscalName = columns[3],
                    FantasyName = columns[4],
                    Url = columns[5],
                    IsRemoved = columns[9].Equals("true")
                };

                if (!string.IsNullOrWhiteSpace(columns[6]))
                    bank.DateRegistered = DateTime.Parse(columns[6], null, System.Globalization.DateTimeStyles.RoundtripKind);

                if (!string.IsNullOrWhiteSpace(columns[7]))
                    bank.DateUpdated = DateTime.Parse(columns[7], null, System.Globalization.DateTimeStyles.RoundtripKind);

                if (!string.IsNullOrWhiteSpace(columns[8]))
                    bank.DateRemoved = DateTime.Parse(columns[8], null, System.Globalization.DateTimeStyles.RoundtripKind);

                result.Add(bank);
            }

            return result;
        }

        /// <summary>
        /// Loads the SQL.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadSql()
        {
            var result = new List<Bank>();
            var lines = File.ReadAllLines("data\\bancos.sql");
            foreach (var line in lines)
            {
                var pattern = "VALUES (";
                var indexOf = line.IndexOf(pattern, StringComparison.InvariantCultureIgnoreCase);

                var start = indexOf + pattern.Length;
                var end = line.Length - start - 2;

                var columns = line.Substring(start, end).Split(",");
                for (var l = 0; l < columns.Length; l++)
                    columns[l] = columns[l].Equals(" NULL")
                        ? string.Empty
                        : columns[l].Replace("'", string.Empty).Trim();

                var bank = new Bank
                {
                    Compe = int.Parse(columns[0]),
                    Ispb = int.Parse(columns[1]),
                    FiscalName = columns[2],
                    FantasyName = columns[3],
                    Document = columns[4],
                    Url = columns[5],
                    IsRemoved = int.Parse(columns[9]) == 1
                };

                if (!string.IsNullOrWhiteSpace(columns[6]))
                    bank.DateRegistered = DateTime.Parse(columns[6], null, System.Globalization.DateTimeStyles.RoundtripKind);

                if (!string.IsNullOrWhiteSpace(columns[7]))
                    bank.DateUpdated = DateTime.Parse(columns[7], null, System.Globalization.DateTimeStyles.RoundtripKind);

                if (!string.IsNullOrWhiteSpace(columns[8]))
                    bank.DateRemoved = DateTime.Parse(columns[8], null, System.Globalization.DateTimeStyles.RoundtripKind);

                result.Add(bank);
            }

            return result;
        }

        /// <summary>
        /// Loads the XML.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadXml() => SerializerFactory.GetCustomSerializer<Banks>(SerializerFormat.XML).Load("data\\bancos.xml").Bank.ToList();

        /// <summary>
        /// Loads the CNPJ.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadCnpj()
        {
            var result = new List<Bank>();
            var lines = File.ReadAllLines("data\\bancos-cnpj.md").Skip(4).ToArray();
            foreach (var line in lines)
            {
                var columns = line.Split("|");
                for (var l = 0; l < columns.Length; l++)
                    columns[l] = columns[l].Trim();

                var bank = new Bank
                {
                    Document = columns[0],
                    FiscalName = columns[1],
                    Type = columns[2],
                    Url = columns[3]
                };
                result.Add(bank);
            }
            return result;
        }

        /// <summary>
        /// Loads the ispb.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadIspb()
        {
            var result = new List<Bank>();
            var lines = File.ReadAllLines("data\\bancos-ispb.md").Skip(4).ToArray();
            foreach (var line in lines)
            {
                var columns = line.Split("|");
                for (var l = 0; l < columns.Length; l++)
                    columns[l] = columns[l].Equals(" n/a ")
                        ? string.Empty
                        : columns[l].Trim();

                var bank = new Bank
                {
                    Ispb = int.Parse(columns[0]),
                    FantasyName = columns[1],
                    Compe = string.IsNullOrWhiteSpace(columns[2]) ? 0 : int.Parse(columns[2]),
                    Network = columns[4],
                    FiscalName = columns[5],
                    DateOperationStarted = columns[6]
                };
                result.Add(bank);
            }
            return result;
        }

        /// <summary>
        /// Loads the site.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadSite()
        {
            var result = new List<Bank>();
            var lines = File.ReadAllLines("data\\bancos-site.md").Skip(4).ToArray();
            foreach (var line in lines)
            {
                var columns = line.Split("|");
                for (var l = 0; l < columns.Length; l++)
                    columns[l] = columns[l].Trim();

                var bank = new Bank
                {
                    Compe = int.Parse(columns[0]),
                    FiscalName = columns[1],
                    Url = columns[2]
                };
                result.Add(bank);
            }

            return result;
        }
    }
}
