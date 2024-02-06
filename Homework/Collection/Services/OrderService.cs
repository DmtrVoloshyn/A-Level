using System;
using System.Linq;
using Collection.Entities;
using Collection.Extensions;
using Collection.Models;
using Collection.Repositories;
using Collection.Services.Abstractions;

namespace Collection.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Guid AddOrder(Order order)
        {
            var orderEntity = new OrderEntity()
            {
                CreatedAt = order.CreatedAt,
                IsEmergensy = order.IsEmergensy
            };

            var id = _orderRepository.AddOrder(orderEntity);

            return id;
        }

        public List<Order> GetOrders()
        {
            var orderEntities = _orderRepository.GetOrders();

            var orders = new List<Order>();

            foreach (var orderEntity in orderEntities)
            {
                orders.Add(new Order()
                {
                    Id = orderEntity.Id,
                    CreatedAt = orderEntity.CreatedAt,
                    IsEmergensy = orderEntity.IsEmergensy
                });
            }

            return orders;
        }

        public List<Order> GetOrders(bool isDesc)
        {
            return (!isDesc)
                ? GetOrders().SortByCreatedAt()
                : GetOrders();
        }

        //public List<Order> GetOrdersWithEmergensy(bool isDesc)
        //{
        //    var orders = GetOrders();

        //    var emergensyOrders = orders
        //        .Where(x => x.IsEmergensy)
        //        .ToList();

        //    orders.RemoveAll(item => emergensyOrders.Contains(item));

        //    emergensyOrder = emergensyOrders.SortByCreatedAt();

        //}
    }
}

