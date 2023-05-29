using MongoDB.Bson;
using MongoDB.Driver;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Festivalproject.Server.Repository;

public class ShiftRepository : IShifts
{
    private const string connectionString = @"mongodb+srv://admin:LgyyJ6R8qFXcQgtg@festivalcluster0.wn5s5bo.mongodb.net/";

    private const string databaseName = "festivalData";
    private const string collectionName = "Shifts";
    private IMongoCollection<Shift> collection;



    // Initializes the ShiftRepository by connecting to the MongoDB database using the provided connection string and database name.
    // Retrieves the collection of Shifts objects from the database.
    public ShiftRepository()
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        collection = database.GetCollection<Shift>(collectionName);
    }

    // Retrieves all shifts from the collection and returns them as a list. Uses a query to find all documents in the collection.
    // Returns the list of shifts.
        public List<Shift> GetAllShifts()
        {
            //return await collection.Find(i => true).ToListAsync();
            var shifts = collection.Find(new BsonDocument()).ToList();
            return shifts;
        }

    // Retrieves shifts from the collection based on the given status.Uses a query to find documents where the Status field matches the provided status.
    //  Returns the list of shifts with the matching status
    public List<Shift> GetShiftsByStatus(bool status)
        {
            return collection.Find(i => i.Status == status).ToList();
        }

        // Inserts a new shift document into the collection. Returns the newly created shift
        public async Task<Shift> CreateShift(Shift newShift)
        {
           collection.InsertOne(newShift);
           return newShift;
        
        }


    // Updates a shift document in the collection with the provided shiftUpdated object
    // Sets the fields of the shift document to the corresponding values from the shiftUpdated object. Returns the updated shift.
    public async Task<Shift> UpdateShift(Shift shiftUpdated)
        {
              Console.WriteLine("Updateshift test repo " + shiftUpdated.Id);


            var filter = Builders<Shift>.Filter.Eq(u => u.Id, shiftUpdated.Id);
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

    // Updates the status of a shift document in the collection based on the given shift ID. Sets the Status field of the shift document to the provided status.
    // Returns a boolean indicating whether the update was successful.
        public async Task<bool> UpdateShiftStatusByShiftId(string Id, bool Status)
        {
            var filter = Builders<Shift>.Filter.Eq(u => u.Id, Id);

            var update = Builders<Shift>.Update
                .Set(u => u.Status, Status);

            var updateResult = await collection.UpdateOneAsync(filter, update);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

    // deletes a shift document from the collection based on the given shift ID.
    public async Task<bool> DeleteShift(string id)
        {
            var result = await collection.DeleteOneAsync(s => s.Id == id);
            if (result.DeletedCount > 0) return true;
            return false;
        }
}