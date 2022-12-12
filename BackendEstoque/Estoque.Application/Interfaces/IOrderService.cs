using Estoque.Application.Messages.Order;
using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Interfaces;

public interface IOrderService
{
    Task<bool> CreateOrder(CreateOrderRequest request);
    Task<List<Orders>> GetAll();
    Task<Orders> GetById(Guid id);

}
