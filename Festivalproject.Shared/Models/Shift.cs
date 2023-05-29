using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Festivalproject.Shared.Models;
// We are using MongoDB drivers mapping function, to map our modelclasses fields to the database fields, if these do not match
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