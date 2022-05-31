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

using System.Net.Http;

namespace BancosBrasileiros.MergeTool.Helpers
{
    using Dto;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using CrispyWaffle.Serialization;

    /// <summary>
    /// Class Reader.
    /// </summary>
    internal class Reader
    {
        /// <summary>
        /// The comma separated values pattern
        /// </summary>
        private readonly Regex _csvPattern = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// The semicolon separated values pattern
        /// </summary>
        private readonly Regex _ssvPattern = new Regex(";(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// The SLC pattern
        /// </summary>
        private readonly Regex _slcPattern = new Regex(@"^(?<code>\d{1,3})\s(?<cnpj>\d{2}\.\d{3}\.\d{3}\/\d{4}([-|·|\.|\s]{1,2})\d{2})\s(?<nome>.+?)(?:[\s|X]){1,7}$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// The SILOC pattern
        /// </summary>
        private readonly Regex _silocPattern = new Regex(@"^(?<code>\d{1,3})\s(?<compe>\d{3})\s(?<ispb>\d{8})\s(?<cobranca>sim|não)\s(?<doc>sim|não)\s(?<nome>.+?)$");

        /// <summary>
        /// The change log URL
        /// </summary>
        private const string _changeLogUrl = "https://raw.githubusercontent.com/guibranco/BancosBrasileiros/master/CHANGELOG.md";

        /// <summary>
        /// The base URL
        /// </summary>
        private const string _baseUrl = "https://raw.githubusercontent.com/guibranco/BancosBrasileiros/master/data/bancos.json";

        /// <summary>
        /// The string URL
        /// </summary>
        private const string _strUrl = "http://www.bcb.gov.br/pom/spb/estatistica/port/ParticipantesSTRport.csv";

        /// <summary>
        /// The spi URL
        /// </summary>
        private const string _spiUrl = "https://www.bcb.gov.br/content/estabilidadefinanceira/spi/participantes-spi-{0:yyyyMMdd}.csv";

        /// <summary>
        /// The SLC URL
        /// </summary>
        private const string _slcUrl = "https://www.cip-bancos.org.br/Monitoramento/Participantes_Homologados.pdf";

        /// <summary>
        /// The siloc URL
        /// </summary>
        private const string _silocUrl = "https://www.cip-bancos.org.br/Monitoramento/SILOC.pdf";

        /// <summary>
        /// The counting SLC
        /// </summary>
        private int _countingSlc;

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
        public string LoadChangeLog() => DownloadString(_changeLogUrl);


        /// <summary>
        /// Loads the base.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadBase()
        {
            var data = DownloadString(_baseUrl);
            return SerializerFactory.GetCustomSerializer<List<Bank>>(SerializerFormat.JSON).Deserialize(data);
        }

        /// <summary>
        /// Loads the string.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadStr()
        {
            var data = DownloadString(_strUrl);
            var lines = data.Split("\n").Skip(1).ToArray();

            return lines
                .Select(line => _csvPattern.Split(line))
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
        /// Loads the pix.
        /// </summary>
        /// <returns>List&lt;Bank&gt;.</returns>
        public List<Bank> LoadPix()
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
                  .Select(line => _ssvPattern.Split(line))
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
                return DownloadString(string.Format(_spiUrl, date));
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

            var reader = new PdfReader(_slcUrl);
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
                if (!_slcPattern.IsMatch(line))
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
            if (!_slcPattern.IsMatch(line))
                return null;

            var match = _slcPattern.Match(line);

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

            var reader = new PdfReader(_silocUrl);
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


        private Bank ParseLineSiloc(string line)
        {
            if (!_silocPattern.IsMatch(line))
                return null;

            var match = _silocPattern.Match(line);

            var code = Convert.ToInt32(match.Groups["code"].Value.Trim());

            return new Bank
            {
                Compe = Convert.ToInt32(match.Groups["compe"].Value.Trim()),
                IspbString = match.Groups["ispb"].Value.Trim(),
                LongName = match.Groups["nome"].Value.Replace("\"", "").Trim()
            };
        }
    }
}
