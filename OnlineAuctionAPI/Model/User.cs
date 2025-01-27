
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace DockerMongoTestApp.Models
{
    public class User
    {
        [BsonId]
        [Key]
        public ObjectId UserId { get; set; }

        [Required]
        [MaxLength(50)]
        [BsonElement("name")]
        public  string Name { get; set; }


        [Required]
        [BsonElement("contactno")]
        [Length(10,10)]
        public decimal ContactNo { get; set; }

        [Required]
        [BsonElement("username")]
        public string UserName;
    }


public static class UserEndpoints
{
	public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/User").WithTags(nameof(User));

        group.MapGet("/", () =>
        {
            return new [] { new User() };
        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        
    }
}

}
