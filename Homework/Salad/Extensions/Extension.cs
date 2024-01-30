using Salad.Models;

namespace Salad.Extensions
{
	public static class Extension
	{
		public static Vegetable[] SortByCalories(this Vegetable[] vegetables)
		{
			return vegetables.OrderBy(vegetable => vegetable.Calories).ToArray();
        }

        public static void DisplaySalad(this Vegetable[] vegetables)
        {
            Console.WriteLine("\n");
            foreach (var vegetable in vegetables)
            {
                Console.WriteLine($"{vegetable.Name} - {vegetable.Calories} calories");
            }
        }
    }
}

