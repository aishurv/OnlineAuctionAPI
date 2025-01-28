using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuctionAPI.Model
{
    public class Admin
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }


        [MaxLength(50)]
        public string Name { get; set; }


    }
}
