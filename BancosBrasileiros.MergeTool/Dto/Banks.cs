// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 18/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-01-2022
// ***********************************************************************
// <copyright file="Banks.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Dto
{
    using System.Xml.Serialization;

    /// <summary>
    /// Class Banks.
    /// </summary>
    [XmlRoot("banks")]
    public class Banks
    {
        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        /// <value>The bank.</value>
        [XmlElement("bank")]
        public Bank[] Bank { get; set; }
    }
}