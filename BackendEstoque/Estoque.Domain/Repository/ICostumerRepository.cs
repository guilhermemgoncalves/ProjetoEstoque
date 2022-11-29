using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Repository
{
    public interface ICostumerRepository
    {
        Task CreateAsync(Costumer newCostumer);
        Task<List<Costumer>> GetAsync();
        Task<Costumer> GetByIdAsync(string id);
    }
}
