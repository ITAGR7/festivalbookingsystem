using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace Festivalproject.Server.Repository;

public class UserRepository : IUser
{
    private const string connectionString =
        @"mongodb+srv://admin:LgyyJ6R8qFXcQgtg@festivalcluster0.wn5s5bo.mongodb.net/";

    private const string databaseName = "festivalData";
    private const string collectionName = "Users";
    private IMongoCollection<User> collection;



    //Initializes the UserRepository by connecting to the MongoDB database using the provided connection string and database name.
    // Retrieves the collection of User objects from the database.
    public UserRepository()
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        collection = database.GetCollection<User>(collectionName);
    }





    // Retrieves a LoginResultDTO based on the provided username and password.
    public LoginResultDTO GetLoginResult(string username, string password)
    {
        try
        {
             // Builds a filter to match the username and password in the database.
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(u => u.UserName, username), // Husk at ændre til username 
                Builders<User>.Filter.Eq(u => u.Password, password)
            );
            //applying the filter with a find method 
            var result = collection.Find(filter).FirstOrDefault();

            //Returns a LoginResultDTO with the UserType and ObjectId from the matching User document if found; otherwise, returns a LoginResultDTO indicating no match.
            if (result != null)
                return new LoginResultDTO { IsValid = true, UserType = result.UserType, ObjectId = result.Id };
            else { 
                return new LoginResultDTO { IsValid = false, UserType = " ", ObjectId = " " };
            }
               
        }
        catch (Exception ex)
        {        
            Console.WriteLine($"Der opstod en fejl under login: {ex.Message}");
            return new LoginResultDTO { IsValid = false, UserType = " ", ObjectId = " " };
        }

    }


    //Retrieves all users from the database. Returns list of User objects.
    public List<User> GetAllUsers()
    {
        try
        {
            return collection.Find(new BsonDocument()).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Fejl ved hentning af alle brugere.", ex);
        }
    }


    //Retrieves a user from the database based on the provided ObjectId. Returns the matching User object if found; otherwise, returns null.
    public User GetUserByObjectId(string id)
    {
        try
        {
            var user = collection.Find<User>(i => i.Id == id).FirstOrDefault();
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception("Fejl ved hentning af bruger ved ObjectId.", ex);
        }
    }


    //Method that creates a new user to the database. The method checks sername already exists and throws an exception if it does. Else it a new user document into user collection.
    public User CreateUser(User newUser)
    {
        var userExist = collection.Find(u => u.UserName == newUser.UserName).FirstOrDefault();

        if (userExist != null)
        {
            throw new Exception("Brugernavn eksisterer allerede");
        }
        else
        {
            collection.InsertOne(newUser);
            return newUser;
        }
    }


    // Updates an existing user in the database with the provided userUpdated object. Uses the user's ObjectId to identify the document to update.
    // Sets the fields of the user document to the corresponding values from the userUpdated object.
    public  Task<UpdateResult> UpdateUser(User userUpdated)
    {
        try
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, userUpdated.Id);

            var update = Builders<User>.Update
                .Set(u => u.UserName, userUpdated.UserName)
                .Set(u => u.Password, userUpdated.Password)
                .Set(u => u.FirstName, userUpdated.FirstName)
                .Set(u => u.SurName, userUpdated.SurName)
                .Set(u => u.Address, userUpdated.Address)
                .Set(u => u.Zip, userUpdated.Zip)
                .Set(u => u.City, userUpdated.City)
                .Set(u => u.PhoneNumber, userUpdated.PhoneNumber)
                .Set(u => u.Email, userUpdated.Email)
                .Set(u => u.Id, userUpdated.Id);

            var result = collection.UpdateOneAsync(filter, update);
            return result;
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Der opstod en fejl under opdatering af brugeren: {ex.Message}");
            return null;
        }
    }
}