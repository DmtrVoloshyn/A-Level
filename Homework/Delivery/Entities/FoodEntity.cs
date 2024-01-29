using Delivery.Enums;

namespace Delivery.Entities
{
	public class FoodEntity : ItemEntity
	{
        public FoodEntity()
        {
            Item = ItemType.Food;
        }

        public bool IsHotDish { get; set; }
    }
}

