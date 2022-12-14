using Estoque.Application.Interfaces;
using Estoque.Application.Messages;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Estoque.WebAPI.Controllers
{
    /// <summary>
    /// Controller de usuários que farão a retirada dos produtos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _consumablesService;
        /// <summary>
        /// Construtor de consumableController
        /// </summary>
        /// <param name="consumablesService"></param>
        public ProductController(IProductsService consumablesService)
        {
            _consumablesService = consumablesService;
        }


        /// <summary>
        /// Lista todos os itens consumiveis do estoque
        /// </summary>
        /// <param name="consumablesStatus"> true para retornar itens habilitados/ false para itens desabilitados</param>
        /// <returns> </returns>
        /// <response code ="200"> Retorna os itens </response>
        /// 
        /// <response code ="204"> Não há Itens com o consumableStatus enviado</response>
        /// <response code ="400"> consumableStatus não aceito</response>
        [HttpGet("GetAll")]
        public async Task<ActionResult<GetProductResponse>> GetAllTools([FromQuery] string consumablesStatus)       
        {
            if(string.IsNullOrEmpty(consumablesStatus))
            {
                return BadRequest(error: "consumablesStatus não pode ser vazio");
            }
            if(consumablesStatus != "false" && consumablesStatus != "true")
            {
                return BadRequest(error: "consumablesStatus é diferente de true e false");
            }

            return Ok(await _consumablesService.GetTools(consumablesStatus));
        }


        /// <summary>
        /// Retorna o Item por ID {Guid/uiid}
        /// </summary>
        /// <param name="id"> retorna o item respectivo ao id</param>
        /// <returns> </returns>
        /// <response code ="200"> Retorna o Item desejado pelo Id</response>
        /// 
        /// <response code ="204"> Não há Itens com o id enviado</response>
        /// <response code ="400"> Esse formato não é um Guid</response>


        [HttpGet("GetById")]
        public async Task<ActionResult<GetProductByIDResponse>> GetToolById([FromQuery] Guid id)
        {
            var result = await _consumablesService.GetToolById(id);

            if(string.IsNullOrEmpty(result.ProductResponse.Description))
            {
                var message = "O item não existe no banco de dados";
                return Ok(message); 
            }
            return Ok(result);
        }
      
        /// <summary>
        /// Cria um novo item no estoque
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Retorna a data e hora que item foi criado</response>  
        /// <response code ="400"> Informação obrigatóriao não fornecida</response>
        [HttpPost("Create")]
        public async Task<ActionResult> CreateTools([FromBody] CreateProductRequest request)
        {

            var responseMessage = ValidateFields(request);

            if(responseMessage != "ValidFields")
            {
                return BadRequest(error: responseMessage);
            }

            var response = await _consumablesService.CreateTool(request);

            return Created("Produto Criado:", response);
        }
        /// <summary>
        /// Atualiza um item no estoque
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Retorna a data e hora que item foi Atualizado</response>  
        /// <response code ="400"> Informação obrigatóriao não fornecida</response>
        [HttpPost("Update")]
        public async Task<ActionResult<UpdateProductResponse>> UpdateTools([FromBody] UpdateProductRequest request)
        {
            var responseMessage = ValidateFields(request);
             if(responseMessage != "ValidFields")
            {
                return BadRequest(error: responseMessage);
            }

            var response = await _consumablesService.UpdateTool(request);

            if (response.LastUpdate == DateTime.MinValue)
            {
                var message = "O item não existe no banco de dados";
                return Ok(message);
            }
            return Ok(response);
        }
        /// <summary>
        /// Desativa o Item na Base de dados
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="204"> O item foi Atualizado</response>         

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteTool([FromBody] Guid guid)
        {
            
            await _consumablesService.DeleteTool(guid);
            return NoContent();
        }
        /// <summary>
        /// Atualiza todos os itens do estoque para ativo
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Retorna a data e hora que item foi Atualizado</response>  
    
        [HttpGet("ActivateAll")]
        public async Task<ActionResult<string>> GetActivateAll()
        {
            await _consumablesService.ActivateAll();
            return Ok("Todos os itens foram atualizados");
        }
        /// <summary>
        /// Sobe a base de dados por CSV
        /// </summary>
        ///
        /// <returns> </returns>
        /// <response code ="200"> Retorna a Base de dados</response>  
        [HttpPost("loadByCsv")]
        public async Task<ActionResult<string>> GetEmployeeCSV([FromForm] IFormFileCollection file)
        {
            var response = await _consumablesService.ReadCSV<ProductsCSV>(file[0].OpenReadStream());

            return response;
        }

        private string ValidateFields(CreateProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Description) || request.Description == "string")
            {
                return "Erro: O campo toolDescription é obrigatório";
            }
            if (string.IsNullOrWhiteSpace(request.Category) || request.Category == "string")
            {
                return "Erro: O campo ToolCategory é obrigatório";
            }
            return "ValidFields";
        }
        private string ValidateFields(UpdateProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Id.ToString()))
            {
                return "Erro: O campo Id é obrigatório";
            }
            if (string.IsNullOrWhiteSpace(request.ToolDescription) || request.ToolDescription == "string")
            {
                return "Erro: O campo toolDescription é obrigatório";
            }
            if (string.IsNullOrWhiteSpace(request.ToolCategory) || request.ToolCategory == "string")
            {
                return "Erro: O campo ToolCategory é obrigatório";
            }
            return "ValidFields";
        }

    }
}
