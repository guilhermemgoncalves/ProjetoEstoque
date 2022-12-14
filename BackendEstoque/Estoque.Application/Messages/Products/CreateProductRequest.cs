using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages
{
    public class CreateProductRequest
    {        
        public string ToolName { get; set; } = null!;
        public string? ToolDescription { get; set; } = null!;
        public string ToolCategory { get; set; } = null!;
        public decimal ToolPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
