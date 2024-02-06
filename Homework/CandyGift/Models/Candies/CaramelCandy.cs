namespace CandyGift.Models.Candies
{
    public abstract class CaramelCandy : Candy
    {
        protected CaramelCandy(int weight, string manufacturer, bool isHandMade,
            bool isFruitTaste, bool isWithFilling, bool isSoftCaramel, string name)
            : base(weight, manufacturer, isHandMade, isFruitTaste, isWithFilling, name)
        {
            IsSoftCaramel = isSoftCaramel;
        }

        public bool IsSoftCaramel { get; set; }
    }
}

