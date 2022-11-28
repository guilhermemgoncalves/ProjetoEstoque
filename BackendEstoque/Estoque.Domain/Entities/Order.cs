using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("_id")]
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public List<ToolOrder> OrderTools { get; set; } = new List<ToolOrder>();
        public Guid CostumerId { get; set; } 

    }

    public class ToolOrder
    {
        public Guid ToolId { get; set; }
        public int Amount { get; set; }
    }


}
