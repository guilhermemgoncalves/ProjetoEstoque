using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("_id")]
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int Total { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } 
        public string Location { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateRegistry { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
