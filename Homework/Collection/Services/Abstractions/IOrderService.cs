using System;
using Collection.Models;

namespace Collection.Services.Abstractions
{
	public interface IOrderService
	{
		Guid AddOrder(Order order);
		List<Order> GetOrders();
	}
}

