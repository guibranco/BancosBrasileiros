// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 04-27-2021
// ***********************************************************************
// <copyright file="Comparer.cs" company="Guilherme Branco Stracini ME">
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
    /// Class Comparer.
    /// </summary>
    internal class Comparer
    {
        /// <summary>
        /// Compares the specified data.
        /// </summary>
        /// <param name="csv">The CSV.</param>
        /// <param name="html">The HTML.</param>
        /// <param name="json">The json.</param>
        /// <param name="markdown">The markdown.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="xml">The XML.</param>
        /// <returns>List&lt;Bank&gt;.</returns>
        public static IList<Bank> Compare(
            IEnumerable<Bank> csv,
            IEnumerable<Bank> html,
            IEnumerable<Bank> json,
            IEnumerable<Bank> markdown,
            IEnumerable<Bank> sql,
            IEnumerable<Bank> xml)
        {
            var normalizedList = csv.ToDictionary(item => item.Compe);

            foreach (var item in html)
                CompareItems(normalizedList, "HTML", item);

            foreach (var item in json)
                CompareItems(normalizedList, "JSON", item);

            foreach (var item in markdown)
                CompareItems(normalizedList, "Markdown", item);

            foreach (var item in sql)
                CompareItems(normalizedList, "SQL", item);

            foreach (var item in xml)
                CompareItems(normalizedList, "XML", item);


            return normalizedList.Select(i => i.Value).ToList();
        }

        /// <summary>
        /// Compares the items.
        /// </summary>
        /// <param name="normalizedList">The normalized list.</param>
        /// <param name="type">The type.</param>
        /// <param name="item">The item.</param>
        private static void CompareItems(Dictionary<int, Bank> normalizedList, string type, Bank item)
        {
            if (!normalizedList.ContainsKey(item.Compe))
            {
                item.Url = item.Url.ToLower();
                normalizedList.Add(item.Compe, item);
                return;
            }

            if (normalizedList[item.Compe].Equals(item))
                return;

            var normalized = normalizedList[item.Compe];

            Console.WriteLine($"{normalized} | CSV");
            Console.WriteLine($"{item} | {type}");

            if (normalized.Ispb == 0)
                normalized.Ispb = item.Ispb;
            if (item.Ispb == 0)
                item.Ispb = normalized.Ispb;

            if (string.IsNullOrWhiteSpace(normalized.Document))
                normalized.Document = item.Document;
            else if (string.IsNullOrWhiteSpace(item.Document))
                item.Document = normalized.Document;

            if (string.IsNullOrWhiteSpace(normalized.FiscalName) || item.FiscalName.Length > normalized.FiscalName.Length)
                normalized.FiscalName = item.FiscalName;

            if (!item.FiscalName.Equals(normalized.FiscalName))
                item.FiscalName = normalized.FiscalName;

            if (string.IsNullOrWhiteSpace(normalized.FantasyName) || item.FantasyName.Length < normalized.FantasyName.Length)
                normalized.FantasyName = item.FantasyName;

            if (!string.IsNullOrWhiteSpace(normalized.FantasyName) &&
                !normalized.FantasyName.Equals(item.FantasyName, StringComparison.InvariantCultureIgnoreCase))
            {
                if (!item.FiscalName.Equals(item.FantasyName))
                    Console.WriteLine($"Nome fantasia diferente em {type} | {normalized.FantasyName} | {item.FantasyName}");
                else
                    item.FantasyName = normalized.FantasyName;
            }

            if (string.IsNullOrWhiteSpace(normalized.Type))
                normalized.Type = item.Type;

            if (string.IsNullOrWhiteSpace(normalized.Url) && !string.IsNullOrWhiteSpace(item.Url))
                normalized.Url = item.Url.ToLower();
            else if (!string.IsNullOrWhiteSpace(normalized.Url) && string.IsNullOrWhiteSpace(item.Url))
                item.Url = normalized.Url.ToLower();

            if (!string.IsNullOrWhiteSpace(normalized.Url) && !normalized.Url.Equals(item.Url, StringComparison.InvariantCultureIgnoreCase))
                Console.WriteLine($"URL diferente em {type} | {normalized.Url} | {item.Url}");

            if (string.IsNullOrWhiteSpace(normalized.DateOperationStarted) && !string.IsNullOrWhiteSpace(item.DateOperationStarted))
                normalized.DateOperationStarted = item.DateOperationStarted;


            if (normalized.DateRegistered is { Ticks: 0 })
                normalized.DateRegistered = null;
            if (item.DateRegistered is { Ticks: 0 })
                item.DateRegistered = null;

            if (normalized.DateRegistered.HasValue &&
                item.DateRegistered.HasValue &&
                normalized.DateRegistered != item.DateRegistered)
            {
                var dateRegistered = new DateTime(Math.Min(normalized.DateRegistered.Value.Ticks, item.DateRegistered.Value.Ticks));
                normalized.DateRegistered = dateRegistered;
                item.DateRegistered = dateRegistered;
            }
            else if (!normalized.DateRegistered.HasValue && item.DateRegistered.HasValue)
                normalized.DateRegistered = item.DateRegistered;
            else if (!item.DateRegistered.HasValue && normalized.DateRegistered.HasValue)
                item.DateRegistered = normalized.DateRegistered;

            normalized.DateUpdated = DateTimeOffset.Now;
            item.DateUpdated = normalized.DateUpdated;

            if (normalized.DateRemoved is { Ticks: 0 })
                normalized.DateRemoved = null;

            if (item.DateRemoved is { Ticks: 0 })
                item.DateRemoved = null;

            if (!normalized.DateRemoved.HasValue && item.DateRemoved.HasValue)
                normalized.DateRemoved = item.DateRemoved;
            else if (normalized.DateRemoved.HasValue && item.DateRemoved.HasValue)
                normalized.DateRemoved = new DateTime(Math.Min(normalized.DateRemoved.Value.Ticks, item.DateRemoved.Value.Ticks));

            normalized.IsRemoved = normalized.DateRemoved.HasValue;

            if (normalized.Equals(item))
                return;

            Console.WriteLine($"{normalized} | CSV");
            Console.WriteLine($"{item} | {type}");
        }
    }
}
