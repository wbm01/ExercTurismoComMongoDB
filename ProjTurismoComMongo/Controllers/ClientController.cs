using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjTurismoComMongo.Models;
using ProjTurismoComMongo.Services;

namespace ProjTurismoComMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService; //injeção de dependência
        }

        [HttpGet]
        public ActionResult<List<Client>> Get() => _clientService.Get();

        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public ActionResult<Client> Create(Client client)
        {
            _clientService.Create(client);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Client client)
        {
            var c = _clientService.Get(id);

            if (c == null)
            {
                return NotFound();
            }
            _clientService.Update(id, client);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = _clientService.Get(id);
            if (client == null)
            {
                return NotFound();
            }
            _clientService.DeleteOne(id);
            return Ok();
        }
    }
}
