using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuctionAPI.DTO
{
    public class InsertUserDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]
        [Length(10, 10)]
        public decimal ContactNo { get; set; }

        [Required]
        public string UserName;
    }
}
