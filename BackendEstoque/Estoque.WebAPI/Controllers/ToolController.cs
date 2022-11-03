using Estoque.Application.Interfaces;
using Estoque.Application.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
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

        [HttpGet("testeapi")]
        [OpenApiOperation(
            operationId: "testapi",
            tags: new[] { "Retorna os lotes atribuidos para o usuário realizar a gravação de voz." }
        )]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "application/json",
            bodyType: typeof(string),
            Description = "Retorna uma lista de lotes com fases para que o usuário possa gravar a sua voz lendo os textos sugeridos"
        )]
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
