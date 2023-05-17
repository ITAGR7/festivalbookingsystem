using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Festivalproject.Shared.Models
{
    // Test udføres først med at der fås fat i et objekt id.
    [BsonIgnoreExtraElements]
    public class Shifts
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; } = "";


        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("area")]
        public string Area { get; set; }

        [BsonElement("isOccupied")]
        public bool Status { get; set; }

        [BsonElement("description")]
        public string Description { get; set; } = "";

        [BsonElement("capacity")]
        public int Capacity { get; set; }

        [BsonElement("duration")]
        public int Duration { get; set; }

        [BsonElement("startTime")]
        public DateTime startTime { get; set; }

        [BsonElement("endTime")]
        public DateTime endTime { get; set; }

    }
}
