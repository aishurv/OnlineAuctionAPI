
using OnlineAuctionAPI.Models;
using OnlineAuctionAPI.Data;
using MongoDB.Driver;
namespace OnlineAuctionAPI.Controllers
{
    public static class UserEndpoints
    {
         private static readonly MongoDbService _mongoDbService = new();
         private static readonly IMongoCollection<User>? _users = _mongoDbService.Database?.GetCollection<User>("users"); 
        
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/User").WithTags(nameof(User));

            group.MapGet("/", () =>
            {
                return _users.Find(FilterDefinition<User>.Empty).ToListAsync();
            })
            .WithName("GetAllUsers")
            .WithOpenApi();
            group.MapGet("/{id}", (String id) =>
            {
                var filter = Builders<User>.Filter.Eq(x => x._id, id);
                return _users.Find(filter).FirstOrDefault();
            })
            .WithName("GetUserById")
            .WithOpenApi();

            group.MapPut("/{id}", (String id, User input) =>
            {
                var filter = Builders<User>.Filter.Eq(x => x._id, id);
                _users.ReplaceOne(filter, input);
                return Results.NoContent();
            })
            .WithName("UpdateUser")
            .WithOpenApi();

            group.MapPost("/", (User user) =>
            {
                _users.InsertOne(user);
                return TypedResults.Created($"/api/Users/{user._id}", user);
            })
            .WithName("CreateUser")
            .WithOpenApi();

            group.MapDelete("/{id}", (String id) =>
            {
                var filter = Builders<User>.Filter.Eq(x => x._id, id);
                _users.DeleteOne(filter);
            })
            .WithName("DeleteUser")
            .WithOpenApi();

        }
    }
}
