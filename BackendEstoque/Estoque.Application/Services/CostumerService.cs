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

        public async Task<bool> CreateCostumer(Costumer costumer)
        {
            await _costumerRepository.CreateAsync(costumer);

            return true;
        }

        public async Task<List<Costumer>> GetAll()
        {
            return await _costumerRepository.GetAsync();
        }

        public async Task<Costumer> GetById(string prontuario)
        {
            return await _costumerRepository.GetByIdAsync(prontuario);
        }
    }
}
