using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAsync();
        Task<Order> GetByIdAsync(Guid id);              
        Task CreateAsync(Order newOrder);
    }
}
