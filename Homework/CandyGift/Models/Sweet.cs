namespace CandyGift.Models
{
    public abstract class Sweet
    {
        protected Sweet(int weight, string manufacturer)
        {
            Weight = weight;
            Manufacturer = manufacturer;
        }

        public int Weight { get; set; }
        public string Manufacturer { get; set; }
    }
}
