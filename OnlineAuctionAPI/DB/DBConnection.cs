using MongoDB.Driver;
using OnlineAuctionAPI.Models;
namespace DB
{
    
    public static class DBConnection
    {
        //public static MongoClient mongoClient = new MongoClient("mongodb://admin:password@mongo-container:27017");
        static MongoClient mongoClient;
        public static IMongoDatabase Database;
        private static readonly IMongoCollection<Product> _productCollection;
        private static readonly IMongoCollection<User> _userCollection;
        static DBConnection()
        {
             mongoClient = new MongoClient("mongodb://localhost:27017");
             Database = mongoClient.GetDatabase("OnlineAuctionDB");

            _productCollection = Database.GetCollection<Product>("products");
            _userCollection = Database.GetCollection<User>("users");
            Console.WriteLine(Database.GetType().Name);
        }
        public static List<Product> Products
        {
            get
            {
                var collection = Database.GetCollection<Product>("products");
                return collection.Find(_ => true).ToList();
            }
        }
        public static List<User> Users
        {
            get
            {
                var collection = Database.GetCollection<User>("users");
                return collection.Find(_ => true).ToList();
            }
        }
        public static void AddProduct(Product product)
        {
            _productCollection.InsertOne(product);
        }
        public static void AddProducts(List<Product> products)
        {
            _productCollection.InsertMany(products);
        }
        public static void AddUser(User user)
        {
            _userCollection.InsertOne(user);
        }
        public static void AddUser(List<User> users)
        {
            _userCollection.InsertMany(users);
        }


    }
}
