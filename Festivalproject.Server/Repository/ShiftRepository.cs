using MongoDB.Bson;
using MongoDB.Driver;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Interface;


namespace Festivalproject.Server.Repository
{
    public class ShiftRepository : IShifts
    {
        private const string connectionString = @"mongodb+srv://admin:LgyyJ6R8qFXcQgtg@festivalcluster0.wn5s5bo.mongodb.net/";
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

        public List<Shift> GetShiftsByStatus(bool status)
        {

            return collection.Find(i => i.Status == status).ToList();
        }

        public async Task<Shift> UpdateShift(Shift shiftUpdated)
        {
            Console.WriteLine("Updateshift test repo " + shiftUpdated.Id);


            var filter = Builders<Shift>.Filter.Eq(u => u.Id, shiftUpdated.Id);

            var update = Builders<Shift>.Update
              .Set(u => u.Name, shiftUpdated.Name)
              .Set(u => u.startTime, shiftUpdated.startTime)
              .Set(u => u.endTime, shiftUpdated.endTime)
              .Set(u => u.Description, shiftUpdated.Description);

            var result = await collection.UpdateOneAsync(filter, update);

            return shiftUpdated; 

        }
    }

}
