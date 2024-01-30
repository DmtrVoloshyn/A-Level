using Salad.Converters;
using Salad.Entities;
using Salad.Entities.FruitVegetablesEntity;
using Salad.Entities.LeafyVegetablesEntity;
using Salad.Models;
using Salad.Models.FruitVegetables;
using Salad.Models.LeafyVegetables;
using Salad.Repositories;
using Serilog;

namespace Salad.Services
{
	public class VegetablesService
	{
		private readonly IRepository<VegetableEntity> _repository;


        public VegetablesService(IRepository<VegetableEntity> vegetablesRepository)
		{
            _repository = vegetablesRepository;
        }

		public void CreateVegetables()
		{
			List<VegetableEntity> vegetableEntities = new();

            for (int i = 0; i < 20; i++)
			{
				vegetableEntities.Add(new Cucumber().ToEntity());
				vegetableEntities.Add(new RedTomato().ToEntity());
                vegetableEntities.Add(new YellowTomato().ToEntity());
                vegetableEntities.Add(new SweetPepper().ToEntity());
                vegetableEntities.Add(new GreenOnion().ToEntity());
                vegetableEntities.Add(new Basil().ToEntity());
            }

			foreach (var item in vegetableEntities)
			{
				_repository.Add(item);
			}

            Log.Information("Vegetables created");
        }

		public Vegetable[] GetVegetables()
		{
            VegetableEntity[] vegetables = (VegetableEntity[])_repository.GetAll();
            Vegetable[] vegetablesModels = new Vegetable[vegetables.Length];

            for (int i = 0; i < vegetables.Length; i++)
            {
                var vegetableM = vegetables[i] switch
                {
                    CucumberEntity cucumberEntity => (Vegetable)cucumberEntity.ToModel(),
                    RedTomatoEntity redTomatoEntity => redTomatoEntity.ToModel(),
                    YellowTomatoEntity yellowTomatoEntity => yellowTomatoEntity.ToModel(),
                    SweetPepperEntity sweetPepperEntity => sweetPepperEntity.ToModel(),
                    BasilEntity basilEntity => basilEntity.ToModel(),
                    GreenOnionEntity greenOnionEntity => greenOnionEntity.ToModel(),
                    _ => throw new NotImplementedException()
                };

                vegetablesModels[i] = vegetableM;
            }

            return vegetablesModels;
        }
	}
}

