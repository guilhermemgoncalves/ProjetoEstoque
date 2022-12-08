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

        [HttpGet("GetAll")]
        public async Task<ActionResult<GetToolsResponse>> GetAllTools([FromQuery] string consumablesStatus)       
        {
            return Ok(await _consumablesService.GetTools(consumablesStatus));
        }


        [HttpGet("GetById")]
        public async Task<ActionResult<GetToolByIDResponse>> GetToolById([FromQuery] Guid id)
        {
            return Ok(await _consumablesService.GetToolById(id));
        }
      

        [HttpPost("Create")]
        public async Task<ActionResult> GetTools([FromBody] CreateToolRequest request)
        {            
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

    }
}
