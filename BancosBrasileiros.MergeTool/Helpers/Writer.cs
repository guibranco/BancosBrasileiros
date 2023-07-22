// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/09/2022
// ***********************************************************************
// <copyright file="Writer.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Helpers;

using CrispyWaffle.Serialization;
using Dto;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
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

        var changeLogFile = Reader.LoadChangeLog();

        changeLogFile = changeLogFile.Replace("## Changelog\r\n\r\n", "## Changelog\n\n");
        var result = changeLogFile.Replace("## Changelog\n\n", $"## Changelog\n\n{changeLog}\n");

        File.WriteAllText($"result{Path.DirectorySeparatorChar}CHANGELOG.md", result);
    }

    /// <summary>
    /// Saves the specified banks.
    /// </summary>
    /// <param name="banks">The banks.</param>
    public static void SaveBanks(IList<Bank> banks)
    {
        if (!Directory.Exists("result"))
            Directory.CreateDirectory("result");

        banks = banks.OrderBy(b => b.Compe).ToList();

        SaveCsv(banks);
        banks
            .GetCustomSerializer(SerializerFormat.Json)
            .Save($"result{Path.DirectorySeparatorChar}bancos.json");
        SaveMarkdown(banks);
        SaveSql(banks);
        new Banks { Bank = banks.ToArray() }
            .GetCustomSerializer(SerializerFormat.Xml)
            .Save($"result{Path.DirectorySeparatorChar}bancos.xml");
    }

    /// <summary>
    /// Saves the CSV.
    /// </summary>
    /// <param name="banks">The banks.</param>
    private static void SaveCsv(IList<Bank> banks)
    {
        var lines = new List<string> { string.Join(",", GetFieldsJsonPropertyNames) };

        lines.AddRange(
            banks.Select(
                bank =>
                    $"{bank.Compe:000},{bank.Ispb:00000000},{bank.Document},{bank.LongName.Replace(",", "")},{bank.ShortName.Replace(",", "")},{bank.Network},{bank.Type},{bank.PixType},{(string.IsNullOrWhiteSpace(bank.ChargeStr) ? "" : bank.ChargeStr)},{(string.IsNullOrWhiteSpace(bank.CreditDocumentStr) ? "" : bank.CreditDocumentStr)},{(bank.LegalCheque ? "Sim" : "Não")},{bank.SalaryPortability},{(bank.Products == null ? "NULL" : string.Join("|", bank.Products))},{bank.Url},{bank.DateOperationStarted},{bank.DatePixStarted},{bank.DateRegistered:O},{bank.DateUpdated:O}"
            )
        );

        File.WriteAllLines($"result{Path.DirectorySeparatorChar}bancos.csv", lines, Encoding.UTF8);
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
            string.Join(" | ", GetFieldsDisplayNames),
            string.Join(" | ", GetFieldsDisplayNames.Select(_ => "---"))
        };

        lines.AddRange(
            banks.Select(
                bank =>
                    $"{bank.Compe:000} | {bank.Ispb:00000000} | {bank.Document} | {bank.LongName} | {bank.ShortName} | {(string.IsNullOrWhiteSpace(bank.Network) ? "-" : bank.Network)} | {(string.IsNullOrWhiteSpace(bank.Type) ? "-" : bank.Type)} | {(string.IsNullOrWhiteSpace(bank.PixType) ? "-" : bank.PixType)} | {(string.IsNullOrWhiteSpace(bank.ChargeStr) || !bank.Charge.HasValue ? "-" : (bank.Charge.Value ? "Sim" : "Não"))} | {(string.IsNullOrWhiteSpace(bank.CreditDocumentStr) || !bank.CreditDocument.HasValue ? "-" : (bank.CreditDocument.Value ? "Sim" : "Não"))} | {(bank.LegalCheque ? "Sim" : "Não")} | {(string.IsNullOrWhiteSpace(bank.SalaryPortability) ? "-" : bank.SalaryPortability)} | {(bank.Products == null ? "-" : string.Join(",", bank.Products))} | {(string.IsNullOrWhiteSpace(bank.Url) ? "-" : bank.Url)} | {(string.IsNullOrWhiteSpace(bank.DateOperationStarted) ? "-" : bank.DateOperationStarted)} | {(string.IsNullOrWhiteSpace(bank.DatePixStarted) ? "-" : bank.DatePixStarted)} | {bank.DateRegistered:O} | {bank.DateUpdated:O}"
            )
        );

        File.WriteAllLines($"result{Path.DirectorySeparatorChar}bancos.md", lines, Encoding.UTF8);
    }

    /// <summary>
    /// Saves the SQL.
    /// </summary>
    /// <param name="banks">The banks.</param>
    private static void SaveSql(IList<Bank> banks)
    {
        var lines = new List<string>();

        var prefix = $"INSERT INTO Banks ({string.Join(",", GetFieldsJsonPropertyNames)}) VALUES(";
        lines.AddRange(
            banks.Select(
                bank =>
                    $"{prefix}'{bank.Compe:000}','{bank.Ispb:00000000}','{bank.Document}','{bank.LongName.Replace("'", "''")}','{bank.ShortName}',{(string.IsNullOrWhiteSpace(bank.Type) ? "NULL" : $"'{bank.Type}'")},{(string.IsNullOrWhiteSpace(bank.PixType) ? "NULL" : $"'{bank.PixType}'")},{(string.IsNullOrWhiteSpace(bank.Network) ? "NULL" : $"'{bank.Network}'")},{(string.IsNullOrWhiteSpace(bank.ChargeStr) ? "NULL" : $"'{bank.Charge}'")},{(string.IsNullOrWhiteSpace(bank.CreditDocumentStr) ? "NULL" : $"'{bank.CreditDocument}'")},'{bank.SalaryPortability}',{(string.IsNullOrWhiteSpace(bank.SalaryPortability) ? "NULL" : $"'{bank.SalaryPortability}'")},{(bank.Products == null ? "NULL" : $"'{string.Join(",", bank.Products)}'")},{(string.IsNullOrWhiteSpace(bank.Url) ? "NULL" : $"'{bank.Url}'")},{(string.IsNullOrWhiteSpace(bank.DateOperationStarted) ? "NULL" : $"'{bank.DateOperationStarted}'")},{(string.IsNullOrWhiteSpace(bank.DatePixStarted) ? "NULL" : $"'{bank.DatePixStarted}'")},'{bank.DateRegistered:O}','{bank.DateUpdated:O}');"
            )
        );

        File.WriteAllLines($"result{Path.DirectorySeparatorChar}bancos.sql", lines, Encoding.UTF8);
    }

    /// <summary>
    /// Gets the get fields json property names.
    /// </summary>
    /// <value>The get fields json property names.</value>
    private static string[] GetFieldsJsonPropertyNames { get; } =
        typeof(Bank)
            .GetProperties()
            .Where(pi => pi.GetCustomAttribute<JsonIgnoreAttribute>() == null)
            .Select(pi => pi.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? pi.Name)
            .ToArray();

    /// <summary>
    /// Gets the get fields display names.
    /// </summary>
    /// <value>The get fields display names.</value>
    private static string[] GetFieldsDisplayNames { get; } =
        typeof(Bank)
            .GetProperties()
            .Where(pi => pi.GetCustomAttribute<JsonIgnoreAttribute>() == null)
            .Select(
                pi =>
                    pi.GetCustomAttribute<DisplayAttribute>()?.Name
                    ?? pi.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName
                    ?? pi.Name
            )
            .ToArray();
}
