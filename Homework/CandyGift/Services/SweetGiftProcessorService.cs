using CandyGift.Entities;
using CandyGift.Entities.Candies;
using CandyGift.Entities.Cookies;
using CandyGift.Extensions;
using CandyGift.Models;
using CandyGift.Repositories;
using CandyGift.Сonverters;
using Serilog;

namespace CandyGift.Services
{
	public sealed class SweetGiftProcessorService
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
            var giftSortedSweets = _giftPack.GetSortedSweets();
            DisplaySweets(giftSortedSweets);

            Console.WriteLine(string.Join(Environment.NewLine, giftSortedSweets
                 .Where(sweet => sweet != null)
                 .GroupBy(sweet => sweet.Name)
                 .Select(group => new
                 {
                     Name = group.Key,
                     Count = group.Count()
                 })));
            Console.WriteLine($"Actual gift weight: {_giftPack.GetActualGiftWeight()}g");

            Console.WriteLine("\nDo you want to take one?");

            while (true)
            {
                Console.Write("Enter weight:  ");
                var response = Console.ReadLine();


                if (int.TryParse(response, out int result))
                {
                    Console.WriteLine($"You are lucky: " + giftSortedSweets.GetByWeight(result).Name);
                    break;
                }

                Console.WriteLine("Invalid input.");
            }
        }

        private void DisplaySweets(Sweet[] sweets)
        {
            Console.WriteLine(string.Join(Environment.NewLine, sweets
                .Where(sweet => sweet != null)
                .GroupBy(sweet => sweet.Weight)
                .SelectMany(group => group.Select(sweet => new
                {
                    Name = sweet.Name,
                    Weight = sweet.Weight
                }))) + Environment.NewLine);
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
                    break;
                }

                randomSweets[index] = sweetModel;
                totalWeight += sweetItem.Weight;
                index++;
            }

            Log.Information("Added random sweets by weight");
        }
    }
}

