using Estoque.Application.Interfaces;
using Estoque.Application.Messages;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Estoque.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class ConsumablesController : ControllerBase
    {
        private readonly IConsumablesService _consumablesService;

        public ConsumablesController(IConsumablesService consumablesService)
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
        public async Task<ActionResult<GetToolsResponse>> GetAllTools([FromQuery] string consumablesStatus)       
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
        public async Task<ActionResult<GetToolByIDResponse>> GetToolById([FromQuery] Guid id)
        {
            var result = await _consumablesService.GetToolById(id);

            if(string.IsNullOrEmpty(result.BasicToolResponse.Description))
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
        public async Task<ActionResult> CreateTools([FromBody] CreateToolRequest request)
        {

            var responseMessage = ValidateFields(request);

            if(responseMessage != "ValidFields")
            {
                return BadRequest(error: responseMessage);
            }

            var response = await _consumablesService.CreateTool(request);
            return Created("teste",response);
        }

        [HttpPost("Update")]
        public async Task<UpdateToolResponse> UpdateTools([FromBody] UpdateToolRequest request)
        {
            return await _consumablesService.UpdateTool(request);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteTool([FromBody] Guid guid)
        {
            var response = await _consumablesService.DeleteTool(guid);
            return NoContent();
        }

        [HttpGet("ActivateAll")]
        public async Task<IResult> GetActivateAll()
        {
            await _consumablesService.ActivateAll();
            return Results.Ok();
        }

        [HttpPost("loadByCsv")]
        public async Task<ActionResult<string>> GetEmployeeCSV([FromForm] IFormFileCollection file)
        {
            var response = await _consumablesService.ReadCSV<ConsumablesCSV>(file[0].OpenReadStream());

            return response;
        }

        private string ValidateFields(CreateToolRequest request)
        {
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
