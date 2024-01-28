using Salad.Entities;

namespace Salad.Repositories
{
	public class VegetablesRepository : MemoryRepository<VegetableEntity>
    {
        public override void Add(VegetableEntity entity)
        {
            Items.Add(entity);
        }

        public override VegetableEntity Get(Guid id)
        {
            foreach (var item in Items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new Exception("Ingredient was not found");
        }

        public override VegetableEntity[] GetAll() => Items.ToArray();
    }
}
