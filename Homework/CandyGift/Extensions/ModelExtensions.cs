using CandyGift.Models;

namespace CandyGift.Extensions
{
	public static class ModelExtensions
	{
        public static Sweet GetByWeight(this IEnumerable<Sweet> sweets, int weight)
        {
            foreach (var item in sweets)
            {
                if (item.Weight == weight)
                {
                    return item;
                }
            }
            throw new Exception("Not found");
        }
    }
}

