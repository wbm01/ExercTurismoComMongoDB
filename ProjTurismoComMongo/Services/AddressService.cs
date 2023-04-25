﻿using MongoDB.Driver;
using ProjTurismoComMongo.Config;
using ProjTurismoComMongo.Models;

namespace ProjTurismoComMongo.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;
        private readonly IMongoCollection<City> _city;

        public AddressService(IProjMDSettings settings)
            //O Contrutor foi feito para que seja feita a conexão no banco
            //toda vez que chamar a classe AddressService
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<Address> GetAddress()
        {
            return _address.Find(c => true).ToList();
        }

        public Address GetAddress(string id)
        {
            return _address.Find<Address>(c => c.IdAddress == id).FirstOrDefault();
        }

        public Address Create(Address address)
        {
            var cidade = _city.Find(c => c.IdCity == address.City.IdCity).FirstOrDefault();
            if (cidade == null) _city.InsertOne(address.City);
            else address.City = cidade;

            _address.InsertOne(address);

            return address;
        }

        public void Update(string id, Address address)
        {
            _address.ReplaceOne(c => c.IdAddress == address.IdAddress, address);
        }

        public void Delete(Address address)
        {
            _address.DeleteOne(c => c.IdAddress == address.IdAddress);
        }

        public void DeleteOne(string id)
        {
            _address.DeleteOne(c => c.IdAddress == id);
        }
    }
}
