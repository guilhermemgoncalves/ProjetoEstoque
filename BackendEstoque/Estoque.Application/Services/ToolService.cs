using Estoque.Application.Interfaces;
using Estoque.Application.Messages;
using Estoque.Domain.Entities;
using Estoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Services
{
    public class ToolService : IToolService
    {
        private readonly IToolRepository _toolRepository;
        public ToolService(IToolRepository toolRepository)
        {
            _toolRepository = toolRepository;
        }

        public async Task<CreateToolResponse> CreateTool(CreateToolRequest request)
        {
            var toolEntity = new Tool()
            {
                Id = Guid.NewGuid(),
                Category = request.ToolCategory,
                DateRegistry = DateTime.UtcNow,
                Description = request.ToolDescription,
                IsActive = true,
                Name = request.ToolName,
                Price = request.ToolPrice,
                LastUpdate = DateTime.UtcNow,                
            };

            await _toolRepository.CreateAsync(toolEntity);

            CreateToolResponse response = new CreateToolResponse()
            {
                Id= toolEntity.Id,
                DateRegistry = toolEntity.DateRegistry,
                IsActive = toolEntity.IsActive
            };

            return response;
        }

        public async Task<GetToolByIDResponse> GetToolById(Guid Id)
        {
            var toolEntity = await _toolRepository.GetByIdAsync(Id);

            BasicToolResponse basicTool = new()
            {
                Id = toolEntity.Id,
                Category = toolEntity.Category,
                Description = toolEntity.Description,
                IsActive=toolEntity.IsActive,
                Name = toolEntity.Name,
                Price= toolEntity.Price,
                Tags= toolEntity.Tags,
                LastUpdate = toolEntity.LastUpdate
            };

            GetToolByIDResponse response = new ()
            {
                BasicToolResponse = basicTool
            };

            return await Task.FromResult(response);
        }

        public async Task<GetToolsResponse> GetTools()
        {
            var toolsEntity = await _toolRepository.GetAsync();
            GetToolsResponse response = new GetToolsResponse();

            foreach (Tool tool in toolsEntity)
            {
                BasicToolResponse basicToolResponse = new BasicToolResponse()
                {
                    Id= tool.Id,
                    Name= tool.Name,
                    Category= tool.Category,
                    Description= tool.Description,
                    Price  = tool.Price,
                    Tags = tool.Tags,
                    IsActive = tool.IsActive,
                    LastUpdate = tool.LastUpdate
                };
                response.BasicToolResponse.Add(basicToolResponse);
            }
            return await Task.FromResult(response);
         }

        
      

        public bool TestService()
        {
            return false;
        }

        public async Task<UpdateToolResponse> UpdateTool(Guid Id, UpdateToolRequest request)
        {
            var toolEntity = await _toolRepository.GetByIdAsync(Id);

            BasicToolResponse basicTool = new()
            {
                Id = toolEntity.Id,
                Category = toolEntity.Category,
                Description = toolEntity.Description,
                IsActive = toolEntity.IsActive,
                Name = toolEntity.Name,
                Price = toolEntity.Price,
                Tags = toolEntity.Tags,
                LastUpdate = toolEntity.LastUpdate
            };         



            var response = new UpdateToolResponse()
            { LastUpdate = DateTime.UtcNow};

            return await Task.FromResult(response);
        }
    }
}
