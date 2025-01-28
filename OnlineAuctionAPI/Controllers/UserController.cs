using DB;
using OnlineAuctionAPI.DTO;
using OnlineAuctionAPI.Models;
using AutoMapper;
namespace OnlineAuctionAPI.Controllers
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/User").WithTags(nameof(User));

            group.MapGet("/", () =>
            {
                return DBConnection.Users;
            })
            .WithName("GetAllUsers")
            .WithOpenApi();
            group.MapGet("/{id}", (String id) =>
            {
                return DBConnection.Users.Where(user => user._id == id);
            })
            .WithName("GetUserById")
            .WithOpenApi();

            group.MapPut("/{id}", (String id, UpdateUserDTO input, IMapper mapper) =>
            {
                var user = DBConnection.Users.FirstOrDefault(u => u._id == id);
                mapper.Map(input, user);
                DBConnection.UsersCollection.Save(user);
                //DBConnection.Users.up
                return Results.NoContent();
            })
            .WithName("UpdateUser")
            .WithOpenApi();

            group.MapPost("/", (User user) =>
            {
                DBConnection.AddUser(user);
                return TypedResults.Created($"/api/Users/{user._id}", user);
            })
            .WithName("CreateUser")
            .WithOpenApi();

            group.MapDelete("/{id}", (String id) =>
            {
                //return TypedResults.Ok(new User { ID = id });
            })
            .WithName("DeleteUser")
            .WithOpenApi();

        }
    }
}
