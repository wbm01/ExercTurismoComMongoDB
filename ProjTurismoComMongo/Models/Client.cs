using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjTurismoComMongo.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdClient { get; set; }

        public string NameClient { get; set; }

        public string Phone { get; set; }

        public Address AddressClient { get; set; }

        public DateTime DtRegisterClient { get; set; }
    }
}
