using Serilog;

namespace CandyGift.Models
{
	public sealed class GiftPack
	{
        public Sweet[] Sweets { get; private set; }
		public int PackWeight { get; private set; }

		public GiftPack(Sweet[] sweets)
		{
			Sweets = sweets;
			PackWeight = 20;
		}

        public int GetActualGiftWeight()
        {
            int sweetsWeightSum = Sweets.Where(sweet => sweet != null).Sum(sweet => sweet.Weight);

            return sweetsWeightSum + PackWeight;
        }

		public Sweet[] GetSortedSweets()
		{
            var sortedSweets = Sweets
                .Where(sweet => sweet != null)
                .OrderBy(sweet => sweet.Weight)
                .ToArray();

            Log.Information("Sweets in giftpack sorted by weight");

            return sortedSweets;
        }
    }
}

