using Festivalproject.Server.Interface;
using Festivalproject.Shared.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Festivalproject.Server.Repository
{
    public class UserRepository : IUser
    {


        private const string connectionString = @"mongodb+srv://admin:LgyyJ6R8qFXcQgtg@festivalcluster0.wn5s5bo.mongodb.net/";
        private const string databaseName = "festivalData";
        private const string collectionName = "Users";
        private IMongoCollection<User> collection;

        public UserRepository()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<User>(collectionName);
        }


        public bool IsValidLogin(string username, string password)
        {
            Console.WriteLine("isvalidlogin repo");

            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(u => u.UserName, username),
                Builders<User>.Filter.Eq(u => u.Password, password)
            );
            var result = collection.Find(filter).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            return false;

        }

        public List<User> GetAllUsers()
        {
            //GetAllUsers test on Repo

            return collection.Find(new BsonDocument()).ToList();

        }

        public string CreateUser(User newUser)
        {

            collection.InsertOne(newUser);
            return newUser.UserName;

        }

        //public UpdateUser(User user)
        //{

        //}


    }


}

