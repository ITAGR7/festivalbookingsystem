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




        public LoginResult GetLoginResult(string username, string password)
        {

            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(u => u.UserName, username),
                Builders<User>.Filter.Eq(u => u.Password, password)
            );
            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                return new LoginResult { IsValid = true, UserType = result.UserType };
            }
            return new LoginResult { IsValid = false, UserType = " " }; // use -1 or any other invalid value for RoleType
        }




        public List<User> GetAllUsers()
        {
            //GetAllUsers test on Repo

            return collection.Find(new BsonDocument()).ToList();

        }

        public User GetUserById(string id)
        {
            Console.WriteLine("Getuserbyid repo");

            User user = collection.Find<User>(i => i.UserName == id).FirstOrDefault();
            return user;
        }

        public string CreateUser(User newUser)
        {

            collection.InsertOne(newUser);
            return newUser.UserName;

        }

        // Metode sat til task bool, fordi den er async, fordi den skal returnere resultat af 
        //..updateoneasync metoden (validering)
        public async Task<bool> UpdateUser(User userUpdated)
        {

            
            // Her burde vi måske anvende user.ID fremfor username? I så fald skal det opdateres på client også
            var filter = Builders<User>.Filter.Eq(u => u.UserName, userUpdated.UserName);

            var update = Builders<User>.Update
                .Set(u => u.UserName, userUpdated.UserName)
                .Set(u => u.FirstName, userUpdated.FirstName)
                .Set(u => u.SurName, userUpdated.SurName)
                .Set(u => u.Address, userUpdated.Address)
                .Set(u => u.Zip, userUpdated.Zip)
                .Set(u => u.City, userUpdated.City)
                .Set(u => u.PhoneNumber, userUpdated.PhoneNumber)
                .Set(u => u.Email, userUpdated.Email)
                .Set(u => u.Password, userUpdated.Password);


   

            var result = await collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;


        }


    }
}

