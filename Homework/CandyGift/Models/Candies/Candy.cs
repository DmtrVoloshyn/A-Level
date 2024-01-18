namespace CandyGift.Models.Candies
{
    public abstract class Candy : Sweet
    {
        protected Candy(int weight, string manufacturer, bool isHandMade,
            bool isFruitTaste, bool isWithFilling)
            : base(weight, manufacturer)
        {
            IsHandMade = isHandMade;
            IsFruitTaste = isFruitTaste;
            IsWithFilling = isWithFilling;
        }

        public bool IsHandMade { get; set; }
        public bool IsFruitTaste { get; set; }
        public bool IsWithFilling { get; set; }
    }
}

