namespace Salad.Models
{
	public abstract class Vegetable : Flora, IIngredient
    {
		protected Vegetable(bool hasFruit,
            bool isEdible,
            string name,
            int calories,
            int protein,
            int carbohydrates,
            int fats,
            double weight) : base(hasFruit, isEdible)
		{
            Name = name;
            Calories = calories;
            Protein = protein;
            Сarbohydrates = carbohydrates;
            Fats = fats;
            Weight = weight;
        }

        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Сarbohydrates { get; set; }
        public int Fats { get; set; }
        public double Weight { get; set; }
    }
}

