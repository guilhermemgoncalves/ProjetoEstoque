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

        public async Task<CreateProductResponse> CreateTool(CreateProductRequest request)
        {
            var toolEntity = new Tool()
            {
                Id = Guid.NewGuid(),
                Category = request.Category,
                DateRegistry = DateTime.UtcNow,
                Description = request.Description,
                IsActive = true,                
                Price = request.Price,
                LastUpdate = DateTime.UtcNow,                
            };

            await _toolRepository.CreateAsync(toolEntity);

            CreateProductResponse response = new()
            {
                Id= toolEntity.Id,
                DateRegistry = toolEntity.DateRegistry,
                IsActive = toolEntity.IsActive
            };

            return response;
        }

        public async Task<GetProductByIDResponse> GetToolById(Guid Id)
        {
            var toolEntity = await _toolRepository.GetByIdAsync(Id);          

            GetProductByIDResponse response = new ()
            {
                ProductResponse = FromEntityTOBasicResponse(toolEntity)
            };

            return await Task.FromResult(response);
        }

        public async Task<GetProductResponse> GetTools(string toolStatus)
        {

            var toolsEntity = await _toolRepository.GetAsync();
            GetProductResponse response = new();

            foreach (Tool tool in toolsEntity)
            {
                BasicProduct basicToolResponse = FromEntityTOBasicResponse(tool); 
                
                if(toolStatus == "true")
                {
                    if(basicToolResponse.IsActive == true)
                    {
                        response.BasicToolResponse.Add(basicToolResponse);
                    }
                }
                if (toolStatus == "false")
                {
                    if (basicToolResponse.IsActive == false)
                    {
                        response.BasicToolResponse.Add(basicToolResponse);
                    }
                }
            }
            return await Task.FromResult(response);
         }        

        public async Task<UpdateProductResponse> UpdateTool(UpdateProductRequest request)
        {
            var toolEntity = await _toolRepository.GetByIdAsync(request.Id);  

            ProcessUpdate(request, toolEntity);

            UpdateProductResponse response = new()
            {
                LastUpdate = await _toolRepository.UpdateByIdAsync(toolEntity, toolEntity.Id)
            };

            return await Task.FromResult(response);
        }

        public async Task<UpdateProductResponse> DeleteTool(Guid id)
        {
            var toolEntity = await _toolRepository.GetByIdAsync(id);

            InactivateProduct(toolEntity);

            UpdateProductResponse response = new()
            {
                LastUpdate = await _toolRepository.UpdateByIdAsync(toolEntity, toolEntity.Id)
            };

            return await Task.FromResult(response);
        }

        private void ProcessUpdate(UpdateProductRequest request, Tool toolEntity)
        {
            if (!string.IsNullOrEmpty(request.ToolName) && request.ToolName != "string")
            {
                toolEntity.Name = request.ToolName;
            }
            if (!string.IsNullOrWhiteSpace(request.ToolDescription) && request.ToolDescription != "string") 
            {
                toolEntity.Description = request.ToolDescription;
            }
            if(!string.IsNullOrWhiteSpace(request.ToolCategory ) && request.ToolCategory != "string")
            {
                toolEntity.Category = request.ToolCategory;
            }
            if(request.ToolPrice != 0)
            {
                toolEntity.Price = request.ToolPrice;
            }
            toolEntity.LastUpdate = DateTime.UtcNow;            
        }

        private static BasicProduct FromEntityTOBasicResponse(Tool toolEntity)
        {
            
            BasicProduct basicTool = new()
            {
                Id = toolEntity.Id,
                Category = toolEntity.Category,
                Description = toolEntity.Description,
                IsActive = toolEntity.IsActive,                
                Price = toolEntity.Price,               
                LastUpdate = toolEntity.LastUpdate
            };

            return basicTool;
        }

        private void InactivateProduct(Tool toolEntity)
        {
            toolEntity.IsActive = false;
            toolEntity.LastUpdate = DateTime.UtcNow;
        }
        private void ActivateProduct(Tool toolEntity)
        {
            toolEntity.IsActive = true;
            toolEntity.LastUpdate = DateTime.UtcNow;
        }      
        

        public async Task ActivateAll()
        {
            var toolsEntity = await _toolRepository.GetAsync();           

            foreach (Tool tool in toolsEntity)
            {
                FromEntityTOBasicResponse(tool);
                if (!tool.IsActive)
                {
                    ActivateProduct(tool);
                    await _toolRepository.UpdateByIdAsync(tool, tool.Id);
                    Console.WriteLine(tool.Id);
                }
            }
        }
    }
}
