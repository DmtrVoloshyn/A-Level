using Delivery.Enums;

namespace Delivery.Models
{
	public class Food : Item
	{
		public Food()
		{
			Item = ItemType.Food;
		}
        public bool IsHotDish { get; set; }
	}
}

