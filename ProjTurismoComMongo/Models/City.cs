using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjTurismoComMongo.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdCity { get; set; }

        public string Description { get; set; }

        public DateTime DtRegisterCity { get; set; }
    }
}
