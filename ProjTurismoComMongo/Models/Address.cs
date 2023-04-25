using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjTurismoComMongo.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdAddress { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string Neighborhood { get; set; }

        public string Cep { get; set; }

        public string Complement { get; set; }

        public City City { get; set; }

        public DateTime DtRegisterAddress { get; set; }
    }
}
