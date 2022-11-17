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
    public class ToolRepository : IToolRepository
    {
        private readonly IMongoCollection<Tool> _toolCollection;

        public ToolRepository(IOptions<EstoqueDbSettings> estoqueSettings)
        {
            var mongoClient = new MongoClient(estoqueSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(estoqueSettings.Value.DatabaseName);
            _toolCollection = mongoDatabase.GetCollection<Tool>(estoqueSettings.Value.ToolCollectionName);

        }

        public async Task CreateAsync(Tool newTool)
        {
            await _toolCollection.InsertOneAsync(newTool);
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tool>> GetAsync()
        {
            return await _toolCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Tool> GetByIdAsync(Guid id)
        {
            return await _toolCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public Task UpdateByIdAsync(Tool newTool, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
