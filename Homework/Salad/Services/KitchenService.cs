using Salad.Models;
using Salad.Models.FruitVegetables;
using Salad.Models.LeafyVegetables;

namespace Salad.Services
{
	public class KitchenService
	{
        private List<Vegetable> saladIngredients = new List<Vegetable>();

        public Vegetable[] CreateVegatableSalad(Vegetable[] vegetables)
        {
            int redTomatoCount = VegetableSaladRecipe.RedTomatoCount;
            int yellowTomatoCount = VegetableSaladRecipe.YellowTomatoCount;
            int sweetPepperCount = VegetableSaladRecipe.SweetPepperCount;
            int cucumberCount = VegetableSaladRecipe.CucumberCount;
            int basilCount = VegetableSaladRecipe.BasilCount;
            int onionCount = VegetableSaladRecipe.OnionCount;

            foreach (var vegetable in vegetables)
            {
                switch (vegetable)
                {
                    case RedTomato _ when redTomatoCount > 0:
                        saladIngredients.Add(vegetable);
                        redTomatoCount--;
                        break;
                    case YellowTomato _ when yellowTomatoCount > 0:
                        saladIngredients.Add(vegetable);
                        yellowTomatoCount--;
                        break;
                    case SweetPepper _ when sweetPepperCount > 0:
                        saladIngredients.Add(vegetable);
                        sweetPepperCount--;
                        break;
                    case Cucumber _ when cucumberCount > 0:
                        saladIngredients.Add(vegetable);
                        cucumberCount--;
                        break;
                    case Basil _ when basilCount > 0:
                        saladIngredients.Add(vegetable);
                        basilCount--;
                        break;
                    case GreenOnion _ when onionCount > 0:
                        saladIngredients.Add(vegetable);
                        onionCount--;
                        break;
                }

                if (redTomatoCount == 0 && yellowTomatoCount == 0 && sweetPepperCount == 0 &&
                    cucumberCount == 0 && basilCount == 0 && onionCount == 0)
                {
                    break;
                }
            }

            return saladIngredients.ToArray();
        }

        public SaladEnergyInfo GetSaladInfo() => CalculateEnergyValues(saladIngredients);

        private SaladEnergyInfo CalculateEnergyValues(List<Vegetable> saladIngredients)
        {
            SaladEnergyInfo saladEnergyInfo = new SaladEnergyInfo();

            foreach (var vegetable in saladIngredients)
            {

                saladEnergyInfo.TotalCalories += vegetable.Calories;
                saladEnergyInfo.TotalProtein += vegetable.Protein;
                saladEnergyInfo.TotalCarbohydrates += vegetable.Сarbohydrates;
                saladEnergyInfo.TotalFats += vegetable.Fats;
            }

            return saladEnergyInfo;
        }
    }
}

