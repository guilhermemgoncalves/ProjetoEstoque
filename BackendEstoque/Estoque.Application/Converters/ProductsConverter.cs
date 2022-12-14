using Estoque.Application.Messages;
using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Converters
{
    public class ProductsConverter
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
                Location = productCsv.Location,
                Model = productCsv.Model,
                Price = productCsv.Price,
                Type = productCsv.Type,
                LastUpdate = DateTime.UtcNow,
                Total = productCsv.Total,

            };
            return product;
        }
    }
}
