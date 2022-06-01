// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 05-19-2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 05-31-2022
// ***********************************************************************
// <copyright file="Reader.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Helpers
{
    using System.Net.Http;
    using BancosBrasileiros.MergeTool.Dto;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using CrispyWaffle.Serialization;

    /// <summary>
    /// Class Reader.
    /// </summary>
    internal class Reader
    {
        /// <summary>
        /// The counting SLC
        /// </summary>
        private int _countingSlc;

        /// <summary>
        /// The counting sitraf
        /// </summary>
        private int _countingSitraf;

        /// <summary>
        /// The counting CTC
        /// </summary>
        private int _countingCtc;

        /// <summary>
        /// The counting PCPS
        /// </summary>
        private int _countingPcps;

        /// <summary>
        /// Downloads the string.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        private static string DownloadString(string url)
        {
            var client = new HttpClient();
            using var response = client.GetAsync(url).Result;
            using var content = response.Content;
            return content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Loads the change log.
        /// </summary>
        /// <returns>System.String.</returns>
        public string LoadChangeLog() => DownloadString(Constants.ChangeLogUrl);

        /// <summary>
        /// Loads the base.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadBase()
        {
            var data = DownloadString(Constants.BaseUrl);
            return SerializerFactory.GetCustomSerializer<List<Bank>>(SerializerFormat.JSON).Deserialize(data);
        }

        /// <summary>
        /// Loads the string.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadStr()
        {
            var data = DownloadString(Constants.StrUrl);
            var lines = data.Split("\n").Skip(1).ToArray();

            return lines
                .Select(line => Patterns.CsvPattern.Split(line))
                .Where(columns => columns.Length > 1 && int.TryParse(columns[2], out _))
                .Select(columns => new Bank
                {
                    CompeString = columns[2],
                    IspbString = columns[0],
                    LongName = columns[5].Replace("\"", "").Replace("?", "-").Trim(),
                    ShortName = columns[1].Trim(),
                    DateOperationStarted = DateTime.ParseExact(columns[6].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
                    Network = columns[4]
                })
                .ToList();
        }

        /// <summary>
        /// Loads the spi.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadSpi()
        {
            var baseDate = DateTime.Today;

            var data = GetPixData(baseDate);

            while (string.IsNullOrWhiteSpace(data))
            {
                baseDate = baseDate.AddDays(-1);
                data = GetPixData(baseDate);
            }

            var lines = data.Split("\n").Skip(1).ToArray();

            return lines
                  .Select(line => Patterns.SsvPattern.Split(line))
                  .Where(columns => columns.Length > 1 && int.TryParse(columns[0], out _))
                  .Select(columns => new Bank
                  {
                      IspbString = columns[0],
                      LongName = columns[1],
                      ShortName = columns[2],
                      PixType = columns[4],
                      DatePixStarted = DateTime
                      .Parse(columns[5].Trim(), CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal)
                      .ToUniversalTime()
                      .AddHours(-3)
                      .ToString("yyyy-MM-dd HH:mm:ss")
                  })
                  .ToList();
        }

        /// <summary>
        /// Gets the pix data.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>string.</returns>
        private string GetPixData(DateTime date)
        {
            try
            {
                return DownloadString(string.Format(Constants.SpiUrl, date));
            }
            catch (WebException)
            {
                return null;
            }
        }

        /// <summary>
        /// Loads the SLC.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadSlc()
        {
            _countingSlc = 0;
            var result = new List<Bank>();
            var reader = new PdfReader(Constants.SlcUrl);
            for (var currentPage = 1; currentPage <= reader.NumberOfPages; currentPage++)
            {
                var currentText = PdfTextExtractor.GetTextFromPage(reader, currentPage, new SimpleTextExtractionStrategy());
                currentText = Encoding.UTF8.GetString(Encoding.Convert(
                    Encoding.Default,
                    Encoding.UTF8,
                    Encoding.Default.GetBytes(currentText)));
                result.AddRange(ParseLinesSlc(currentText));
            }

            return result;
        }

        /// <summary>
        /// Parses the lines SLC.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>IEnumerable&lt;Bank&gt;.</returns>
        private IEnumerable<Bank> ParseLinesSlc(string page)
        {
            var result = new List<Bank>();
            var lines = page.Split("\n");

            var spliced = string.Empty;

            foreach (var line in lines)
            {
                if (!Patterns.SlcPattern.IsMatch(line))
                {
                    spliced += $" {line}";
                    continue;
                }

                Bank bank;

                if (!string.IsNullOrWhiteSpace(spliced))
                {
                    bank = ParseLineSlc(spliced.Trim());

                    if (bank != null)
                        result.Add(bank);

                    spliced = string.Empty;
                }

                bank = ParseLineSlc(line);

                if (bank != null)
                    result.Add(bank);
            }

            return result;
        }

        /// <summary>
        /// Parses the line SLC.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>Bank.</returns>
        private Bank ParseLineSlc(string line)
        {
            if (!Patterns.SlcPattern.IsMatch(line))
                return null;

            var match = Patterns.SlcPattern.Match(line);

            var code = Convert.ToInt32(match.Groups["code"].Value.Trim());

            _countingSlc++;

            if (_countingSlc != code)
                Console.WriteLine($"SLC | Counting: {_countingSlc} | Code: {code}");

            return new Bank
            {
                Document = match.Groups["cnpj"].Value.Trim(),
                LongName = match.Groups["nome"].Value.Replace("\"", "").Trim()
            };
        }

        /// <summary>
        /// Loads the siloc.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadSiloc()
        {
            var result = new List<Bank>();
            var reader = new PdfReader(Constants.SilocUrl);
            for (var currentPage = 1; currentPage <= reader.NumberOfPages; currentPage++)
            {
                var currentText = PdfTextExtractor.GetTextFromPage(reader, currentPage, new SimpleTextExtractionStrategy());
                currentText = Encoding.UTF8.GetString(Encoding.Convert(
                    Encoding.Default,
                    Encoding.UTF8,
                    Encoding.Default.GetBytes(currentText)));
                result.AddRange(ParseLinesSiloc(currentText));
            }

            return result;
        }

        /// <summary>
        /// Parses the lines siloc.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>IEnumerable&lt;Bank&gt;.</returns>
        private IEnumerable<Bank> ParseLinesSiloc(string page)
        {
            var result = new List<Bank>();
            var lines = page.Split("\n");

            foreach (var line in lines)
            {
                var bank = ParseLineSiloc(line);

                if (bank != null)
                    result.Add(bank);
            }

            return result;
        }

        /// <summary>
        /// Parses the line siloc.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>Bank.</returns>
        private Bank ParseLineSiloc(string line)
        {
            if (!Patterns.SilocPattern.IsMatch(line))
                return null;

            var match = Patterns.SilocPattern.Match(line);

            return new Bank
            {
                Compe = Convert.ToInt32(match.Groups["compe"].Value.Trim()),
                IspbString = match.Groups["ispb"].Value.Trim(),
                LongName = match.Groups["nome"].Value.Replace("\"", "").Trim(),
                Charge = match.Groups["cobranca"].Value.Trim(),
                CreditDocument = match.Groups["doc"].Value.Trim()
            };
        }

        /// <summary>
        /// Loads the sitraf.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadSitraf()
        {
            _countingSitraf = 0;
            var result = new List<Bank>();
            var reader = new PdfReader(Constants.SitrafUrl);
            for (var currentPage = 1; currentPage <= reader.NumberOfPages; currentPage++)
            {
                var currentText = PdfTextExtractor.GetTextFromPage(reader, currentPage, new SimpleTextExtractionStrategy());
                currentText = Encoding.UTF8.GetString(Encoding.Convert(
                    Encoding.Default,
                    Encoding.UTF8,
                    Encoding.Default.GetBytes(currentText)));
                result.AddRange(ParseLinesSitraf(currentText));
            }

            return result;
        }

        /// <summary>
        /// Parses the lines sitraf.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>IEnumerable&lt;Bank&gt;.</returns>
        private IEnumerable<Bank> ParseLinesSitraf(string page)
        {
            var result = new List<Bank>();
            var lines = page.Split("\n");

            var spliced = string.Empty;

            foreach (var line in lines)
            {
                if (!Patterns.SitrafPattern.IsMatch(line))
                {
                    spliced += $" {line}";
                    continue;
                }

                Bank bank;

                if (!string.IsNullOrWhiteSpace(spliced))
                {
                    bank = ParseLineSitraf(spliced.Trim());

                    if (bank != null)
                        result.Add(bank);

                    spliced = string.Empty;
                }

                bank = ParseLineSitraf(line);

                if (bank != null)
                    result.Add(bank);
            }

            return result;
        }

        /// <summary>
        /// Parses the line sitraf.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>Bank.</returns>
        private Bank ParseLineSitraf(string line)
        {
            if (!Patterns.SitrafPattern.IsMatch(line))
                return null;

            var match = Patterns.SitrafPattern.Match(line);

            var code = Convert.ToInt32(match.Groups["code"].Value.Trim());

            _countingSitraf++;

            if (_countingSitraf != code)
                Console.WriteLine($"SITRAF | Counting: {_countingSitraf} | Code: {code}");

            return new Bank
            {
                Compe = Convert.ToInt32(match.Groups["compe"].Value.Trim()),
                IspbString = match.Groups["ispb"].Value.Trim(),
                LongName = match.Groups["nome"].Value.Replace("\"", "").Trim()
            };
        }

        /// <summary>
        /// Loads the CTC.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadCtc()
        {
            _countingCtc = 0;
            var result = new List<Bank>();
            var reader = new PdfReader(Constants.CtcUrl);
            for (var currentPage = 1; currentPage <= reader.NumberOfPages; currentPage++)
            {
                var currentText = PdfTextExtractor.GetTextFromPage(reader, currentPage, new SimpleTextExtractionStrategy());
                currentText = Encoding.UTF8.GetString(Encoding.Convert(
                    Encoding.Default,
                    Encoding.UTF8,
                    Encoding.Default.GetBytes(currentText)));
                result.AddRange(ParsePageCtc(currentText));
            }

            return result;
        }

        /// <summary>
        /// Parses the lines CTC.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>IEnumerable&lt;Bank&gt;.</returns>
        private IEnumerable<Bank> ParsePageCtc(string page)
        {
            var result = new List<Bank>();
            var lines = page.Split("\n");

            var spliced = string.Empty;

            foreach (var line in lines)
            {
                if (!Patterns.CtcPattern.IsMatch(line))
                {
                    spliced += $" {line}";
                    continue;
                }

                Bank bank;

                if (!string.IsNullOrWhiteSpace(spliced))
                {
                    bank = ParseLineCtc(spliced.Trim());

                    if (bank != null)
                        result.Add(bank);

                    spliced = string.Empty;
                }

                bank = ParseLineCtc(line);

                if (bank != null)
                    result.Add(bank);
            }

            return result;
        }

        /// <summary>
        /// Parses the line CTC.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>Bank.</returns>
        private Bank ParseLineCtc(string line)
        {
            if (!Patterns.CtcPattern.IsMatch(line))
                return null;

            var match = Patterns.CtcPattern.Match(line);

            var code = Convert.ToInt32(match.Groups["code"].Value.Trim());

            _countingCtc++;

            if (_countingCtc != code)
                Console.WriteLine($"CTC | Counting: {_countingCtc++} | Code: {code}");

            return new Bank
            {
                Document = match.Groups["cnpj"].Value.Trim(),
                IspbString = match.Groups["ispb"].Value.Trim(),
                LongName = match.Groups["nome"].Value.Replace("\"", "").Trim(),
                Products = match.Groups["produtos"].Value.Split(",").Select(p => p.Trim()).OrderBy(p=>p).ToArray()
            };
        }

        /// <summary>
        /// Loads the PCPS.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadPcps()
        {
            _countingPcps = 0;
            var result = new List<Bank>();
            var reader = new PdfReader(Constants.PcpsUrl);
            for (var currentPage = 1; currentPage <= reader.NumberOfPages; currentPage++)
            {
                var currentText = PdfTextExtractor.GetTextFromPage(reader, currentPage, new SimpleTextExtractionStrategy());
                currentText = Encoding.UTF8.GetString(Encoding.Convert(
                    Encoding.Default,
                    Encoding.UTF8,
                    Encoding.Default.GetBytes(currentText)));
                result.AddRange(ParsePagePcps(currentText));
            }

            return result;
        }

        /// <summary>
        /// Parses the page PCPS.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>IEnumerable&lt;Bank&gt;.</returns>
        private IEnumerable<Bank> ParsePagePcps(string page)
        {
            var result = new List<Bank>();
            var lines = page.Split("\n");

            var spliced = string.Empty;

            foreach (var line in lines)
            {
                if (!Patterns.PcpsPattern.IsMatch(line))
                {
                    spliced += $" {line}";
                    continue;
                }

                Bank bank;

                if (!string.IsNullOrWhiteSpace(spliced))
                {
                    bank = ParseLinePcps(spliced.Trim());

                    if (bank != null)
                        result.Add(bank);

                    spliced = string.Empty;
                }

                bank = ParseLinePcps(line);

                if (bank != null)
                    result.Add(bank);
            }

            return result;
        }

        /// <summary>
        /// Parses the line PCPS.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>Bank.</returns>
        private Bank ParseLinePcps(string line)
        {
            if (!Patterns.PcpsPattern.IsMatch(line))
                return null;

            var match = Patterns.PcpsPattern.Match(line);

            var code = Convert.ToInt32(match.Groups["code"].Value.Trim());

            _countingPcps++;

            if (_countingPcps != code)
                Console.WriteLine($"PCPS | Counting: {_countingPcps++} | Code: {code}");

            return new Bank
            {
                Document = match.Groups["cnpj"].Value.Trim(),
                IspbString = match.Groups["ispb"].Value.Trim(),
                LongName = match.Groups["nome"].Value.Replace("\"", "").Trim(),
                SalaryPortability = match.Groups["adesao"].Value.Trim()
            };
        }
    }
}
