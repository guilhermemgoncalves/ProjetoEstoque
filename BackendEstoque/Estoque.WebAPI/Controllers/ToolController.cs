using Estoque.Application.Interfaces;
using Estoque.Application.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Estoque.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class ToolController : ControllerBase
    {
        private readonly IToolService _toolService;

        public ToolController(IToolService toolService)
        {
            _toolService = toolService;
        }

        [HttpGet("GetAll")]
        public async Task<GetToolsResponse> GetAllTools([FromQuery] string toolStatus)       
        {
            return await _toolService.GetTools(toolStatus);
        }


        [HttpGet("GetById")]
        public async Task<GetToolByIDResponse> GetToolById([FromQuery] Guid id)
        {
            return await _toolService.GetToolById(id);
        }
      

        [HttpPost("Create")]
        public async Task<ActionResult> GetTools([FromBody] CreateToolRequest request)
        {            
            var response = await _toolService.CreateTool(request);
            return Created("teste",response);
        }

        [HttpPost("Update")]
        public async Task<UpdateToolResponse> UpdateTools([FromBody] UpdateToolRequest request)
        {
            return await _toolService.UpdateTool(request);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteTool([FromBody] Guid guid)
        {
            var response = await _toolService.DeleteTool(guid);
            return Ok(response);
        }

        [HttpGet("ActivateAll")]
        public async Task<IResult> GetActivateAll()
        {
            await _toolService.ActivateAll();
            return Results.Ok();
        }



    }
}
