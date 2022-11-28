﻿using Estoque.Domain.Entities;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _toolCollection;

        public OrderRepository(IOptions<EstoqueDbSettings> estoqueSettings)
        {
            var mongoClient = new MongoClient(estoqueSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(estoqueSettings.Value.DatabaseName);
            _toolCollection = mongoDatabase.GetCollection<Order>(estoqueSettings.Value.OrderCollectionName);
            
        }

        public async Task CreateAsync(Order newTool)
        {
            await _toolCollection.InsertOneAsync(newTool);
        }

        public async Task<List<Order>> GetAsync()
        {
            return await _toolCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _toolCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

      
    }
}
