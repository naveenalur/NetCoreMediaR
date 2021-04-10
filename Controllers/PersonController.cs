using DataBase.Model;
using MediatR;
using MeditorDefinations.Command;
using MeditorDefinations.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await mediator.Send(new GetPersonListQuery());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await mediator.Send(new GetPersonByIdQuery(id));
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<Person> Post([FromBody] Person value)
        {
            var model = new InsertPersonCommand(value.FirstName, value.LasttName);
            return await mediator.Send(model);
        }


        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task <Unit>Delete(int id)
        {
            return await mediator.Send(new DeletePersonCommand(id));
        }
    }
}
