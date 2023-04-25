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

        public AddressController(AddressService addressService)
        {
            _addressService = addressService; //injeção de dependência
        }

        [HttpGet]
        public ActionResult<List<Address>> GetAddress() => _addressService.GetAddress();

        [HttpGet("{id:length(24)}",Name = "GetAddress")]
        public ActionResult<Address> GetAddress(string id)
        {
            var address = _addressService.GetAddress(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpPost]
        //Ao dar o post a classe controller vai pegar o objeto, enviar para
        //a service e a service vai fazer as validações, incluir no banco 
        //e retornar para a classe Address.
        public ActionResult<Address> Create(Address address)
        {
            _addressService.Create(address);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Address address)
        {
            var c = _addressService.GetAddress(id);

            if (c == null)
            {
                return NotFound();
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
            var address = _addressService.GetAddress(id);
            if (address == null)
            {
                return NotFound();
            }
            _addressService.DeleteOne(id);
            return Ok();
        }
    }
}
