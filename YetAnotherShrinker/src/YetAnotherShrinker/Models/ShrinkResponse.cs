using Newtonsoft.Json;

namespace YetAnotherShrinker.Models
{
    public class ShrinkResponse
    {
        [JsonProperty("shrunkUrl")]
        public string ShrunkUrl { get; set; }
    }
}
