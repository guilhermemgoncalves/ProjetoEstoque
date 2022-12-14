
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
        private readonly IProductRepository _productsRepository;
        private readonly ProductHelpers _productHelpers = new();
        public ProductsService(IProductRepository consumablesRepository)
        {
            _productsRepository = consumablesRepository;
        }

        public async Task<CreateProductResponse> CreateTool(CreateProductRequest request)
        {
            var productEntity = _productHelpers.ConvertToProduct(request);

            await _productsRepository.CreateAsync(productEntity);
            //Adicionar a Helpers
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
            var productEntity = await _productsRepository.GetByIdAsync(Id);
            var response = new GetProductByIDResponse();

            if(productEntity == null)
            {
               return await Task.FromResult(response);
            }

            response.ProductResponse = _productHelpers.FromEntityTOBasicResponse(productEntity);
           
            return await Task.FromResult(response);
        }

        public async Task<GetProductResponse> GetTools(string toolStatus)
        {

            var productsEntity = await _productsRepository.GetAsync();
            GetProductResponse response = new();

            foreach (Product product in productsEntity)
            {
                BasicProduct ProductResponse = _productHelpers.FromEntityTOBasicResponse(product);

                if (toolStatus == "true")
                {
                    if (ProductResponse.IsActive == true)
                    {
                        response.BasicToolResponse.Add(ProductResponse);
                    }
                }
                if (toolStatus == "false")
                {
                    if (ProductResponse.IsActive == false)
                    {
                        response.BasicToolResponse.Add(ProductResponse);
                    }
                }
            }
            return await Task.FromResult(response);
        }

        public async Task<UpdateProductResponse> UpdateTool(UpdateProductRequest request)
        {
            var products = await _productsRepository.GetByIdAsync(request.Id);

            if(products == null)
            {
                return new UpdateProductResponse();
            }
            //Adicionar a Helpers
            UpdateProductResponse response = new()
            {
                LastUpdate = await _productsRepository.UpdateByIdAsync(products, products.Id)
            };

            return await Task.FromResult(response);
        }

        public async Task<UpdateProductResponse> DeleteTool(Guid id)
        {
            var productEntity = await _productsRepository.GetByIdAsync(id);

            _productHelpers.InactivateProduct(productEntity);
            //Adicionar a Helpers
            UpdateProductResponse response = new()
            {
                LastUpdate = await _productsRepository.UpdateByIdAsync(productEntity, productEntity.Id)
            };

            return await Task.FromResult(response);
        }

        public async Task ActivateAll()
        {
            var produtcsEntity = await _productsRepository.GetAsync();

            foreach (Product product in produtcsEntity)
            {
                _productHelpers.FromEntityTOBasicResponse(product);
                if (!product.IsActive)
                {
                    _productHelpers.ActivateProduct(product);
                    await _productsRepository.UpdateByIdAsync(product, product.Id);
                    Console.WriteLine(product.Id);
                }
            }
        }

        public async Task<string> ReadCSV<T>(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<ProductsCSV>();            

            int i = 0;

            foreach (var record in records)
            {
                var productsEntity = _productHelpers.ConvertToProduct(record);
                await _productsRepository.CreateAsync(productsEntity);
                i++;
            }
            return $"Foram adicionados {i} registros com sucesso!";
        }


    }
}
