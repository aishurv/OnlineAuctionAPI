#nullable disable

using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuctionAPI.DTO
{
    public class InsertProductDTO
    {
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
