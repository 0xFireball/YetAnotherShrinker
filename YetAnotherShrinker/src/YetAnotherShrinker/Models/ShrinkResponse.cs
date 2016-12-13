using Newtonsoft.Json;

namespace YetAnotherShrinker.Models
{
    public class ShrinkResponse
    {
        [JsonProperty("shrunkUrl")]
        public ShrunkUrl ShrunkUrl { get; set; }
    }
}
