using Newtonsoft.Json;

namespace YetAnotherShrinker.Models
{
    public class ShrunkUrl : DatabaseObject
    {
        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("shrunkPath")]
        public string ShrunkPath { get; set; }
    }
}