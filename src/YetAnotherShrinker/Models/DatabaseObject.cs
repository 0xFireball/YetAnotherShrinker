using LiteDB;
using Newtonsoft.Json;

namespace YetAnotherShrinker.Models
{
    public class DatabaseObject
    {
        [JsonIgnore]
        [BsonId]
        public ObjectId DatabaseId { get; set; }
    }
}