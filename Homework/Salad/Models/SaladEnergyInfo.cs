namespace Salad.Models
{
    public class SaladEnergyInfo
    {
        public int TotalCalories { get; set; }
        public int TotalProtein { get; set; }
        public int TotalCarbohydrates { get; set; }
        public int TotalFats { get; set; }

        public void DisplaySaladInfo()
        {
            Console.WriteLine($"Total Calories: {TotalCalories}");
            Console.WriteLine($"Total Protein: {TotalProtein}");
            Console.WriteLine($"Total Carbohydrates: {TotalCarbohydrates}");
            Console.WriteLine($"Total Fats: {TotalFats}");
        }
    }
}

