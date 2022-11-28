using Estoque.Application.Interfaces;
using Estoque.Application.Messages.Order;
using Estoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estoque.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<List<Orders>> GetOrders()
        {
            return await _orderService.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost("CreateOrder")]
        public async Task<IResult> Post([FromBody] CreateOrderRequest request)
        {
            var response = await _orderService.CreateOrder(request);

            return Results.Ok(response) ;
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }    
    }
}
