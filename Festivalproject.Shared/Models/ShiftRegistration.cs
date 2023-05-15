using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Festivalproject.Shared.Models
{
    public class ShiftRegistration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = "";

        [BsonElement("UserId")]
        public string UserId { get; set; } = "";

        [BsonElement("Username")]
        public string Username { get; set; } = "";

        [BsonElement("startTime")]
        public DateTime startTime { get; set; }

        [BsonElement("endTime")]
        public DateTime endTime { get; set; }

    }
}
