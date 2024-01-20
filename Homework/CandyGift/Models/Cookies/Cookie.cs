namespace CandyGift.Models.Cookies
{
    public abstract class Cookie : Sweet
    {
        protected Cookie(int weight, string manufacturer, string name, bool hasChocolateChips, bool isVegan) : base(weight, manufacturer, name)
        {
            HasChocolateChips = hasChocolateChips;
            IsVegan = isVegan;
        }

        public bool HasChocolateChips { get; set; }
        public bool IsVegan { get; set; }
    }
}

