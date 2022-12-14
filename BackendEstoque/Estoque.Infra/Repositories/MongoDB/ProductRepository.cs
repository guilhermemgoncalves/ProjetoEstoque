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
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _ProductCollection;

        public ProductRepository(IOptions<EstoqueDbSettings> estoqueSettings)
        {
            var mongoClient = new MongoClient(estoqueSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(estoqueSettings.Value.DatabaseName);
            _ProductCollection = mongoDatabase.GetCollection<Product>(estoqueSettings.Value.ProductCollectionName);
            
        }

        public async Task CreateAsync(Product
            newProduct)
        {
            await _ProductCollection.InsertOneAsync(newProduct);
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _ProductCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _ProductCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public async Task<DateTime> UpdateByIdAsync(Product newProduct, Guid id)
        {
            await _ProductCollection.ReplaceOneAsync(_=>_.Id == id, newProduct );
            return newProduct.LastUpdate;
        }      
    }
}
