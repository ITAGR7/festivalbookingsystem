using MongoDB.Bson;
using MongoDB.Driver;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Interface;
using System.Xml.Linq;


namespace Festivalproject.Server.Repository;

public class ShiftRegistrationRepository : IShiftRegistration
{ 
    private const string connectionString =@"mongodb+srv://admin:LgyyJ6R8qFXcQgtg@festivalcluster0.wn5s5bo.mongodb.net/";
    private const string databaseName = "festivalData";
    private const string collectionName = "ShiftRegistration";
   
    
    private IMongoCollection<ShiftRegistration> collection;


    // Initializes the ShiftRegistrationRepository by connecting MongoDB database with provided connection string and database name.
    // Collects the collection of ShiftRegistration objects from the database.
    public ShiftRegistrationRepository()
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        collection = database.GetCollection<ShiftRegistration>(collectionName);
    }

    //gets a list of ShiftRegistration objects by searching for registrations with UserId from collection. 
    public List<ShiftRegistration> GetRegisteredShiftsById(string UserId)
    {
        try
        {
            return collection.Find(sr => sr.UserId == UserId).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while retrieving registered shifts by user ID: " + ex.Message);
            return new List<ShiftRegistration>(); // Return an empty list or default value
        }
    }


    // Inserts a new ShiftRegistration object in collection.
    public async Task<bool> CreateShiftRegistration(ShiftRegistration shiftRegistration)
    {
        try
        {
            await collection.InsertOneAsync(shiftRegistration);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating a shift registration: " + ex.Message);
            throw; // Rethrow the exception or throw a custom exception
        }
    }


    // Updates ShiftRegistration objects where a matching ShiftId is found in the collection.
    // ShiftName, StartTime, EndTime, and Description gets updated by values from shift object
    public async Task<bool> UpdateShiftRegistrationByShiftId(Shift _shift)
    {
        try
        {
            var filter = Builders<ShiftRegistration>.Filter.Eq(u => u.ShiftId, _shift.Id);

            var update = Builders<ShiftRegistration>.Update
                .Set(u => u.ShiftName, _shift.Name)
                .Set(u => u.StartTime, _shift.startTime)
                .Set(u => u.EndTime, _shift.endTime)
                .Set(u => u.Description, _shift.Description);

            var result = await collection.UpdateManyAsync(filter, update);

            return result.ModifiedCount > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while updating shift registration: " + ex.Message);
            throw; 
        }
    }
}