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
        public async Task<IResult> GetOrders()
        {
            var response = await _orderService.GetAll();
            return Results.Ok(response);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IResult>Get(Guid id)
        {
            var response = await _orderService.GetById(id);

            return Results.Ok(response);
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
