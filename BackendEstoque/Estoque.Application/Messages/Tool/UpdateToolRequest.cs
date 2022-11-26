using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages
{
    public class UpdateToolRequest
    {   
        public Guid Id { get; set; }
        public string? ToolName { get; set; } 
        public string? ToolDescription { get; set; }
        public string? ToolCategory { get; set; } 
        public double ToolPrice { get; set; }        
    }
}
