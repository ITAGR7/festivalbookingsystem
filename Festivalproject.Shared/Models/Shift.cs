using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Festivalproject.Shared.Models;

// Test udføres først med at der fås fat i et objekt id.
[BsonIgnoreExtraElements]
public class Shift
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";
    
    
    [BsonElement("name")]
    [Required]
    public string Name { get; set; }

    [Required]
    [BsonElement("type")] 

    public string Type { get; set; }
    

    [BsonElement("isOccupied")] 
    public bool Status { get; set; }


    [Required]
    [BsonElement("area")] 
    public string Area { get; set; }


    [Required]
    [BsonElement("description")]
    public string Description { get; set; } = "";

    [Required]
    [BsonElement("duration")]
    public int Duration { get; set; }


    [Required]
    [BsonElement("startTime")]
    public DateTime startTime { get; set; }


    [Required]
    [BsonElement("endTime")]
    public DateTime endTime { get; set; }

    public bool IsPriority { get; set; }

    
}
