using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DockerMongoTestApp.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public required string Name { get; set; }
        [BsonElement("description")]
        public required string Description { get; set; }
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
