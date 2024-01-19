using CandyGift.Enums;

namespace CandyGift.Models.Candies
{
    public abstract class ChocolateCandy : Candy
    {
        protected ChocolateCandy(int weight, string manufacturer, bool isHandMade,
            bool isFruitTaste, bool isWithFilling, string name)
            : base(weight, manufacturer, isHandMade, isFruitTaste, isWithFilling, name)
        {
            ChocolateType = ChocolateType.Milk;
        }

        public ChocolateType ChocolateType { get; set; }
    }

}

