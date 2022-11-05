using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Entities
{
    public class Tool
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("_id")]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 
        public string Category { get; set; } = null!;
        public List<string> Tags { get; set; } = new();
        public double Price { get; set; } 
        public bool IsActive { get; set; }
        public DateTime DateRegistry { get; set; }
    }	
}
