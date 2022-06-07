// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 06-07-2022
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-07-2022
// ***********************************************************************
// <copyright file="Helpers.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BancosBrasileiros.MergeTool.Helpers
{
    using System;

    /// <summary>
    /// Class Helpers.
    /// </summary>
    internal static class Logger
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="color">The color.</param>
        public static void Log(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}