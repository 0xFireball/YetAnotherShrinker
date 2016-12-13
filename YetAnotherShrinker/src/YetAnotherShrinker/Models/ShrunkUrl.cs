using LiteDB;
using Newtonsoft.Json;

namespace YetAnotherShrinker.Models
{
    public class ShrunkUrl
    {
        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("shrunkPath")]
        public string ShrunkPath { get; set; }
        
        [JsonIgnore]
        [BsonId]
        public ObjectId DatabaseId { get; set; }
    }
}
