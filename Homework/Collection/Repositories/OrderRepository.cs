using System;
using Collection.Entities;

namespace Collection.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private List<OrderEntity> Orders;

        public OrderRepository()
        {
            Orders = new List<OrderEntity>()
                    {
                        new OrderEntity()
                        {
                            Id = Guid.NewGuid(),
                            CreatedAt = DateTime.UtcNow,
                            IsEmergensy = true
                        },
                        new OrderEntity()
                        {
                            Id = Guid.NewGuid(),
                            CreatedAt = DateTime.UtcNow,
                            IsEmergensy = true
                        },
                        new OrderEntity()
                        {
                            Id = Guid.NewGuid(),
                            CreatedAt = DateTime.UtcNow.AddHours(3),
                            IsEmergensy = false
                        },
                        new OrderEntity()
                        {
                            Id = Guid.NewGuid(),
                            CreatedAt = DateTime.UtcNow.AddHours(2),
                            IsEmergensy = true
                        },
                        new OrderEntity()
                        {
                            Id = Guid.NewGuid(),
                            CreatedAt = DateTime.UtcNow.AddHours(1),
                            IsEmergensy = true
                        }
                    };
        }

        public Guid AddOrder(OrderEntity order)
        {
            order.Id = Guid.NewGuid();

            Orders.Add(order);

            return order.Id;
        }

        public List<OrderEntity> GetOrders()
        {
            return Orders;
        }
    }
}

