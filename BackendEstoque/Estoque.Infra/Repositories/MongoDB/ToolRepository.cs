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

        public Task CreateAsync(Tool newTool)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tool>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tool> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateByIdAsync(Tool newTool, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
