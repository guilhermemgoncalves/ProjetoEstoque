using Estoque.Application.Interfaces;
using Estoque.Application.Messages.Costumers;
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
        /// <summary>
        /// Obtem todos os usuários que podem retirar produtos
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Retorna a Base de dados</response>  
        [HttpGet]
        public async Task<ActionResult<Costumer>> Get()
        {
            return Ok(await _costumerService.GetAll());
        }
        
        /// <summary>
        /// Retorna o  usuários pelo seu numero de prontuário
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Retorna usuário </response>  
        [HttpGet("{id}")]
        public async Task<ActionResult<Costumer>> Get(string prontuario)
        {
            return Ok(await _costumerService.GetById(prontuario));
        }


        /// <summary>
        /// Cria um usuário na base de dados
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Cria um usuário </response> 
        [HttpPost]
        public async Task<ActionResult<Costumer>> Post([FromBody] Costumer costumer)
        {
            var response = await _costumerService.CreateCostumer(costumer);
            return Created("Criado", response);
        }

        /// <summary>
        /// Cria um usuário na base de dados
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Cria Upload de Foto para usuario </response> 
        /// 
        [HttpPost("uploadImage")]
        public async Task<ActionResult<string>> Post([FromBody] UploadImageCommand body)
        {
            var response = await _costumerService.UploadBase64Image(body.Image, body.Container);
            return Created("Criado", response);
        }


    }
}
