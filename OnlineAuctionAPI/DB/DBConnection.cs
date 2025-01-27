using MongoDB.Driver;
using DockerMongoTestApp.Models;
namespace DB
{
    
    public static class DBConnection
    {
        //public static MongoClient mongoClient = new MongoClient("mongodb://admin:password@mongo-container:27017");
        public static MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase Database = mongoClient.GetDatabase("OnlineAuction");
        private static readonly IMongoCollection<Product> _productCollection;

        static DBConnection()
        {
            _productCollection = Database.GetCollection<Product>("products");
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
        public static void AddProduct(Product product)
        {
            _productCollection.InsertOne(product);
        }
        public static void AddProducts(List<Product> products)
        {
            _productCollection.InsertMany(products);
        }


    }
}
