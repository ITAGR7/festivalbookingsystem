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


    
    public async Task<bool> CreateShiftRegistration(ShiftRegistration shiftRegistration)
    {
        await collection.InsertOneAsync(shiftRegistration);
        return true;
    }


    public async Task<bool> UpdateShiftRegistrationByShiftId(Shift _shift)
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
}