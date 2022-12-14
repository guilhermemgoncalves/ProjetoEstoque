using Estoque.Application.Messages;
using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Converters
{
    public class ProductHelpers
    {

        public Product ConvertToProduct(ProductsCSV productCsv )
        {
            Product product = new Product()
            {
                Brand =  productCsv.Brand,
                Category = productCsv.Category, 
                DateRegistry = DateTime.UtcNow,
                Description = productCsv.Description,
                IsActive = true,
                Type = productCsv.Type,
                LastUpdate = DateTime.UtcNow,
                Location = productCsv.Location,
                Model = productCsv.Model,
                Price = productCsv.Price,
                Total = productCsv.Total,

            };
            return product;
        }

        public Product ConvertToProduct(CreateProductRequest request)
        {
            Product product = new Product()
            {
                Brand = request.Brand,
                Location = request.Location,
                Model = request.Model,
                Type = request.Type,
                Category = request.Category,
                DateRegistry = DateTime.UtcNow,
                Description = request.Description,
                IsActive = true,
                Price = request.Price,
                LastUpdate = DateTime.UtcNow,
                Total = 0           

            };
            return product;
        }

        public BasicProduct FromEntityTOBasicResponse(Product productEntity)
        {

            BasicProduct basicProduct = new()
            {
                Id = productEntity.Id,
                Category = productEntity.Category,
                Description = productEntity.Description,
                IsActive = productEntity.IsActive,
                Price = productEntity.Price,
                LastUpdate = productEntity.LastUpdate,
                Brand = productEntity.Brand,
                Model = productEntity.Model,
                Location = productEntity.Location
            };

            return basicProduct;
        }
        public void InactivateProduct(Product productEntity)
        {
            productEntity.IsActive = false;
            productEntity.LastUpdate = DateTime.UtcNow;
        }
        public void ActivateProduct(Product productEntity)
        {
            productEntity.IsActive = true;
            productEntity.LastUpdate = DateTime.UtcNow;
        }
    }
}
