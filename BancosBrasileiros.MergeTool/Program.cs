// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 18/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-01-2022
// ***********************************************************************
// <copyright file="Program.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool;

using System;
using System.Text;
using Helpers;

/// <summary>
/// Class Program.
/// </summary>
static class Program
{
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        Logger.Log("Bancos Brasileiros - Merge tool", ConsoleColor.Cyan);

        var worker = new Worker();
        worker.Work();
    }
}
