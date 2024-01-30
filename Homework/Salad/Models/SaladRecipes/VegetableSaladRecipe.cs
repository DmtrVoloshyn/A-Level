using Salad.Models.SaladRecipes;

namespace Salad.Models
{
    public class VegetableSaladRecipe : IRecipe
    {
        public static string Name { get; } = "Vegetable salad 2000";
		public static int RedTomatoCount { get; } = 2;
        public static int YellowTomatoCount { get; } = 3;
        public static int SweetPepperCount { get; } = 1;
        public static int CucumberCount { get; } = 1;
        public static int BasilCount { get; } = 1;
        public static int OnionCount { get; } = 1;
    }
}

