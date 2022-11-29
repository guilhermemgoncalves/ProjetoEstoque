using Estoque.Application.Interfaces;
using Estoque.Domain.Entities;
using Estoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Services
{
    public class CostumerService : ICostumerService
    {
        private readonly ICostumerRepository _costumerRepository;
        public CostumerService(ICostumerRepository costumerRepository)
        {
            _costumerRepository = costumerRepository;
        }

        public Task<bool> CreateCostumer()
        {
            throw new NotImplementedException();
        }

        public Task<List<Costumer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Costumer> GetById(string prontuario)
        {
            throw new NotImplementedException();
        }
    }
}
