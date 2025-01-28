using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OnlineAuctionAPI.Data;
using OnlineAuctionAPI.Model;
namespace OnlineAuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMongoCollection<Admin>? _admins;
        public AdminController(MongoDbService mongoDbService) 
        {
            _admins = mongoDbService.Database?.GetCollection<Admin>("admin");
        }
        [HttpGet]
        public async Task<IEnumerable<Admin>> Get()
        {
            return await _admins.Find(FilterDefinition<Admin>.Empty).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin?>> GetById(string id)
        {
            var filter = Builders<Admin>.Filter.Eq(x => x._id, id);
            var admin = _admins.Find(filter).FirstOrDefault();
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }
        [HttpPost]
        public async Task<ActionResult> Create(string name )
        {
            var admin = new Admin()
            {
                Name = name
            };
            await _admins.InsertOneAsync(admin);
            return CreatedAtAction(nameof(GetById), new {id = admin._id},admin);
        }
        [HttpPut]
        public async Task<ActionResult> Update (Admin admin)
        {
            var filter = Builders<Admin>.Filter.Eq(x=>x._id, admin._id);
            //var update = Builders<Admin>.Update
            //    .Set(x => x.Name, admin.Name);
            //await _admins.UpdateOneAsync(filter, update);

            await _admins.ReplaceOneAsync(filter, admin);
            return Ok(admin);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var filter = Builders<Admin>.Filter.Eq(x => x._id,id);
            await _admins.DeleteOneAsync(filter);
            return Ok();
        }
        
    }
}
