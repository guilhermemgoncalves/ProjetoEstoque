using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Entities
{
    public class Costumer
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("_id")]
        public string Prontuario { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Type { get; set; } = null!;

    }
}
