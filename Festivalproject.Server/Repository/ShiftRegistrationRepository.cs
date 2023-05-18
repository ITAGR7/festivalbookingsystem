using MongoDB.Bson;
using MongoDB.Driver;
using Festivalproject.Shared.Models;
using Festivalproject.Server.Interface;



namespace Festivalproject.Server.Repository
{
    public class ShiftRegistrationRepository : IShiftRegistration
    {
        private const string connectionString = @"mongodb+srv://admin:LgyyJ6R8qFXcQgtg@festivalcluster0.wn5s5bo.mongodb.net/";
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

            var filter = Builders<ShiftRegistration>.Filter.Eq("userId", UserId);
            var result = collection.Find(filter).ToList();
            return result;

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


        // Id anvendes ikke i denne og der manglede et filter 

        //public List<ShiftRegistration> GetRegisteredShiftsById(Shift shift)
        //{
        //    //return await collection.Find(i => true).ToListAsync();
        //    // check for match between shift.Shiftid and shiftRegistration.ShiftId 


        //    var result = collection.Find(new BsonDocument()).ToList();
        //    Console.WriteLine("Test Get registered" + result.Count);
        //    return result; 
        //}
    }
}
