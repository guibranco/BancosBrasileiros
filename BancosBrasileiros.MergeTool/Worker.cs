// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 04-27-2021
// ***********************************************************************
// <copyright file="Worker.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool
{
    using Helpers;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Class Worker.
    /// </summary>
    internal class Worker
    {

        /// <summary>
        /// Works this instance.
        /// </summary>
        public void Work()
        {
            Console.WriteLine("Reading data files");

            var reader = new Reader();

            var str = reader.LoadStr();
            var cnpj = reader.LoadCnpj();
            var site = reader.LoadSite();
            var slc = reader.LoadSlc();

            Console.WriteLine($"STR: {str.Count} | CNPJ: {cnpj.Count} | Site: {site.Count} | SLC: {slc.Count} \r\n");

            var seeder = new Seeder(); //The order must be STR -> Site -> ISPB -> CNPJ -> SLC to find the Fiscal Name and the COMPE code.
            seeder.SeedSite(str, site);
            seeder.SeedDocument(str, cnpj);
            seeder.SeedSlc(str, slc);

            foreach (var bank in str)
            {
                bank.DateRegistered ??= DateTimeOffset.Now;
                bank.DateUpdated ??= DateTimeOffset.Now;
            }

            var types = str.GroupBy(b => b.Type);
            foreach (var type in types.OrderBy(g => g.Key))
            {
                Console.WriteLine($"Type: {type.Key} | Total: {type.Count()}");
            }

            str = str.Where(b => b.Ispb != 0 || b.Compe == 1).ToList();

            Console.WriteLine("\r\nSaving result files");

            var writer = new Writer();
            writer.Save(str);

            Console.WriteLine($"Merge done. Banks: {str.Count} | Check 'result' folder in 'bin' directory!");

            var binDirectory = Directory.GetCurrentDirectory();
            var resultDirectory = Path.Combine(binDirectory, "result");
            Process.Start("explorer.exe", resultDirectory);
        }
    }
}
