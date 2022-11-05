using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages
{
    public class CreateToolRequest
    {        
        public string ToolName { get; set; } = null!;
        public string? ToolDescription { get; set; } 
        public string ToolCategory { get; set; } = null!;
        public double ToolPrice { get; set; }
    }
}
