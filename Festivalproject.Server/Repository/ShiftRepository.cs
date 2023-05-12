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
        private IMongoCollection<Shifts> collection;

        public ShiftRepository()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<Shifts>(collectionName);
        }


        public List<Shifts> GetAllShifts()
        {

            //return await collection.Find(i => true).ToListAsync();
            return collection.Find(new BsonDocument()).ToList();
        }

        public List<Shifts> GetShiftsByStatus(bool status)
        {

            return collection.Find(i => i.Status == status).ToList();
        }
    }

}
