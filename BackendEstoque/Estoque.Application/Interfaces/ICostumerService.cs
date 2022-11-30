using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Interfaces
{
    public interface ICostumerService
    {
        Task<bool> CreateCostumer(Costumer costumer);
        Task<List<Costumer>> GetAll();
        Task<Costumer> GetById(string prontuario);
    }
}
