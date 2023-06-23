// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 05-31-2022
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-01-2022
// ***********************************************************************
// <copyright file="Constants.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BancosBrasileiros.MergeTool.Helpers
{
    /// <summary>
    /// Class Constants.
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// The change log URL
        /// </summary>
        public const string ChangeLogUrl = "https://raw.githubusercontent.com/guibranco/BancosBrasileiros/main/CHANGELOG.md";

        /// <summary>
        /// The base URL
        /// </summary>
        public const string BaseUrl = "https://raw.githubusercontent.com/guibranco/BancosBrasileiros/main/data/bancos.json";

        /// <summary>
        /// The string URL
        /// </summary>
        public const string StrUrl = "http://www.bcb.gov.br/pom/spb/estatistica/port/ParticipantesSTRport.csv";

        /// <summary>
        /// The spi URL
        /// </summary>
        public const string SpiUrl = "https://www.bcb.gov.br/content/estabilidadefinanceira/spi/participantes-spi-{0:yyyyMMdd}.csv";

        /// <summary>
        /// The SLC URL
        /// </summary>
        public const string SlcUrl = "https://www2.nuclea.com.br/Monitoramento/Participantes_Homologados.pdf";

        /// <summary>
        /// The siloc URL
        /// </summary>
        public const string SilocUrl = "https://www2.nuclea.com.br/Monitoramento/SILOC.pdf";

        /// <summary>
        /// The sitraf URL
        /// </summary>
        public const string SitrafUrl = "https://www2.nuclea.com.br/Monitoramento/Relação%20de%20Clientes%20SITRAF.pdf";

        /// <summary>
        /// The CTC URL
        /// </summary>
        public const string CtcUrl = "https://www2.nuclea.com.br/SAP/CTC.pdf";

        /// <summary>
        /// The PCPS URL
        /// </summary>
        public const string PcpsUrl = "https://www2.nuclea.com.br/SAP/Rela%C3%A7%C3%A3o%20de%20Participantes%20PCPS.pdf";
    }
}
