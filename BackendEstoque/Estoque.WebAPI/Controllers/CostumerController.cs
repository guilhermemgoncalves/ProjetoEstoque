using Estoque.Application.Interfaces;
using Estoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estoque.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {

        private readonly ICostumerService _costumerService;
        public CostumerController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            return  Results.Ok( await _costumerService.GetAll());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(string id)
        {
            return Results.Ok(await _costumerService.GetById(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] Costumer costumer)
        {
            return Results.Ok( await _costumerService.CreateCostumer(costumer));
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
