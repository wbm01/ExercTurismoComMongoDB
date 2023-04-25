using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjTurismoComMongo.Models;
using ProjTurismoComMongo.Services;

namespace ProjTurismoComMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;

        public AddressController(AddressService addressService, CityService cityService)
        {
            _addressService = addressService; //injeção de dependência
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpPost]
        //Ao dar o post a classe controller vai pegar o objeto, enviar para
        //a service e a service vai fazer as validações do banco, incluir no banco 
        //e retornar para a classe Address.
        public ActionResult<Address> Create(Address address)
        {

            address.City = _cityService.Create(address.City);
            _addressService.Create(address);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Address address)
        {
            var c = _addressService.Get(id);

            if (c == null)
            {
                return NotFound();
            }

            if (address.City.IdCity != null)
            {
                var city = _cityService.Get(address.City.IdCity);
                address.City = city;
            }
            else
            {
                address.City = _cityService.Create(address.City);
            }
            _addressService.Update(id, address);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var address = _addressService.Get(id);
            if (address == null)
            {
                return NotFound();
            }
            _addressService.DeleteOne(id);
            return Ok();
        }
    }
}
