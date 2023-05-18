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




        public LoginResultDTO GetLoginResult(string username, string password)
        {

            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(u => u.UserName, username),//Husk at ændre til username 
                Builders<User>.Filter.Eq(u => u.Password, password)
            );
            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                return new LoginResultDTO { IsValid = true, UserType = result.UserType, ObjectId = result.Id };
            }
            return new LoginResultDTO { IsValid = false, UserType = " ", ObjectId = " " }; // use -1 or any other invalid value for RoleType
        }





        public List<User> GetAllUsers()
        {
            //GetAllUsers test on Repo

            return collection.Find(new BsonDocument()).ToList();

        }

        public User GetUserByObjectId(string id)
        {
            Console.WriteLine("Getuserbyid repo");

            User user = collection.Find<User>(i => i.Id == id).FirstOrDefault();
            return user;
        }

        public User CreateUser(User newUser)
        {
            

            var userExist = collection.Find(u => u.UserName == newUser.UserName).FirstOrDefault();

            if(userExist!= null) 
            {
                throw new Exception("Brugernavn eksisterer allerede");
            }
            else
            {
             collection.InsertOne(newUser);
             return newUser;

            }
           

        }





        // Metode sat til task bool, fordi den er async, fordi den skal returnere resultat af 
        //..updateoneasync metoden (validering)
        public async Task<bool> UpdateUser(User userUpdated)
        {

            var filter = Builders<User>.Filter.Eq(u => u.Id, userUpdated.Id);

            var update = Builders<User>.Update
                .Set(u => u.UserName, userUpdated.UserName)
                .Set(u => u.FirstName, userUpdated.FirstName)
                .Set(u => u.SurName, userUpdated.SurName)
                .Set(u => u.Address, userUpdated.Address)
                .Set(u => u.Zip, userUpdated.Zip)
                .Set(u => u.City, userUpdated.City)
                .Set(u => u.PhoneNumber, userUpdated.PhoneNumber)
                .Set(u => u.Email, userUpdated.Email)
                .Set(u => u.Password, userUpdated.Password)
                .Set(u => u.Id, userUpdated.Id); 




            var result = await collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;


        }

    }

    
}

