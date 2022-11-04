using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Repository
{
    public interface IToolRepository
    {
        Task<List<Tool>> GetAsync();        
        Task<Tool> GetByIdAsync(Guid id);
        Task UpdateByIdAsync(Tool newTool, Guid id);
        Task DeleteByIdAsync(Guid id);
        Task CreateAsync(Tool newTool);
    }
}
