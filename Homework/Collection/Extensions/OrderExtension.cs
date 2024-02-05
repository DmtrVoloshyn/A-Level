using System;
using Collection.Models;

namespace Collection.Extensions
{
	public static class OrderExtension
    {
		public static List<Order> SortByCreatedAt(this List<Order> orders)
		{
			int count = orders.Count;

			for (int gap = count/2; gap > 0; gap/=2)
			{
				for (int i = gap; i < count; i++)
				{
					var temp = orders[i];

					int j;

					for (j = i; j >= gap && orders[j - gap].CompareTo(temp) > 0; j -= gap)
					{
						orders[j] = orders[j - gap];
					}

					orders[j] = temp;
				}
			}

			return orders;
		} 
	}
}

