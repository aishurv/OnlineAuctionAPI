using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuctionAPI.Models
{
    public class Product
    {
        [BsonId]
        [Key]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [BsonElement("description")]
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [BsonElement("inituialvalue")]
        public decimal InitialValue { get; set; }
        [BsonElement("urrentvalue")]
        public decimal CurrentValue { get; set; }
        [BsonElement("prepvalue")]
        public decimal PreValue { get; set; }
        [BsonElement("isactive")]
        public bool IsActive { get; set; }
    }
}
