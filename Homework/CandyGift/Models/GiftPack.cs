namespace CandyGift.Models
{
	public class GiftPack
	{
        public Sweet[]? Sweets { get; private set; }
		public int PackWeight { get; set; }

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
    }
}

