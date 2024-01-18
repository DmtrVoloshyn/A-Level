using CandyGift.Enums;

namespace CandyGift.Models.Cookies
{
    public class ChocolateCookie : Cookie
    {
        protected ChocolateCookie(int weight, string manufacturer, bool hasChocolateChips, bool isVegan,
            int chocolateWeight, ChocolateType chocolateType)
            : base(weight, manufacturer, hasChocolateChips, isVegan)
        {
            ChocolateWeight = chocolateWeight;
            ChocolateType = chocolateType;
        }

        public int ChocolateWeight { get; set; }
        public ChocolateType ChocolateType { get; set; }
    }
}

