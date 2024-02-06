using Logger.Models;
using Logger.Services.Abstractions;

namespace Logger
{
	public class Actions
	{
        private readonly ILoggerService _logger;

        public Actions(ILoggerService loggerService)
		{
            _logger = loggerService;
		}

		public void FirstMethod()
		{
            _logger.Log(LogLevel.Info, "Start Method");
		}

        public void SecondMethod()
        {
            try
            {
                if(true)
                    throw new BusinessException("Skipped logic in method");
            }
            catch(BusinessException ex)
            {
                _logger.Log(LogLevel.Warning, ex.Message);
            }
        }

        public void ThirdMethod()
        {
            try
            {
                if (true)
                    throw new Exception("I broke a logic");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
        }
    }
}

