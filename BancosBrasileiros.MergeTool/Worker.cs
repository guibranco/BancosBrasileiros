// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 19/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 05-05-2021
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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using BancosBrasileiros.MergeTool.Dto;
    using CrispyWaffle.Extensions;
    using iTextSharp.text;

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

            var source = reader.LoadBase();
            var initial = source.ToArray().ToList();
            var str = reader.LoadStr();
            var slc = reader.LoadSlc();
            var pix = reader.LoadPix();

            var original = DeepCopy(source);

            Console.WriteLine($"Source: {source.Count} | STR: {str.Count} | SLC: {slc.Count} | PIX: {pix.Count} \r\n");

            new Seeder(source)
                .GenerateMissingDocument()
                .SeedStr(str)
                .SeedSlc(slc)
                .SeedPix(pix);

            foreach (var bank in source)
            {
                bank.DateRegistered ??= DateTimeOffset.Now;
                bank.DateUpdated ??= DateTimeOffset.Now;
            }

            var types = source.GroupBy(b => b.Type);

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            foreach (var type in types.OrderBy(g => g.Key))
            {
                Console.WriteLine($"Type: {(string.IsNullOrWhiteSpace(type.Key) ? "-" : type.Key)} | Total: {type.Count()}");
            }

            Console.ForegroundColor = ConsoleColor.White;

            source = source.Where(b => b.Ispb != 0 || b.Compe == 1).ToList();


            var except = source.Except(original).ToList();

            if (!except.Any())
            {
                Console.WriteLine("No new data or updated information");
                return;
            }

            var added = new List<Bank>();
            var updated = new List<Bank>();

            foreach (var exc in except)
            {
                var isUpdated = initial.Any(b => b.Ispb == exc.Ispb);

                if (isUpdated)
                    updated.Add(exc);
                else
                    added.Add(exc);
            }

            var changeLog = new StringBuilder();
            var pullRequestText = new StringBuilder();

            var color = ConsoleColor.DarkGreen;

            changeLog.Append($"{DateTime.Now:yyyy-MM-dd}: ");

            if (added.Any())
            {
                changeLog.Append($"- Adicionado {added.Count} bancos ({string.Join(", ", added.Select(i => $"{i.Compe} - {i.ShortName}"))}) ");

                pullRequestText.AppendLine($"Added banks: {added.Count}\r\n");

                Console.WriteLine($"\r\nAdded items: {added.Count}\r\n\r\n");

                foreach (var item in added)
                {
                    pullRequestText.AppendLine($"- [X] {item.Compe} - {item.LongName} - {item.Document}");

                    Console.ForegroundColor = color;
                    color = color == ConsoleColor.DarkGreen ? ConsoleColor.Cyan : ConsoleColor.DarkGreen;

                    Console.WriteLine($"Added: {item}\r\n");
                }

                pullRequestText.AppendLine("");
            }

            Console.ForegroundColor = ConsoleColor.White;

            color = ConsoleColor.DarkBlue;

            if (updated.Any())
            {
                changeLog.Append($"- Atualizado {updated.Count} bancos ({string.Join(", ", updated.Select(i => $"{i.Compe} - {i.ShortName}"))}) ");

                pullRequestText.AppendLine($"Updated banks: {updated.Count}\r\n");

                Console.WriteLine($"\r\nUpdated items: {updated.Count}\r\n\r\n");

                foreach (var item in updated)
                {
                    pullRequestText.AppendLine($"- [X] {item.Compe} - {item.LongName} - {item.Document}");

                    Console.ForegroundColor = color;
                    color = color == ConsoleColor.DarkBlue ? ConsoleColor.Blue : ConsoleColor.DarkBlue;

                    Console.WriteLine($"Updated: {item}\r\n");
                }
            }

            changeLog.Append("- [@guibranco](https://github.com/guibranco)");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\r\nSaving result files");

            Writer.WriteChangeLog(changeLog.ToString());
            Writer.WritePullRequest(pullRequestText.ToString());
            Writer.Save(source);

            Console.WriteLine($"Merge done. Banks: {source.Count} | Check 'result' folder in 'bin' directory!");

            var binDirectory = Directory.GetCurrentDirectory();
            var resultDirectory = Path.Combine(binDirectory, "result");
            Process.Start("explorer.exe", resultDirectory);
        }

        public static T DeepCopy<T>(T item)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            var result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
