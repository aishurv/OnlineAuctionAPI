using MongoDB.Driver;

namespace OnlineAuctionAPI.Data
{
    public class MongoDbService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase? _database;

        public MongoDbService(IConfiguration configuration) 
        {
            _configuration =configuration;
            var connectionString = "mongodb://localhost:27017";//_configuration.GetConnectionString("DbConnection");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _database= mongoClient.GetDatabase("OnlineAuctionDB");
        }
        public IMongoDatabase? Database => _database;
    }
}
