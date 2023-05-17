using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;


namespace Festivalproject.Shared.Models
{
    public class User
    {
        //Maps the "Id" property to MongoDbs _id field 
        // BsonType.ObjectId specifies that the property should be stored as an ObjectId (bsontype)
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [Required]
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [Required]
        [BsonElement("surName")]
        public string SurName { get; set; }


        [Required]
        [BsonElement("zip")]
         public int Zip{ get; set; }


        [Required]
        [BsonElement("city")]
        public string City { get; set; }

        [Required]
        [BsonElement("phone")]
        public int PhoneNumber { get; set; }

        [Required]
        [BsonElement("address")]
        public string Address { get; set; }

        [Required]
        [BsonElement("email")]
        public string Email { get; set; }

        [Required]
        [BsonElement("userName")]
        public string UserName { get; set; }

        [Required]
        [BsonElement("password")]
        public string Password { get; set; }

        [Required]
        [BsonElement("userType")]
        public string UserType { get; set; }

        //[BsonElement("volunteerId")]
        //public string VolunteerId { get; set; }







    }
}
