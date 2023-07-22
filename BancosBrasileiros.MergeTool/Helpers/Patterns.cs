// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 05-31-2022
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-01-2022
// ***********************************************************************
// <copyright file="Patterns.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Helpers;

using System;
using System.Text.RegularExpressions;

/// <summary>
/// Class Patterns.
/// </summary>
internal static class Patterns
{
    /// <summary>
    /// The comma separated values pattern
    /// </summary>
    public static readonly Regex CsvPattern =
        new(
            ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled,
            TimeSpan.FromSeconds(5)
        );

    /// <summary>
    /// The semicolon separated values pattern
    /// </summary>
    public static readonly Regex SsvPattern =
        new(
            ";(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled,
            TimeSpan.FromSeconds(5)
        );

    /// <summary>
    /// The SLC pattern
    /// </summary>
    public static readonly Regex SlcPattern =
        new(
            @"^(?<code>\d{1,3})\s(?<cnpj>\d{1,2}\.\d{3}\.\d{3}(?:.|\/)\d{4}([-|·|\.|\s]{1,2})\d{2})\s(?<nome>.+?)(?:[\s|X]){1,7}$",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled,
            TimeSpan.FromSeconds(5)
        );

    /// <summary>
    /// The SILOC pattern
    /// </summary>
    public static readonly Regex SilocPattern =
        new(
            @"^(?<code>\d{1,3})\s(?<compe>\d{3})\s(?<ispb>\d{8})\s(?<cobranca>sim|não)\s(?<doc>sim|não)\s(?<nome>.+?)$",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled,
            TimeSpan.FromSeconds(5)
        );

    /// <summary>
    /// The sitraf pattern
    /// </summary>
    public static readonly Regex SitrafPattern =
        new(
            @"^(?<code>\d{1,3})\s(?<compe>\d{3})\s(?<ispb>\d{8})\s(?<nome>.+?)$",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled,
            TimeSpan.FromSeconds(5)
        );

    /// <summary>
    /// The ctc pattern
    /// </summary>
    public static readonly Regex CtcPattern =
        new(
            @"^(?<code>\d{1,3})\s(?<nome>.+?)\s(?<cnpj>\d{1,2}\.\d{3}\.\d{3}(?:.|\/)\d{4}([-|·|\.|\s]{1,2})\d{2})\s+(?<ispb>\d{8})\s(?<produtos>.+?)$",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled,
            TimeSpan.FromSeconds(5)
        );

    /// <summary>
    /// The PCPS pattern
    /// </summary>
    public static readonly Regex PcpsPattern =
        new(
            @"^(?<code>\d{1,3})\s(?<nome>.+?)\s(?<cnpj>\d{1,2}\.\d{3}\.\d{3}(?:.|\/)\d{4}([-|·|\.|\s]{1,3})\d{2})\s+(?<ispb>\d{7,8})\s(?<adesao>.+?)$",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled,
            TimeSpan.FromSeconds(5)
        );

    public static readonly Regex CqlPattern =
        new(
            @"^(?<code>\d{1,3})\s(?<nome>.+?)\s(?<ispb>\d{7,8})\s(?<tipo>.+?)$",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled,
            TimeSpan.FromSeconds(5)
        );
}
