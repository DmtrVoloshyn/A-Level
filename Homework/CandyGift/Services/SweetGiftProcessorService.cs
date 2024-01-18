using CandyGift.Entities;
using CandyGift.Entities.Candies;
using CandyGift.Entities.Cookies;
using CandyGift.Models;
using CandyGift.Models.Candies;
using CandyGift.Models.Cookies;
using CandyGift.Repositories;
using CandyGift.Сonverters;
using Serilog;

namespace CandyGift.Services
{
	public class SweetGiftProcessorService
	{
		private Sweet[] randomSweets = new Sweet[100];
		private SweetEntity[] sweets;

		private readonly SweetRepository _sweetRepository;
		private readonly SweetService _sweetService;
        private GiftPack _giftPack;


        public SweetGiftProcessorService()
		{
			Log.Logger = new LoggerConfiguration()
				.WriteTo.Console()
				.CreateLogger();
			_sweetRepository = new();
			_sweetService = new(_sweetRepository, Log.Logger);
		}

		public void Run()
		{
			_sweetService.СreateSweets();
            AddRandomSweetsByWeight(1000);
            GiftPack _giftPack = new(randomSweets);

            Console.WriteLine(string.Join(Environment.NewLine, _giftPack.Sweets
                 .Where(sweet => sweet != null)
                 .GroupBy(sweet => sweet.Manufacturer)
                 .Select(group => new
                 {
                     Manufacturer = group.Key,
                     Count = group.Count()
                 })));
            Console.WriteLine($"Actual gift weight: {_giftPack.GetActualGiftWeight()}g");


        }

        public void AddRandomSweetsByWeight(int giftWeight)
        {
            sweets = _sweetRepository.GetAll();
            Random random = new();

            var index = 0;
            var totalWeight = 0;

            while (totalWeight < giftWeight)
            {
                var i = random.Next(sweets.Length);
                var sweetItem = sweets[i];

                var sweetModel = sweetItem switch
                {
                    ChupaChupsEntity chupaChupsEntity => (Sweet)chupaChupsEntity.ToModel(),
                    MilkyWayEntity milkyWayEntity => milkyWayEntity.ToModel(),
                    KokoshaEntity kokoshaEntity => kokoshaEntity.ToModel(),
                    KontikEntity kontikEntity => kontikEntity.ToModel(),
                    _ => throw new NotSupportedException($"Unsupported type: {sweetItem.GetType().Name}")
                };

                if (totalWeight + sweetModel.Weight > giftWeight)
                {
                    continue;
                }

                randomSweets[index] = sweetModel;
                totalWeight += sweetItem.Weight;
                index++;
            }

            Log.Information("Added random sweets by weight");
        }
    }
}

