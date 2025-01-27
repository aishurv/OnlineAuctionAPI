using DB;
using OnlineAuctionAPI.Models;

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
            group.MapGet("/{id}", (int id) =>
            {
                return DBConnection.Users;
            })
            .WithName("GetUserById")
            .WithOpenApi();

            group.MapPut("/{id}", (int id, User input) =>
            {

                //return TypedResults.NoContent();
            })
            .WithName("UpdateUser")
            .WithOpenApi();

            group.MapPost("/", (User model) =>
            {
                return TypedResults.Created($"/api/Users/{model.UserId}", model);
            })
            .WithName("CreateUser")
            .WithOpenApi();

            group.MapDelete("/{id}", (int id) =>
            {
                //return TypedResults.Ok(new User { ID = id });
            })
            .WithName("DeleteUser")
            .WithOpenApi();

        }
    }
}
