using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Festivalproject.Shared.Models;

public class ShiftRegistration
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";

        [BsonElement("shiftId")]
        public string ShiftId { get; set; }


    [BsonElement("area")] public string Area { get; set; } = "";
    [BsonElement("userId")] public string UserId { get; set; } = "";

    [BsonElement("registrationDate")] public string RegistrationDate { get; set; } = "";

    [BsonElement("shiftName")] public string ShiftName { get; set; } = "";

    [BsonElement("description")] public string Description { get; set; }

    [BsonElement("startTime")] public DateTime StartTime { get; set; }

    [BsonElement("endTime")] public DateTime EndTime { get; set; }

    [BsonElement("type")] public DateTime ShiftType { get; set; }

    [BsonElement("duration")] public DateTime Duration { get; set; }



}