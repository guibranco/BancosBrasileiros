namespace BancosBrasileiros
{
    using System;
    using Newtonsoft.Json;

    public class Bank
    {
        [JsonProperty("COMPE")]
        public string Compe { get; set; }

        [JsonProperty("ISPB")]
        public string Ispb { get; set; }

        [JsonProperty("Document")]
        public string Document { get; set; }

        [JsonProperty("LongName")]
        public string LongName { get; set; }

        [JsonProperty("ShortName")]
        public string ShortName { get; set; }

        [JsonProperty("Network")]
        public string Network { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("PixType")]
        public string PixType { get; set; }

        [JsonProperty("Charge")]
        public bool? Charge { get; set;}

        [JsonProperty("CreditDocument")]
        public bool? CreditDocument { get; set; }

        [JsonProperty("SalaryPortability")]
        public string SalaryPortability { get; set; }

        [JsonProperty("Products")]
        public string[] Products { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("DateOperationStarted")]
        public string DateOperationStarted { get; set; }

        [JsonProperty("DatePixStarted")]
        public string DatePixStarted { get; set; }

        [JsonProperty("DateRegistered")]
        public DateTimeOffset DateRegistered { get; set; }

        [JsonProperty("DateUpdated")]
        public DateTimeOffset DateUpdated { get; set; }
    }
}
