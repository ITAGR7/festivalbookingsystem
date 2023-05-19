using MongoDB.Bson;
using MongoDB.Driver;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Interface;


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
        //return await collection.Find(i => true).ToListAsync();
        return collection.Find(new BsonDocument()).ToList();
    }
    
    public Shift GetShiftById(string id)
    {
        return collection.Find(i => i.Id == id).FirstOrDefault();
    }

    public List<Shift> GetShiftsByStatus(bool status)
    {
        return collection.Find(i => i.Status == status).ToList();
    }

    public Shift UpdateShift(Shift newShift)
    {
        var filter = Builders<Shift>.Filter.Eq(s => s.Id, newShift.Id);
        var update = Builders<Shift>.Update
            .Set(s => s.Name, newShift.Name)
            .Set(s => s.Type, newShift.Type)
            .Set(s => s.Status, newShift.Status)
            .Set(s => s.Area, newShift.Area)
            .Set(s => s.Description, newShift.Description)
            .Set(s => s.Duration, newShift.Duration)
            .Set(s => s.startTime, newShift.startTime)
            .Set(s => s.endTime, newShift.endTime);

        collection.UpdateOne(filter, update);
        return newShift;
    }
}