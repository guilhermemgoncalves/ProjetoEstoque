using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages.Order
{
    public class CreateOrderRequest
    {
        public DateTime OrderDate { get; set; }
        public List<ToolOrder> OrderTools { get; set; } = new ();
        public Guid CostuemerId { get; set; }

    }
}
