using System;
using Collection.Entities;
using Collection.Models;

namespace Collection.Repositories
{
	public interface IOrderRepository
	{
        Guid AddOrder(OrderEntity order);
        List<OrderEntity> GetOrders();
    }
}

