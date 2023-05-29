using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Festivalproject.Server.Repository;

public class UserRepository : IUser
{
    private const string connectionString =
        @"mongodb+srv://admin:LgyyJ6R8qFXcQgtg@festivalcluster0.wn5s5bo.mongodb.net/";

    private const string databaseName = "festivalData";
    private const string collectionName = "Users";
    private IMongoCollection<User> collection;

    public UserRepository()
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        collection = database.GetCollection<User>(collectionName);
    }




    //Method for checking is user exists in database, and returning a loginresult object 
    public LoginResultDTO GetLoginResult(string username, string password)
    {
        try
        {  // building a filter for matches in database
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(u => u.UserName, username), // Husk at ændre til username 
                Builders<User>.Filter.Eq(u => u.Password, password)
            );
            //applying the filter with a find method 
            var result = collection.Find(filter).FirstOrDefault();

            //if match is found, we return a loginresult object, with isvalid = true, usertype and ObjectId
            if (result != null)
                return new LoginResultDTO { IsValid = true, UserType = result.UserType, ObjectId = result.Id };
            else { 
                return new LoginResultDTO { IsValid = false, UserType = " ", ObjectId = " " };
            }
               
        }
        catch (Exception ex)
        {        
            Console.WriteLine($"An Error occured while trying to get loginresult: {ex.Message}");
            return new LoginResultDTO { IsValid = false, UserType = " ", ObjectId = " " };
        }

    }


    //Method that retrieves all users from database 
    public List<User> GetAllUsers()
    {
        try
        {
            return collection.Find(new BsonDocument()).ToList();
        }
        catch (Exception ex)
        {
            // Håndter exception her eller kast den videre
            throw new Exception("An error occured trying to retrieve users.", ex);
        }
    }


    //Method that gets user by MongoDbs object id 
    public User GetUserByObjectId(string id)
    {
        try
        {
            var user = collection.Find<User>(i => i.Id == id).FirstOrDefault();
            return user;
        }
        catch (Exception ex)
        {
            // Håndter exception her eller kast den videre
            throw new Exception("An error occured trying go tet user by Objectid.", ex);
        }
    }


    //Method that creates a new user to the database. The method checks if the input username from the new user already exists 
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


    // Async method that awaits updateonasync method, with the updater variables for the user object 
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

            Console.WriteLine($"An errr occured trying to update the user: {ex.Message}");
            return null;
        }
    }
}