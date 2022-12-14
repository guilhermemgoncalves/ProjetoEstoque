using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages
{
    public class GetProductByIDResponse
    {
        public BasicProduct BasicToolResponse { get; set; } = new();
    }
}
