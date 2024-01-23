using Salad.Entities.FruitVegetablesEntity;
using Salad.Entities.LeafyVegetablesEntity;
using Salad.Models;
using Salad.Models.FruitVegetables;
using Salad.Models.LeafyVegetables;

namespace Salad.Converters
{
    public static class ModelConverter
    {
        public static CucumberEntity ToEntity(this Cucumber cucumber)
        {
            return new CucumberEntity
            {
                Name = cucumber.Name,
                Id = Guid.NewGuid(),
                Weight = cucumber.Weight,
                IsSweet = cucumber.IsSweet,
                Calories = cucumber.Calories,
                Color = cucumber.Color,
                Fats = cucumber.Fats,
                Protein = cucumber.Protein,
                Сarbohydrates = cucumber.Сarbohydrates
            };
        }

        public static RedTomatoEntity ToEntity(this RedTomato redTomato)
        {
            return new RedTomatoEntity
            {
                Name = redTomato.Name,
                Id = Guid.NewGuid(),
                Weight = redTomato.Weight,
                IsSweet = redTomato.IsSweet,
                Calories = redTomato.Calories,
                Color = redTomato.Color,
                Fats = redTomato.Fats,
                Protein = redTomato.Protein,
                Сarbohydrates = redTomato.Сarbohydrates
            };
        }

        public static YellowTomatoEntity ToEntity(this YellowTomato yellowTomato)
        {
            return new YellowTomatoEntity
            {
                Name = yellowTomato.Name,
                Id = Guid.NewGuid(),
                Weight = yellowTomato.Weight,
                IsSweet = yellowTomato.IsSweet,
                Calories = yellowTomato.Calories,
                Color = yellowTomato.Color,
                Fats = yellowTomato.Fats,
                Protein = yellowTomato.Protein,
                Сarbohydrates = yellowTomato.Сarbohydrates
            };
        }

        public static SweetPepperEntity ToEntity(this SweetPepper sweetPepper)
        {
            return new SweetPepperEntity
            {
                Name = sweetPepper.Name,
                Id = Guid.NewGuid(),
                Weight = sweetPepper.Weight,
                IsSweet = sweetPepper.IsSweet,
                Calories = sweetPepper.Calories,
                Color = sweetPepper.Color,
                Fats = sweetPepper.Fats,
                Protein = sweetPepper.Protein,
                Сarbohydrates = sweetPepper.Сarbohydrates
            };
        }

        public static BasilEntity ToEntity(this Basil basil)
        {
            return new BasilEntity
            {
                Name = basil.Name,
                Id = Guid.NewGuid(),
                Weight = basil.Weight,
                HasEdibleSkin = basil.HasEdibleSkin,
                Calories = basil.Calories,
                Fats = basil.Fats,
                Protein = basil.Protein,
                Сarbohydrates = basil.Сarbohydrates
            };
        }

        public static GreenOnionEntity ToEntity(this GreenOnion greenOnion)
        {
            return new GreenOnionEntity
            {
                Name = greenOnion.Name,
                Id = Guid.NewGuid(),
                Weight = greenOnion.Weight,
                HasEdibleSkin = greenOnion.HasEdibleSkin,
                Calories = greenOnion.Calories,
                Fats = greenOnion.Fats,
                Protein = greenOnion.Protein,
                Сarbohydrates = greenOnion.Сarbohydrates
            };
        }

        public static Cucumber ToModel(this CucumberEntity cucumber)
        {
            return new Cucumber
            {
                Name = cucumber.Name,
                Weight = cucumber.Weight,
                IsSweet = cucumber.IsSweet,
                Calories = cucumber.Calories,
                Color = cucumber.Color,
                Fats = cucumber.Fats,
                Protein = cucumber.Protein,
                Сarbohydrates = cucumber.Сarbohydrates
            };
        }

        public static RedTomato ToModel(this RedTomatoEntity redTomato)
        {
            return new RedTomato
            {
                Name = redTomato.Name,
                Weight = redTomato.Weight,
                IsSweet = redTomato.IsSweet,
                Calories = redTomato.Calories,
                Color = redTomato.Color,
                Fats = redTomato.Fats,
                Protein = redTomato.Protein,
                Сarbohydrates = redTomato.Сarbohydrates
            };
        }

        public static YellowTomato ToModel(this YellowTomatoEntity yellowTomato)
        {
            return new YellowTomato
            {
                Name = yellowTomato.Name,
                Weight = yellowTomato.Weight,
                IsSweet = yellowTomato.IsSweet,
                Calories = yellowTomato.Calories,
                Color = yellowTomato.Color,
                Fats = yellowTomato.Fats,
                Protein = yellowTomato.Protein,
                Сarbohydrates = yellowTomato.Сarbohydrates
            };
        }

        public static SweetPepper ToModel(this SweetPepperEntity sweetPepper)
        {
            return new SweetPepper
            {
                Name = sweetPepper.Name,
                Weight = sweetPepper.Weight,
                IsSweet = sweetPepper.IsSweet,
                Calories = sweetPepper.Calories,
                Color = sweetPepper.Color,
                Fats = sweetPepper.Fats,
                Protein = sweetPepper.Protein,
                Сarbohydrates = sweetPepper.Сarbohydrates
            };
        }

        public static Basil ToModel(this BasilEntity basil)
        {
            return new Basil
            {
                Name = basil.Name,
                Weight = basil.Weight,
                HasEdibleSkin = basil.HasEdibleSkin,
                Calories = basil.Calories,
                Fats = basil.Fats,
                Protein = basil.Protein,
                Сarbohydrates = basil.Сarbohydrates
            };
        }

        public static GreenOnion ToModel(this GreenOnionEntity greenOnion)
        {
            return new GreenOnion
            {
                Name = greenOnion.Name,
                Weight = greenOnion.Weight,
                HasEdibleSkin = greenOnion.HasEdibleSkin,
                Calories = greenOnion.Calories,
                Fats = greenOnion.Fats,
                Protein = greenOnion.Protein,
                Сarbohydrates = greenOnion.Сarbohydrates
            };
        }
    }
}

