// ***********************************************************************
// Assembly         : BancosBrasileiros.MergeTool
// Author           : Guilherme Branco Stracini
// Created          : 18/05/2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 04-27-2021
// ***********************************************************************
// <copyright file="Bank.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BancosBrasileiros.MergeTool.Dto
{
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Class Bank.
    /// Implements the <see cref="IEquatable{Bank}" />
    /// </summary>
    /// <seealso cref="IEquatable{Bank}" />
    [XmlRoot("Bank")]
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
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        [JsonProperty("Document")]
        [XmlElement("Document")]
        public string Document { get; set; }

        /// <summary>
        /// Gets or sets the name of the fiscal.
        /// </summary>
        /// <value>The name of the fiscal.</value>
        [JsonProperty("FiscalName")]
        [XmlElement("FiscalName")]
        public string FiscalName { get; set; }

        /// <summary>
        /// Gets or sets the name of the fantasy.
        /// </summary>
        /// <value>The name of the fantasy.</value>
        [JsonProperty("FantasyName")]
        [XmlElement("FantasyName")]
        public string FantasyName { get; set; }

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
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("Url")]
        [XmlElement("Url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the date operation started.
        /// </summary>
        /// <value>The date operation started.</value>
        [JsonProperty("DateOperationStarted")]
        [XmlElement("DateOperationStarted")]
        public string DateOperationStarted { get; set; }

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

        /// <summary>
        /// Gets or sets the date removed.
        /// </summary>
        /// <value>The date removed.</value>
        [JsonProperty("DateRemoved")]
        [XmlElement("DateRemoved")]
        public DateTimeOffset? DateRemoved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is removed.
        /// </summary>
        /// <value><c>true</c> if this instance is removed; otherwise, <c>false</c>.</value>
        [JsonProperty("IsRemoved")]
        [XmlIgnore]
        public bool IsRemoved { get; set; }

        /// <summary>
        /// Gets or sets the is removed XML.
        /// </summary>
        /// <value>The is removed XML.</value>
        [JsonIgnore]
        [XmlElement("IsRemoved")]
        public string IsRemovedXml
        {
            get => IsRemoved.ToString();
            set => IsRemoved = value.Equals("true", StringComparison.InvariantCultureIgnoreCase);
        }

        #region Equality members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(Bank other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;


            return
                Compe == other.Compe &&
                Ispb == other.Ispb &&
                string.Equals(Document, other.Document, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(FiscalName, other.FiscalName, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(FantasyName, other.FantasyName, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Network, other.Network, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Type, other.Type, StringComparison.InvariantCultureIgnoreCase) &&//    
                string.Equals(Url, other.Url, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(DateOperationStarted, other.DateOperationStarted, StringComparison.InvariantCultureIgnoreCase) &&
                Nullable.Equals(DateRegistered, other.DateRegistered) &&
                Nullable.Equals(DateUpdated, other.DateUpdated) &&
                Nullable.Equals(DateRemoved, other.DateRemoved) &&
                IsRemoved == other.IsRemoved;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Bank)obj);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Compe);
            hashCode.Add(Ispb);
            hashCode.Add(Document ?? string.Empty, StringComparer.CurrentCultureIgnoreCase);
            hashCode.Add(FiscalName, StringComparer.CurrentCultureIgnoreCase);
            hashCode.Add(FantasyName, StringComparer.CurrentCultureIgnoreCase);
            hashCode.Add(Network ?? string.Empty, StringComparer.CurrentCultureIgnoreCase);
            hashCode.Add(Type ?? string.Empty, StringComparer.CurrentCultureIgnoreCase);
            hashCode.Add(Url ?? string.Empty, StringComparer.CurrentCultureIgnoreCase);
            hashCode.Add(DateOperationStarted ?? string.Empty, StringComparer.CurrentCultureIgnoreCase);
            hashCode.Add(DateRegistered);
            hashCode.Add(DateUpdated);
            hashCode.Add(DateRemoved);
            hashCode.Add(IsRemoved);
            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            if (Ispb > 0)
                strBuilder.AppendFormat("ISPB: {0} | ", Ispb);

            if (!string.IsNullOrWhiteSpace(Document))
                strBuilder.AppendFormat("Document: {0} | ", Document);

            if (!string.IsNullOrWhiteSpace(FiscalName))
                strBuilder.AppendFormat("Fiscal name: {0} | ", FiscalName);

            if (!string.IsNullOrWhiteSpace(FantasyName))
                strBuilder.AppendFormat("Fantasy name: {0} | ", FantasyName);

            if (!string.IsNullOrWhiteSpace(Network))
                strBuilder.AppendFormat("Network: {0} | ", Network);

            if (!string.IsNullOrWhiteSpace(Type))
                strBuilder.AppendFormat("Type: {0} | ", Type);

            if (!string.IsNullOrWhiteSpace(DateOperationStarted))
                strBuilder.AppendFormat("Date operation started: {0} | ", DateOperationStarted);

            strBuilder.AppendFormat(
                "Date registered: {0:O} | Date updated: {1:O} | Date removed: {2:O} | Is removed: {3}", DateRegistered,
                DateUpdated, DateRemoved, IsRemoved);

            return strBuilder.ToString();
        }

        /// <summary>
        /// Returns a value that indicates whether the values of two <see cref="T:BancosBrasileiros.MergeTool.Dto.Bank" /> objects are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>true if the <paramref name="left" /> and <paramref name="right" /> parameters have the same value; otherwise, false.</returns>
        public static bool operator ==(Bank left, Bank right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Returns a value that indicates whether two <see cref="T:BancosBrasileiros.MergeTool.Dto.Bank" /> objects have different values.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, false.</returns>
        public static bool operator !=(Bank left, Bank right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}