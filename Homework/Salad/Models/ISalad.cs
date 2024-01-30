using Salad.Models.SaladRecipes;

namespace Salad.Models
{
    public interface ISalad
    {
        public string Name { get; }
        public IRecipe recipe { get; set; }
    }
}

