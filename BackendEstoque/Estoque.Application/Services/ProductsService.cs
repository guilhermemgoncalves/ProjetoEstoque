
using CsvHelper;
using Estoque.Application.Converters;
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
    public class ProductsService :  IProductsService
    {
        private readonly IProductRepository _consumablesRepository;
        public ProductsService(IProductRepository consumablesRepository)
        {
            _consumablesRepository = consumablesRepository;
        }

        public async Task<CreateProductResponse> CreateTool(CreateProductRequest request)
        {
            var productEntity = new Product()
            {
                Id = Guid.NewGuid(),
                Category = request.ToolCategory,
                DateRegistry = DateTime.UtcNow,
                Description = request.ToolDescription,
                IsActive = true,
                Price = request.ToolPrice,
                LastUpdate = DateTime.UtcNow,
            };

            await _consumablesRepository.CreateAsync(productEntity);

            CreateProductResponse response = new()
            {
                Id = productEntity.Id,
                DateRegistry = productEntity.DateRegistry,
                IsActive = productEntity.IsActive
            };

            return response;
        }

        public async Task<GetProductByIDResponse> GetToolById(Guid Id)
        {
            var productEntity = await _consumablesRepository.GetByIdAsync(Id);
            var response = new GetProductByIDResponse();

            if(productEntity == null)
            {
               return await Task.FromResult(response);
            }

            response.BasicToolResponse = FromEntityTOBasicResponse(productEntity);
           
            return await Task.FromResult(response);
        }

        public async Task<GetProductResponse> GetTools(string toolStatus)
        {

            var consumablesEntity = await _consumablesRepository.GetAsync();
            GetProductResponse response = new();

            foreach (Product consumables in consumablesEntity)
            {
                BasicProduct basicToolResponse = FromEntityTOBasicResponse(consumables);

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

        public async Task<UpdateProductResponse> UpdateTool(UpdateProductRequest request)
        {
            var consumables = await _consumablesRepository.GetByIdAsync(request.Id);

            if(consumables == null)
            {
                return new UpdateProductResponse();
            }

            ProcessUpdate(request, consumables);

            UpdateProductResponse response = new()
            {
                LastUpdate = await _consumablesRepository.UpdateByIdAsync(consumables, consumables.Id)
            };

            return await Task.FromResult(response);
        }

        public async Task<UpdateProductResponse> DeleteTool(Guid id)
        {
            var productEntity = await _consumablesRepository.GetByIdAsync(id);

            InactivateProduct(productEntity);

            UpdateProductResponse response = new()
            {
                LastUpdate = await _consumablesRepository.UpdateByIdAsync(productEntity, productEntity.Id)
            };

            return await Task.FromResult(response);
        }

        private void ProcessUpdate(UpdateProductRequest request, Product productEntity)
        {

            if (!string.IsNullOrWhiteSpace(request.ToolDescription) && request.ToolDescription != "string")
            {
                productEntity.Description = request.ToolDescription;
            }
            if (!string.IsNullOrWhiteSpace(request.ToolCategory) && request.ToolCategory != "string")
            {
                productEntity.Category = request.ToolCategory;
            }
            if (request.ToolPrice != 0)
            {
                productEntity.Price = request.ToolPrice;
            }
            productEntity.LastUpdate = DateTime.UtcNow;
        }

        private static BasicProduct FromEntityTOBasicResponse(Product consumablesEntity)
        {

            BasicProduct basicTool = new()
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

        private void InactivateProduct(Product consumablesEntity)
        {
            consumablesEntity.IsActive = false;
            consumablesEntity.LastUpdate = DateTime.UtcNow;
        }
        private void ActivateProduct(Product consumablesEntity)
        {
            consumablesEntity.IsActive = true;
            consumablesEntity.LastUpdate = DateTime.UtcNow;
        }


        public async Task ActivateAll()
        {
            var consumablesEntity = await _consumablesRepository.GetAsync();

            foreach (Product consumables in consumablesEntity)
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

        public async Task<string> ReadCSV<T>(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<ProductsCSV>();
            ProductsConverter consumablesConverter = new();

            int i = 0;

            foreach (var record in records)
            {
                var consumablesEntity = consumablesConverter.ConvertToProduct(record);
                await _consumablesRepository.CreateAsync(consumablesEntity);
                i++;
            }
            return $"Foram adicionados {i} registros com sucesso!";
        }


    }
}
