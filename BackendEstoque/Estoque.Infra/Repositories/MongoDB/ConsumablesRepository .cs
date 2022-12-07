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
    public class ConsumablesRepository : IConsumablesRepository
    {
        private readonly IMongoCollection<Consumables> _consumablesCollection;

        public ConsumablesRepository(IOptions<EstoqueDbSettings> estoqueSettings)
        {
            var mongoClient = new MongoClient(estoqueSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(estoqueSettings.Value.DatabaseName);
            _consumablesCollection = mongoDatabase.GetCollection<Consumables>(estoqueSettings.Value.ConsumablesCollectionName);
            
        }

        public async Task CreateAsync(Consumables
            newConsumables)
        {
            await _consumablesCollection.InsertOneAsync(newConsumables);
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Consumables>> GetAsync()
        {
            return await _consumablesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Consumables> GetByIdAsync(Guid id)
        {
            return await _consumablesCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public async Task<DateTime> UpdateByIdAsync(Consumables newConsumables, Guid id)
        {
            await _consumablesCollection.ReplaceOneAsync(_=>_.Id == id, newConsumables );
            return newConsumables.LastUpdate;
        }      
    }
}
