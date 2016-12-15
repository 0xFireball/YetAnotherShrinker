using Newtonsoft.Json;
using System.Collections.Generic;

namespace YetAnotherShrinker.Models
{
    public class RouteAnalyticsBundle
    {
        [JsonProperty("redirectEvents")]
        public IEnumerable<UrlRedirectEvent> RedirectEvents { get; set; }

        [JsonProperty("shrunkUrl")]
        public ShrunkUrl ShrunkUrl { get; set; }
    }
}