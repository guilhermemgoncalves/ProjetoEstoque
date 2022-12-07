
using CsvHelper;
using Estoque.Application.Interfaces;
using Estoque.Application.Messages;
using Estoque.Domain.Entities;
using Estoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Services
{
    public class ConsumablesService :  IConsumablesService
    {
        private readonly IConsumablesRepository _consumablesRepository;
        public ConsumablesService(IConsumablesRepository consumablesRepository)
        {
            _consumablesRepository = consumablesRepository;
        }

        public async Task<CreateToolResponse> CreateTool(CreateToolRequest request)
        {
            var consumablesEntity = new Domain.Entities.Consumables()
            {
                Id = Guid.NewGuid(),
                Category = request.ToolCategory,
                DateRegistry = DateTime.UtcNow,
                Description = request.ToolDescription,
                IsActive = true,
                Price = request.ToolPrice,
                LastUpdate = DateTime.UtcNow,
            };

            await _consumablesRepository.CreateAsync(consumablesEntity);

            CreateToolResponse response = new()
            {
                Id = consumablesEntity.Id,
                DateRegistry = consumablesEntity.DateRegistry,
                IsActive = consumablesEntity.IsActive
            };

            return response;
        }

        public async Task<GetToolByIDResponse> GetToolById(Guid Id)
        {
            var consumablesEntity = await _consumablesRepository.GetByIdAsync(Id);

            GetToolByIDResponse response = new()
            {
                BasicToolResponse = FromEntityTOBasicResponse(consumablesEntity)
            };

            return await Task.FromResult(response);
        }

        public async Task<GetToolsResponse> GetTools(string toolStatus)
        {

            var consumablesEntity = await _consumablesRepository.GetAsync();
            GetToolsResponse response = new();

            foreach (Domain.Entities.Consumables consumables in consumablesEntity)
            {
                BasicToolResponse basicToolResponse = FromEntityTOBasicResponse(consumables);

                if (toolStatus == "true")
                {
                    if (basicToolResponse.IsActive == true)
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

        public async Task<UpdateToolResponse> UpdateTool(UpdateToolRequest request)
        {
            var consumables = await _consumablesRepository.GetByIdAsync(request.Id);

            ProcessUpdate(request, consumables);

            UpdateToolResponse response = new()
            {
                LastUpdate = await _consumablesRepository.UpdateByIdAsync(consumables, consumables.Id)
            };

            return await Task.FromResult(response);
        }

        public async Task<UpdateToolResponse> DeleteTool(Guid id)
        {
            var consumablesEntity = await _consumablesRepository.GetByIdAsync(id);

            InactivateProduct(consumablesEntity);

            UpdateToolResponse response = new()
            {
                LastUpdate = await _consumablesRepository.UpdateByIdAsync(consumablesEntity, consumablesEntity.Id)
            };

            return await Task.FromResult(response);
        }

        private void ProcessUpdate(UpdateToolRequest request, Domain.Entities.Consumables consumablesEntity)
        {

            if (!string.IsNullOrWhiteSpace(request.ToolDescription) && request.ToolDescription != "string")
            {
                consumablesEntity.Description = request.ToolDescription;
            }
            if (!string.IsNullOrWhiteSpace(request.ToolCategory) && request.ToolCategory != "string")
            {
                consumablesEntity.Category = request.ToolCategory;
            }
            if (request.ToolPrice != 0)
            {
                consumablesEntity.Price = request.ToolPrice;
            }
            consumablesEntity.LastUpdate = DateTime.UtcNow;
        }

        private static BasicToolResponse FromEntityTOBasicResponse(Domain.Entities.Consumables consumablesEntity)
        {

            BasicToolResponse basicTool = new()
            {
                Id = consumablesEntity.Id,
                Category = consumablesEntity.Category,
                Description = consumablesEntity.Description,
                IsActive = consumablesEntity.IsActive,
                Price = consumablesEntity.Price,
                LastUpdate = consumablesEntity.LastUpdate
            };

            return basicTool;
        }

        private void InactivateProduct(Domain.Entities.Consumables consumablesEntity)
        {
            consumablesEntity.IsActive = false;
            consumablesEntity.LastUpdate = DateTime.UtcNow;
        }
        private void ActivateProduct(Domain.Entities.Consumables consumablesEntity)
        {
            consumablesEntity.IsActive = true;
            consumablesEntity.LastUpdate = DateTime.UtcNow;
        }


        public async Task ActivateAll()
        {
            var consumablesEntity = await _consumablesRepository.GetAsync();

            foreach (Domain.Entities.Consumables consumables in consumablesEntity)
            {
                FromEntityTOBasicResponse(consumables);
                if (!consumables.IsActive)
                {
                    ActivateProduct(consumables);
                    await _consumablesRepository.UpdateByIdAsync(consumables, consumables.Id);
                    Console.WriteLine(consumables.Id);
                }
            }
        }

        public async Task<IEnumerable<T>> ReadCSV<T>(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<T>();
            return records;
        }
    }
}
