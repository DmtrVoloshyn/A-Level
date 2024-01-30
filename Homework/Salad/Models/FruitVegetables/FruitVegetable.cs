namespace Salad.Models
{
	public abstract class FruitVegetable : Vegetable
	{
		public FruitVegetable(bool hasFruit,
            bool isEdible,
            string name,
            int calories,
            int protein,
            int carbohydrates,
            int fats, bool isSweet, string color, double weight)
			: base(hasFruit, isEdible, name, calories, protein, carbohydrates, fats, weight)
		{
            IsSweet = isSweet;
            Color = color;
            Weight = weight;
        }

		public bool IsSweet { get; set; }
        public string Color { get; set; }
    }
}

