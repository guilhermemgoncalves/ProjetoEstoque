using Estoque.Domain.Entities;
using Estoque.Domain.Repository;
using Estoque.Infra.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Infra.Repositories.MongoDB
{
    public class CostumerRepository : ICostumerRepository
    {
        private readonly IMongoCollection<Costumer> _costumerCollection;

        public CostumerRepository(IOptions<EstoqueDbSettings> estoqueSettings)
        {
            var mongoClient = new MongoClient(estoqueSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(estoqueSettings.Value.DatabaseName);
            _costumerCollection = mongoDatabase.GetCollection<Costumer>(estoqueSettings.Value.CostumerCollectionName);

        }

        public async Task CreateAsync(Costumer newCostumer)
        {
            await _costumerCollection.InsertOneAsync(newCostumer);
        }

        public async Task<List<Costumer>> GetAsync()
        {
            return await _costumerCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Costumer> GetByIdAsync(string id)
        {
            return await _costumerCollection.Find(_ => _.Prontuario == id).FirstOrDefaultAsync();
        }


    }
}
