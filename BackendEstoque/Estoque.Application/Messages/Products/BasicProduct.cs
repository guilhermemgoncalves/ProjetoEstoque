using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages
{
    public class BasicProduct
    {
        public Guid Id { get; set; }       
        public string? Description { get; set; } 
        public string? Category { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; }
        public string Location { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
