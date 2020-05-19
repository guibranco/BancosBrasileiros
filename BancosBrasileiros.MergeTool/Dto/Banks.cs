// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 18/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 19/05/2020
// ***********************************************************************
// <copyright file="Banks.cs" company="BancosBrasileiros.MergeTool">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Xml.Serialization;

namespace BancosBrasileiros.MergeTool.Dto
{
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