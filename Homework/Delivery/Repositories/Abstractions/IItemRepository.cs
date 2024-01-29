using System;
using Delivery.Entities;

namespace Delivery.Repositories.Abstractions
{
	public interface IItemRepository
	{
		ItemEntity[] GetItems();
	}
}

