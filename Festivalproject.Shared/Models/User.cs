using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;


namespace Festivalproject.Shared.Models;

public class User
{
    //Maps the "Id" property to MongoDbs _id field 
    // BsonType.ObjectId specifies that the property should be stored as an ObjectId (bsontype)
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";

    [Required(ErrorMessage = "Et fornavn er påkrævet")]
    [BsonElement("firstName")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Et efternavn er påkrævet")]
    [BsonElement("surName")]
    public string SurName { get; set; }


    [Required(ErrorMessage = "Et postnummer er påkrævet")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "Postnumer skal være præcis 4 cifre.")]
    [BsonElement("zip")]
    public int Zip { get; set; }


    [Required(ErrorMessage = "En by er påkrævet")]
    [BsonElement("city")]
    public string City { get; set; }

    [Required(ErrorMessage = "Et telefonnummer er påkrævet")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Telefonnummeret skal være præcis 8 cifre.")]
    [BsonElement("phone")]
    public int PhoneNumber { get; set; }

    [Required(ErrorMessage = "En adresse er påkrævet")]
    [BsonElement("address")]
    public string Address { get; set; }

    [Required(ErrorMessage = "En emailadresse er påkrævet")]
    [EmailAddress]
    [BsonElement("email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Et brugernavn er påkrævet")]
    [BsonElement("userName")]
    public string UserName { get; set; }

    // Setting password to private, making it unaccessible from outside the class 
    [Required(ErrorMessage = "Et kodeord er påkrævet")]
    [BsonElement("password")]
    public  string Password { get; set; }

    [Required(ErrorMessage = " er påkrævet")]
    [BsonElement("userType")]
    public string UserType { get; set; }



    //public void UpdatePassword(string newPassword)
    //{
    //    Password = newPassword;
    //}

}