using CandyGift.Entities;

namespace CandyGift.Repositories
{
    public class SweetRepository : MemoryRepository<SweetEntity>
    {
        public override void Add(SweetEntity entity)
        {
            Items.Add(entity);
        }

        public override SweetEntity Get(Guid id)
        {
            foreach (var item in Items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new Exception("Sweet was not found");
        }

        public override SweetEntity[] GetAll() => Items.ToArray();
    }
}

