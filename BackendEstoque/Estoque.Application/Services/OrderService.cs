using Estoque.Application.Interfaces;
using Estoque.Application.Messages.Order;
using Estoque.Domain.Entities;
using Estoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IToolService _toolService;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IToolService toolService, IOrderRepository orderRepository)
        {
            _toolService = toolService;
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrder(CreateOrderRequest request)
        {
             var OrderEntity = OrderToEntity(request);                
            await _orderRepository.CreateAsync(OrderEntity);

            return true;
        }

        private Orders OrderToEntity(CreateOrderRequest request)
        {

            var OrderEntity = new Orders()
            {
                Id = Guid.NewGuid(),
                CostumerId = request.CostuemerId,
                OrderDate = DateTime.UtcNow,
                OrderTools =  request.OrderTools
            };

            return OrderEntity;
        }

    }
}
