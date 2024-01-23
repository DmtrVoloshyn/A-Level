namespace Salad.Models
{
	public interface IIngredient
	{
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Сarbohydrates { get; set; }
        public int Fats { get; set; }
    }
}
