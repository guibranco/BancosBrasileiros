// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 18/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-01-2022
// ***********************************************************************
// <copyright file="Bank.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Dto
{
    using CrispyWaffle.Extensions;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using CrispyWaffle.Validations;

    /// <summary>
    /// Class Bank.
    /// Implements the <see cref="IEquatable{Bank}" />
    /// </summary>
    /// <seealso cref="IEquatable{Bank}" />
    [XmlRoot("Bank")]
    [Serializable]
    public class Bank : IEquatable<Bank>
    {
        /// <summary>
        /// Gets or sets the COMPE.
        /// </summary>
        /// <value>The COMPE.</value>
        [JsonIgnore]
        [XmlIgnore]
        public int Compe { get; set; }

        /// <summary>
        /// Gets the COMPE string.
        /// </summary>
        /// <value>The COMPE string.</value>
        [JsonProperty("COMPE")]
        [XmlElement("COMPE")]
        public string CompeString
        {
            get => Compe.ToString("000");
            set
            {
                if (int.TryParse(value, out var parsed))
                    Compe = parsed;
            }
        }

        /// <summary>
        /// Gets or sets the ispb.
        /// </summary>
        /// <value>The ispb.</value>
        [JsonIgnore]
        [XmlIgnore]
        public int Ispb { get; set; }

        /// <summary>
        /// Gets or sets the ispb string.
        /// </summary>
        /// <value>The ispb string.</value>
        [JsonProperty("ISPB")]
        [XmlElement("ISPB")]
        public string IspbString
        {
            get => Ispb.ToString("00000000");
            set
            {
                if (int.TryParse(value, out var parsed))
                    Ispb = parsed;
            }
        }

        /// <summary>
        /// The document
        /// </summary>
        private string _document;

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        [JsonProperty("Document")]
        [XmlElement("Document")]
        public string Document
        {
            get => _document;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;
                var document = new string(value.Where(char.IsDigit).ToArray());
                if (document.Length == 8)
                {
                    if (document.Equals("00000000"))
                    {
                        document = "00000000000191";
                    }
                    else
                    {
                        document += "0001";
                        document += $"{document}00".CalculateBrazilianCorporationDocument();
                    }
                }

                _document = document.FormatBrazilianDocument();
            }
        }

        /// <summary>
        /// Gets or sets the long name.
        /// </summary>
        /// <value>The long name.</value>
        [JsonProperty("LongName")]
        [XmlElement("LongName")]
        public string LongName { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        [JsonProperty("ShortName")]
        [XmlElement("ShortName")]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the network.
        /// </summary>
        /// <value>The network.</value>
        [JsonProperty("Network")]
        [XmlElement("Network")]
        public string Network { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("Type")]
        [XmlElement("Type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the type of the pix.
        /// </summary>
        /// <value>The type of the pix.</value>
        [JsonProperty("PixType")]
        [XmlElement("PixType")]
        public string PixType { get; set; }

        /// <summary>
        /// Gets or sets the charge.
        /// </summary>
        /// <value>The charge.</value>
        [JsonProperty("Charge")]
        [XmlElement("Charge")]
        public string Charge { get; set; }

        /// <summary>
        /// Gets or sets the credit document.
        /// </summary>
        /// <value>The credit document.</value>
        [JsonProperty("CreditDocument")]
        [XmlElement("CreditDocument")]
        public string CreditDocument { get; set; }

        /// <summary>
        /// Gets or sets the salary portability.
        /// </summary>
        /// <value>The salary portability.</value>
        [JsonProperty("SalaryPortability")]
        [XmlElement("SalaryPortability")]
        public string SalaryPortability { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        [JsonProperty("Products")]
        [XmlElement("Products")]
        public string[] Products { get; set; }

        /// <summary>
        /// The URL
        /// </summary>
        private string _url;

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("Url")]
        [XmlElement("Url")]
        public string Url
        {
            get => _url;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Equals("NA"))
                    return;
                _url = $"https://{value.ToLower().Replace("https://", "")}";
            }
        }

        /// <summary>
        /// Gets or sets the date operation started.
        /// </summary>
        /// <value>The date operation started.</value>
        [JsonProperty("DateOperationStarted")]
        [XmlElement("DateOperationStarted")]
        public string DateOperationStarted { get; set; }

        /// <summary>
        /// Gets or sets the date pix started.
        /// </summary>
        /// <value>The date pix started.</value>
        [JsonProperty("DatePixStarted")]
        [XmlElement("DatePixStarted")]
        public string DatePixStarted { get; set; }

        /// <summary>
        /// Gets or sets the date registered.
        /// </summary>
        /// <value>The date registered.</value>
        [JsonProperty("DateRegistered")]
        [XmlElement("DateRegistered")]
        public DateTimeOffset? DateRegistered { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        /// <value>The date updated.</value>
        [JsonProperty("DateUpdated")]
        [XmlElement("DateUpdated")]
        public DateTimeOffset? DateUpdated { get; set; }

        #region Equality members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(Bank other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(_document, other._document, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(_url, other._url, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(Charge, other.Charge, StringComparison.InvariantCultureIgnoreCase) &&
                   Compe == other.Compe &&
                   string.Equals(CreditDocument, other.CreditDocument, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(DateOperationStarted, other.DateOperationStarted, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(DatePixStarted, other.DatePixStarted, StringComparison.InvariantCultureIgnoreCase) &&
                   Nullable.Equals(DateRegistered, other.DateRegistered) &&
                   Nullable.Equals(DateUpdated, other.DateUpdated) && Ispb == other.Ispb &&
                   string.Equals(LongName, other.LongName, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(Network, other.Network, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(PixType, other.PixType, StringComparison.InvariantCultureIgnoreCase) &&
                   Equals(Products, other.Products) &&
                   string.Equals(SalaryPortability, other.SalaryPortability, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(ShortName, other.ShortName, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(Type, other.Type, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() == GetType() && Equals((Bank)obj);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(_document ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(_url ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(Charge ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(Compe);
            hashCode.Add(CreditDocument ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(DateOperationStarted ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(DatePixStarted ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(DateRegistered);
            hashCode.Add(DateUpdated);
            hashCode.Add(Ispb);
            hashCode.Add(LongName ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(Network ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(PixType ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(Products);
            hashCode.Add(SalaryPortability ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(ShortName ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(Type ?? string.Empty, StringComparer.InvariantCultureIgnoreCase);
            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            if (Ispb > 0 || Compe.Equals(1))
                strBuilder.AppendFormat("ISPB: {0} | ", IspbString);

            if (!string.IsNullOrWhiteSpace(Document))
                strBuilder.AppendFormat("Document: {0} | ", Document);

            if (!string.IsNullOrWhiteSpace(LongName))
                strBuilder.AppendFormat("Long name: {0} | ", LongName);

            if (!string.IsNullOrWhiteSpace(ShortName))
                strBuilder.AppendFormat("Short name: {0} | ", ShortName);

            if (!string.IsNullOrWhiteSpace(Network))
                strBuilder.AppendFormat("Network: {0} | ", Network);

            if (!string.IsNullOrWhiteSpace(Type))
                strBuilder.AppendFormat("Type: {0} | ", Type);

            if (!string.IsNullOrWhiteSpace(PixType))
                strBuilder.AppendFormat("PIX type: {0} | ", PixType);

            if (!string.IsNullOrWhiteSpace(DateOperationStarted))
                strBuilder.AppendFormat("Date operation started: {0} | ", DateOperationStarted);

            if (!string.IsNullOrWhiteSpace(DatePixStarted))
                strBuilder.AppendFormat("Date PIX started: {0} | ", DatePixStarted);

            strBuilder.AppendFormat("Date registered: {0:O} | Date updated: {1:O}", DateRegistered, DateUpdated);

            return strBuilder.ToString();
        }

        /// <summary>
        /// Returns a value that indicates whether the values of two <see cref="T:BancosBrasileiros.MergeTool.Dto.Bank" /> objects are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>true if the <paramref name="left" /> and <paramref name="right" /> parameters have the same value; otherwise, false.</returns>
        public static bool operator ==(Bank left, Bank right) => Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether two <see cref="T:BancosBrasileiros.MergeTool.Dto.Bank" /> objects have different values.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, false.</returns>
        public static bool operator !=(Bank left, Bank right) => !Equals(left, right);

        #endregion
    }
}