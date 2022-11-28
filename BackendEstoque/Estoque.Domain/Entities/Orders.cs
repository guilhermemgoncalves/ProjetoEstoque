using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Entities
{
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("_id")]
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public List<ToolOrder> OrderTools { get; set; } = new List<ToolOrder>();
        public string CostumerId { get; set; } = null!;

    }

    public class ToolOrder
    {
        public string ToolId { get; set; } = null!;
        public int Amount { get; set; } 
    }


}
