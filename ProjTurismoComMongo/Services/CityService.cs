using MongoDB.Driver;
using ProjTurismoComMongo.Config;
using ProjTurismoComMongo.Models;

namespace ProjTurismoComMongo.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _city;

        public CityService(IProjMDSettings settings)
        {
            var city = new MongoClient(settings.ConnectionString);
            var database = city.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<City> GetCity()
        {
            return _city.Find(c => true).ToList();
        }

        public City GetCity(string id)
        {
            return _city.Find<City>(c => c.IdCity == id).FirstOrDefault();
        }

        public City Create(City city)
        {
            _city.InsertOne(city);
            return city;
        }

        public void Update(string id, City city)
        {
            _city.ReplaceOne(c => c.IdCity == city.IdCity, city);
        }

        public void Delete(City city)
        {
            _city.DeleteOne(c => c.IdCity == city.IdCity);
        }

        public void DeleteOne(string id)
        {
            _city.DeleteOne(c => c.IdCity == id);
        }
    }
}
