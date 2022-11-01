using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.MockEntity
{
    public class Tool
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> Tags { get; set; } = new();
        public decimal Price { get; set; }
        public DateTime DateRegistry { get; set; }
    }	
}
