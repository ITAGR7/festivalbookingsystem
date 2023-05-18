using MongoDB.Bson;
using MongoDB.Driver;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Interface;


namespace Festivalproject.Server.Repository;

public class ShiftRegistrationRepository : IShiftRegistration
{
    private const string connectionString =
        @"mongodb+srv://admin:LgyyJ6R8qFXcQgtg@festivalcluster0.wn5s5bo.mongodb.net/";

    private const string databaseName = "festivalData";
    private const string collectionName = "ShiftRegistration";
    private IMongoCollection<ShiftRegistration> collection;

    public ShiftRegistrationRepository()
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        collection = database.GetCollection<ShiftRegistration>(collectionName);
    }


    public List<ShiftRegistration> GetRegisteredShiftsById(string UserId)
    {
        //return await collection.Find(i => true).ToListAsync();
        return collection.Find(new BsonDocument()).ToList();
    }

    public void CreateShiftRegistration(ShiftRegistration shiftregistration)
    {
        collection.InsertOne(shiftregistration);
    }


    // Id anvendes ikke i denne og der manglede et filter 

    //public List<ShiftRegistration> GetRegisteredShiftsById(string UserId)
    //{
    //    //return await collection.Find(i => true).ToListAsync();
    //   


    //    var result = collection.Find(new BsonDocument()).ToList();
    //    Console.WriteLine("Test Get registered" + result.Count);
    //    return result; 
    //}
}