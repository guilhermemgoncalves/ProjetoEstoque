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

        private Order OrderToEntity(CreateOrderRequest request)
        {

            var OrderEntity = new Order()
            {
                Id = Guid.NewGuid(),
                CostumerId = request.CostuemerId,
                OrderDate = request.OrderDate,
                 OrderTools =  request.OrderTools
            };

            return OrderEntity;
        }

    }
}
