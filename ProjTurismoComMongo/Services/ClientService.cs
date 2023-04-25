using System.Net;
using MongoDB.Driver;
using ProjTurismoComMongo.Config;
using ProjTurismoComMongo.Models;

namespace ProjTurismoComMongo.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Address> _address;
        private readonly IMongoCollection<City> _city;

        public ClientService(IProjMDSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _client = database.GetCollection<Client>(settings.ClientCollectionName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<Client> Get()
        {
            return _client.Find(c => true).ToList();
        }

        public Client Get(string id)
        {
            return _client.Find<Client>(c => c.IdClient == id).FirstOrDefault();
        }

        public Client Create(Client client)
        {

            var cidade = _city.Find(c => c.IdCity == client.AddressClient.City.IdCity).FirstOrDefault();
            if (cidade.Equals(""))
                _city.InsertOne(client.AddressClient.City);
            else
                client.AddressClient.City = cidade;

            var endereco = _address.Find(c => c.IdAddress == client.AddressClient.IdAddress).FirstOrDefault();
            if (endereco == null)
                _address.InsertOne(client.AddressClient);
            else
                client.AddressClient = endereco;

            

            _client.InsertOne(client);

            return client;
        }

        public void Update(string id, Client client)
        {
            _client.ReplaceOne(c => c.IdClient == client.IdClient, client);
        }

        public void Delete(Client client)
        {
            _client.DeleteOne(c => c.IdClient == client.IdClient);
        }

        public void DeleteOne(string id)
        {
            _client.DeleteOne(c => c.IdClient == id);
        }
    }
}
