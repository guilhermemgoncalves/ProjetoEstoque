using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAsync();        
        Task<Product> GetByIdAsync(Guid id);
        Task<DateTime> UpdateByIdAsync(Product updateProduct, Guid id);
        Task DeleteByIdAsync(Guid id);
        Task CreateAsync(Product newProduct);
    }
}
