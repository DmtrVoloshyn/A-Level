using System;
using Delivery.Enums;

namespace Delivery.Models
{
	public class Drug : Item
	{
		public Drug()
		{
            Item = ItemType.Drug;
		}
		public bool IsUrgent { get; set; }
		public bool IsReceiptRequired { get; set; }
	}
}

