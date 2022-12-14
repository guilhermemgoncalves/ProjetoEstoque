using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages
{
    public class CreateProductResponse
    {
        public Guid Id { get; set; }       
        public bool IsActive { get; set; }
        public DateTime DateRegistry { get; set; }
    }
}
