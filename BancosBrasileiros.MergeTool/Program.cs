// ***********************************************************************
// Assembly         : MergeBancosBrasileiros
// Author           : Guilherme Branco Stracini
// Created          : 18/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 19/05/2020
// ***********************************************************************
// <copyright file="Program.cs" company="MergeBancosBrasileiros">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace BancosBrasileiros.MergeTool
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Bancos Brasileiros - Merge tool");

            var worker = new Worker();
            worker.Work();
        }
    }
}
