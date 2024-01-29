using System;
using Delivery.Enums;

namespace Delivery.Entities
{
	public class ItemEntity
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ItemType Item { get; set; }
    }
}

