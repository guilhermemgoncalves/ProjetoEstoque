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

        /// <summary>
        /// Obtem todos os pedidos feitos
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Retorna pedidos feitos</response>  
        [HttpGet]
        public async Task<IResult> GetOrders()
        {
            var response = await _orderService.GetAll();
            return Results.Ok(response);
        }

        /// <summary>
        /// Retorna um pedido pelo id
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Retorna um pedido</response>  
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> Get(Guid id)
        {
            var response = await _orderService.GetById(id);

            return Ok(response);
        }


        /// <summary>
        /// Cria um pedido na base de dados
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Cria um pedido </response> 
        [HttpPost("CreateOrder")]
        public async Task<ActionResult<Orders>> Post([FromBody] CreateOrderRequest request)
        {
            var response = await _orderService.CreateOrder(request);

            return Created("Criado", response);
        }

       
    }
}
