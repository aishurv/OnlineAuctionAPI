
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace OnlineAuctionAPI.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }


        [Required]
        [MaxLength(50)]
        public  string Name { get; set; }


        [Required]
        [BsonRepresentation(BsonType.Double)]
        public decimal ContactNo { get; set; }

        
    }
    

}
