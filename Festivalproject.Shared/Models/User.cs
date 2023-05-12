using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Festivalproject.Shared.Models
{
    public class User
    {
        //Maps the "Id" property to MongoDbs _id field 
        // BsonType.ObjectId specifies that the property should be stored as an ObjectId (bsontype)
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";


        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("phone")]
        public int PhoneNumber { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("userName")]

        public string UserName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        //[BsonElement("volunteerId")]
        //public string VolunteerId { get; set; }







    }
}
