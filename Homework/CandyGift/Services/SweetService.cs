using CandyGift.Entities;
using CandyGift.Models;
using CandyGift.Models.Candies;
using CandyGift.Models.Cookies;
using CandyGift.Repositories;
using CandyGift.Services.Abstractions;
using CandyGift.Сonverters;
using Serilog;

namespace CandyGift.Services
{
	public class SweetService : ISweetService
	{
        private readonly SweetRepository _sweetRepository;
        private readonly ILogger _logger;

		public SweetService(SweetRepository sweetRepository, ILogger logger)
		{
            _sweetRepository = sweetRepository;
            _logger = logger;
		}

        public void СreateSweets()
        {
            List<SweetEntity> sweets = new();

            for (int i = 0; i < 20; i++)
            {
                sweets.Add(new Kontik().ToEntity());
                sweets.Add(new Kokosha().ToEntity());
                sweets.Add(new MilkyWay().ToEntity());
                sweets.Add(new ChupaChups().ToEntity());
            }

            foreach (var sweet in sweets)
            {
                _sweetRepository.Add(sweet);
            }
            _logger.Information("Sweet objects created and posted to repository");
        }
    }
}

