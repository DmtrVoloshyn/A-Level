namespace Salad.Entities
{
	public class VegetableEntity : IEntity
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Сarbohydrates { get; set; }
        public int Fats { get; set; }
        public double Weight { get; set; }
    }
}

