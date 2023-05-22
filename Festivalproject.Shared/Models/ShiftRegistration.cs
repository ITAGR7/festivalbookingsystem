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


    [BsonElement("shiftArea")]
    public string Area { get; set; } = "";
    [BsonElement("userId")]
    public string UserId { get; set; } = "";


    [BsonElement("registrationDate")]
    public DateTime RegistrationDate { get; set; }

    [BsonElement("shiftName")]
    public string ShiftName { get; set; } = "";

    [BsonElement("shiftDescription")]
    public string Description { get; set; }

    [BsonElement("startTime")]
    public DateTime StartTime { get; set; }

    [BsonElement("endTime")]
    public DateTime EndTime { get; set; }

    [BsonElement("shiftType")]
   
    public string ShiftType { get; set; }

    [BsonElement("shiftDuration")]
    public int Duration { get; set; }



}