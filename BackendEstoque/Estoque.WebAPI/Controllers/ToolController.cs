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
        public async Task<GetToolsResponse> GetAllTools()       
        {
            return await _toolService.GetTools();
        }
        [HttpGet("GetById")]
        public async Task<GetToolByIDResponse> GetToolById([FromQuery] Guid id)
        {
            return await _toolService.GetToolById(id);
        }


        [HttpPost("Create")]
        public async Task<CreateToolResponse> GetTools([FromBody] CreateToolRequest request)
        {            
            return await _toolService.CreateTool(request);
        }

        [HttpPost("Update")]
        public async Task<UpdateToolResponse> UpdateTools([FromBody] UpdateToolRequest request)
        {
            return await _toolService.UpdateTool(request);
        }

        [HttpDelete("Delete")]
        public async Task<UpdateToolResponse> DeleteTool([FromBody] UpdateToolRequest request)
        {
            return await _toolService.DeleteTool(request);
        }

        [HttpGet("ActivateAll")]
        public async Task<string> GetActivateAll()
        {
            await _toolService.ActivateAll();
            return "Todas as ferramentas foram reativadas no catalogo";
        }


    }
}
