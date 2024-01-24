namespace CandyGift.Models.Cookies
{
    public abstract class OatmealCookie : Cookie
    {
        protected OatmealCookie(int weight, string manufacturer, bool hasChocolateChips, bool isVegan,
                              int oatmealAmount, bool hasNuts, string name)
            : base(weight, manufacturer, name, hasChocolateChips, isVegan)
        {
            OatmealAmount = oatmealAmount;
            HasNuts = hasNuts;
        }

        public int OatmealAmount { get; set; }
        public bool HasNuts { get; set; }
    }
}

