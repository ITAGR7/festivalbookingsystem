using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
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
                Builders<User>.Filter.Eq(u => u.UserName, username), 
                Builders<User>.Filter.Eq(u => u.Password, password)
            );
            //applies the filter with a find method 
            var result = collection.Find(filter).FirstOrDefault();

            //Returns a LoginResultDTO with the UserType and ObjectId from the matching User document if found otherwise, returns no match.
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


    //Retrieves all users from the database. Returns list of User objects.
    public List<User> GetAllUsers()
    {
        try
        {
            return collection.Find(new BsonDocument()).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured trying to retrieve users.", ex);
        }
    }


    //Retrieves a user from the database based on the provided ObjectId. Returns matching User object if found. if not, returns null.
    public User GetUserByObjectId(string id)
    {
        try
        {
            var user = collection.Find<User>(i => i.Id == id).FirstOrDefault();
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured trying go tet user by Objectid.", ex);
        }
    }


    //reates new user to the database. checks username already exists and throws exception if yes. if not, new user document inserts into user collection.
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


    // updates existing user in database with userUpdated object. Checks user's ObjectId to identify the document to update. Updates fields in document from userUpdatedObject.
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

            Console.WriteLine($"An error occured trying to update the user: {ex.Message}");
            return null;
        }
    }
}