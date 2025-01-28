using MongoDB.Driver;

namespace OnlineAuctionAPI.Data
{
    public class MongoDbService
    {
        private readonly IMongoDatabase? _database;

        public MongoDbService() 
        {
            var connectionString = "mongodb://localhost:27017";//_configuration.GetConnectionString("DbConnection");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _database= mongoClient.GetDatabase("OnlineAuctionDB");
        }
        public IMongoDatabase? Database => _database;
    }
}
