using System;
using Collection.Models;
using Collection.Services.Abstractions;

namespace Collection
{
	public class Startup
	{
		private readonly IOrderService _orderService;

		public Startup(IOrderService orderService)
		{
			_orderService = orderService;
		}

		public void Start()
		{
			AddOrder();
			GetOrders();
		}

		private void AddOrder()
		{
			Console.WriteLine("Is this order emergensy?");
			var input = Console.ReadLine();

			var order = new Order()
			{
				CreatedAt = DateTime.UtcNow
			};

			if (input?.ToLower().Trim().Equals("y") ?? false)
			{
				order.IsEmergensy = true;
			}

			var id = _orderService.AddOrder(order);

			Console.WriteLine($"Your order number is: {id}");
		}

		private void GetOrders()
		{
			var orders = _orderService.GetOrders();

			Console.WriteLine($"Your recent orders: ");

			foreach (var order in orders)
			{
				Console.WriteLine(order.ToString());
			}
		}
	}
}

