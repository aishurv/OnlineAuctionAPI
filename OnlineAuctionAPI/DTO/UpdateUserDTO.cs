#nullable disable

using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuctionAPI.DTO
{
    public class UpdateUserDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]
        [Length(10, 10)]
        public decimal ContactNo { get; set; }
    }
}
