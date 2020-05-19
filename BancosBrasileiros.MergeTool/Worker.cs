// ***********************************************************************
// Assembly         : MergeBancosBrasileiros
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 19/05/2020
// ***********************************************************************
// <copyright file="Worker.cs" company="MergeBancosBrasileiros">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace BancosBrasileiros.MergeTool
{
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

            var csv = reader.LoadCsv();
            var json = reader.LoadJson();
            var markdown = reader.LoadMarkdown();
            var sql = reader.LoadSql();
            var xml = reader.LoadXml();

            Console.WriteLine($"CSV: {csv.Count} | JSON: {json.Count} | SQL: {sql.Count} | Markdown: {markdown.Count} | XML: {xml.Count}");

            var comparer = new Comparer();
            var normalized = comparer.Compare(csv, json, markdown, sql, xml);

            Console.WriteLine($"Normalized: {normalized.Count}");

            var cnpj = reader.LoadCnpj();
            var ispb = reader.LoadIspb();
            var site = reader.LoadSite();

            Console.WriteLine($"CNPJ: {cnpj.Count} | ISPB: {ispb.Count} | Site: {site.Count}");

            var seeder = new Seeder();
            seeder.Seed(normalized, cnpj, ispb, site);

            var writer = new Writer();
            writer.Save(normalized);

            Console.WriteLine("Merge done. Check result folder in bin directory!");
        }
    }
}
