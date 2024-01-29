using System;
using Delivery.Entities;
using Delivery.Repositories.Abstractions;

namespace Delivery.Repositories
{
	public class ItemRepository : IItemRepository
	{
		public ItemRepository()
		{
		}

        public ItemEntity[] GetItems()
        {
            throw new NotImplementedException();
        }
    }
}

