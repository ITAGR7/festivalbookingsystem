using MongoDB.Bson;
using MongoDB.Driver;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Festivalproject.Server.Repository;

public class ShiftRepository : IShifts
{
    private const string connectionString =
        @"mongodb+srv://admin:LgyyJ6R8qFXcQgtg@festivalcluster0.wn5s5bo.mongodb.net/";

    private const string databaseName = "festivalData";
    private const string collectionName = "Shifts";
    private IMongoCollection<Shift> collection;

    public ShiftRepository()
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        collection = database.GetCollection<Shift>(collectionName);
    }


    public List<Shift> GetAllShifts()
    {
        try
        {
            var shifts = collection.Find(new BsonDocument()).ToList();
            return shifts;
        }
        catch (Exception ex)
        {

            Console.WriteLine("An error occurred while retrieving shifts: " + ex.Message);
            return new List<Shift>(); // Return an empty list or default value
        }
    }

    public List<Shift> GetShiftsByStatus(bool status)
    {
        try
        {
            return collection.Find(i => i.Status == status).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while retrieving shifts by status: " + ex.Message);
            return new List<Shift>(); // Return an empty list or default value
        }
    }

    public async Task<Shift> CreateShift(Shift newShift)
    {
        try
        {
            collection.InsertOne(newShift);
            return newShift;
        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log the error, throw a custom exception, etc.)
            Console.WriteLine("An error occurred while creating a shift: " + ex.Message);
            throw; // Rethrow the exception or throw a custom exception
        }
    }



    public async Task<Shift> UpdateShift(Shift shiftUpdated)
    {
        try
        {
            Console.WriteLine("Updateshift test repo " + shiftUpdated.Id);

            var filter = Builders<Shift>.Filter.Eq(u => u.Id, shiftUpdated.Id);

            //DateTime startTimeUtc = shiftUpdated.startTime.ToUniversalTime();
            //DateTime endTimeUtc = shiftUpdated.endTime.ToUniversalTime();

            var update = Builders<Shift>.Update
                .Set(u => u.Name, shiftUpdated.Name)
                .Set(u => u.startTime, shiftUpdated.startTime)
                .Set(u => u.endTime, shiftUpdated.endTime)
                .Set(u => u.Description, shiftUpdated.Description)
                .Set(u => u.Duration, shiftUpdated.Duration)
                .Set(u => u.Type, shiftUpdated.Type)
                .Set(u => u.Status, shiftUpdated.Status)
                .Set(u => u.Area, shiftUpdated.Area);

            var result = await collection.UpdateOneAsync(filter, update);

            return shiftUpdated;
        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log the error, throw a custom exception, etc.)
            Console.WriteLine("An error occurred while updating a shift: " + ex.Message);
            throw; // Rethrow the exception or throw a custom exception
        }
    }

    public async Task<bool> UpdateShiftStatusByShiftId(string Id, bool Status)
    {
        try
        {
            var filter = Builders<Shift>.Filter.Eq(u => u.Id, Id);

            var update = Builders<Shift>.Update
                .Set(u => u.Status, Status);

            var updateResult = await collection.UpdateOneAsync(filter, update);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while updating shift status: " + ex.Message);
            throw; 
        }
    }


    public async Task<bool> DeleteShift(string id)
    {
        try
        {
            var result = await collection.DeleteOneAsync(s => s.Id == id);
            return result.DeletedCount > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while deleting a shift: " + ex.Message);
            throw; 
        }
    }
}