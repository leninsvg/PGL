using Microsoft.AspNetCore.Mvc;
using PGL.Business.Services;
using PGL.Model;

namespace PGL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("clients")]
        public PageModel<PersonModel> GetClients([FromQuery] int page, [FromQuery] int pageSize)
        {
            return this._personService.GetClients(page, pageSize);
        }
        
        [HttpGet("clients-sp")]
        public PageModel<PersonModel> GetClientsSP([FromQuery] int page, [FromQuery] int pageSize)
        {
            return this._personService.GetClientsSP(page, pageSize);
        }

        [HttpPost("client")]
        public PersonModel Get([FromBody] PersonModel client)
        {
            return this._personService.CreatClient(client);
        }
    }
}