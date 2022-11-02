using Estoque.Application.Interfaces;
using Estoque.Application.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("testeapi")] 
        public string Testeapi()
        {
            var teste = false;
             teste =_toolService.TestService();

            if (teste) { 
            return "Api funcionando";            
            }

            return "Não funcionou";
        }

        [HttpGet("GetAll")]
        public async Task<GetToolsResponse> GetAllTools()       
        {
            return await _toolService.GetTools();
        }
    }
}
