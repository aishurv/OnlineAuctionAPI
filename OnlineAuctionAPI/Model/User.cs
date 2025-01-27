using DB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuctionAPI.Models
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

}
