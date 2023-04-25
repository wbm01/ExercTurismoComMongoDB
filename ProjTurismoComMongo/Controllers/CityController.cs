using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjTurismoComMongo.Models;
using ProjTurismoComMongo.Services;

namespace ProjTurismoComMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService; //injeção de dependência
        }

        [HttpGet]
        public ActionResult<List<City>> GetCity() => _cityService.GetCity();

        [HttpGet("{id:length(24)}", Name = "GetCity")]
        public ActionResult<City> GetCity(string id)
        {
            var city = _cityService.GetCity(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        [HttpPost]
        public ActionResult<City> Create(City city)
        {
            return _cityService.Create(city);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, City city)
        {
            var c = _cityService.GetCity(id);

            if (c == null)
            {
                return NotFound();
            }
            _cityService.Update(id, city);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = _cityService.GetCity(id);
            if (client == null)
            {
                return NotFound();
            }
            _cityService.DeleteOne(id);
            return Ok();
        }
    }
}
