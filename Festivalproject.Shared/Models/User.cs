﻿using System;
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

        
        [BsonElement("firstName")]
        public string FirstName { get; set; }


        [BsonElement("surName")]
        public string SurName { get; set; }



        [BsonElement("zip")]
         public int Zip{ get; set; }



        [BsonElement("city")]
        public string City { get; set; }



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

        [BsonElement("userType")]
        public string UserType { get; set; }

        //[BsonElement("volunteerId")]
        //public string VolunteerId { get; set; }







    }
}
