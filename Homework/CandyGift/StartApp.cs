using CandyGift.Services;

namespace CandyGift
{
    public class StartApp
	{
        private readonly SweetGiftProcessorService _sweetGiftProcessorService;

        public StartApp()
		{
            _sweetGiftProcessorService = new();
        }

        public void Start()
        {
            _sweetGiftProcessorService.Run();
        }

		
    }
}

