// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 06-01-2022
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-01-2022
// ***********************************************************************
// <copyright file="Source.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Helpers;

/// <summary>
/// Enum Source.
/// </summary>
internal enum Source
{
    /// <summary>
    /// The base.
    /// </summary>
    Base,

    /// <summary>
    /// The change log.
    /// </summary>
    ChangeLog,

    /// <summary>
    /// The CTC.
    /// </summary>
    Ctc,

    /// <summary>
    /// The PCPS.
    /// </summary>
    Pcps,

    /// <summary>
    /// The siloc.
    /// </summary>
    Siloc,

    /// <summary>
    /// The sitraf.
    /// </summary>
    Sitraf,

    /// <summary>
    /// The SLC.
    /// </summary>
    Slc,

    /// <summary>
    /// The SPI.
    /// </summary>
    Spi,

    /// <summary>
    /// The CQL.
    /// </summary>
    Cql,
}
