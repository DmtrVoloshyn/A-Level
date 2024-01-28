using Salad.Extensions;
using Salad.Services;

namespace Salad
{
    public class App
    {
        private readonly VegetablesService _vegetablesService;
        private readonly KitchenService _kitchenService;

        public App(VegetablesService vegetablesService, KitchenService kitchenService)
        {
            _vegetablesService = vegetablesService;
            _kitchenService = kitchenService;
        }

        public void Start()
        {
            _vegetablesService.CreateVegetables();
            var vegetables = _vegetablesService.GetVegetables();
            var vegetableSalad = _kitchenService.CreateVegatableSalad(vegetables);
            var saladInfo = _kitchenService.GetSaladInfo();
            saladInfo.DisplaySaladInfo();
            var sortedSaladByCalories = vegetableSalad.SortByCalories();
            sortedSaladByCalories.DisplaySalad();
        }
    }
}

