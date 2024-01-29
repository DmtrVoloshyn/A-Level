using System;
using Delivery.Enums;

namespace Delivery.Models
{
	public class Clothes : Item
	{
		public Clothes()
		{
            Item = ItemType.Clothes;
		}
	}
}

