using Newtonsoft.Json;
using System.Collections.Generic;

namespace YetAnotherShrinker.Models
{
    public class RouteAnalyticsBundle
    {
        [JsonProperty("daySortedEvents")]
        public List<UrlRedirectEvent>[] DaySortedEvents { get; set; }

        [JsonProperty("daySpan")]
        public int DaySpan { get; set; }

        [JsonProperty("redirectEvents")]
        public IEnumerable<UrlRedirectEvent> RedirectEvents { get; set; }

        [JsonProperty("shrunkUrl")]
        public ShrunkUrl ShrunkUrl { get; set; }
    }
}