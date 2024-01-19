namespace CandyGift.Models
{
    public abstract class Sweet
    {
        protected Sweet(int weight, string manufacturer, string name)
        {
            Weight = weight;
            Manufacturer = manufacturer;
            Name = name;
        }

        public int Weight { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
    }
}
