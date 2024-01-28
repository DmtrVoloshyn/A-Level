namespace Salad.Models.LeafyVegetables
{
    public abstract class LeafyVegetable : Vegetable
    {
        public LeafyVegetable(bool hasFruit,
            bool isEdible,
            string name,
            int calories,
            int protein,
            int carbohydrates,
            int fats, bool hasEdibleSkin, double weight)
            : base(hasFruit, isEdible, name, calories, protein, carbohydrates, fats, weight)
        {
            HasEdibleSkin = hasEdibleSkin;
        }

        public bool HasEdibleSkin { get; set; }
    }
}
