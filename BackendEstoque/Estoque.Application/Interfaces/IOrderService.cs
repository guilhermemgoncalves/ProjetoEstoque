using Estoque.Application.Messages.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(CreateOrderRequest request);
    }
}
