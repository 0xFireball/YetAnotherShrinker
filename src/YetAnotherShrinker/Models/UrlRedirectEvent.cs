using Newtonsoft.Json;
using System;

namespace YetAnotherShrinker.Models
{
    public class UrlRedirectEvent
    {
        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("shrunkUrl")]
        public ShrunkUrl ShrunkUrl { get; set; }

        [JsonProperty("clientAddress")]
        public string ClientAddress { get; set; }

        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}