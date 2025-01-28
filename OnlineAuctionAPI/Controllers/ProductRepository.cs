//#nullable disable
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using MongoDB.Driver;
using OnlineAuctionAPI.Data;
using OnlineAuctionAPI.Model;
using OnlineAuctionAPI.Models;

namespace OnlineAuctionAPI.Controllers
{
    public class ProductRepository
    {
        private readonly MongoDbService _mongoDbService = new();

        private readonly IMongoCollection<Product>? _products;
        public ProductRepository() 
        {
            _products = _mongoDbService.Database?.GetCollection<Product>("product");
        }
        public async Task<IEnumerable<Product>> GetAllproducts()
        {
            return await _products.Find(FilterDefinition<Product>.Empty).ToListAsync();
        }
        public Product GetById(string id)
        {
            var filter = Builders<Product>.Filter.Eq(x=> x._id,id);
            return _products.Find(filter).FirstOrDefault();
        }
        public async Task Create(Product product)
        {
            await _products.InsertOneAsync(product);
        }
        public void Update(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(x => x._id, product._id);
             _products.ReplaceOne(filter,product);
        }
        public void Delete (string id )
        {
            var filter = Builders<Product>.Filter.Eq(x => x._id, id);
             _products.DeleteOne(filter);
        }
    }
}
