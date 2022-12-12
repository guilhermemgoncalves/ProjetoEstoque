using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Repository
{
    public interface IConsumablesRepository
    {
        Task<List<Consumables>> GetAsync();        
        Task<Consumables> GetByIdAsync(Guid id);
        Task<DateTime> UpdateByIdAsync(Consumables updatedConsumable, Guid id);
        Task DeleteByIdAsync(Guid id);
        Task CreateAsync(Consumables newConsumable);
    }
}
