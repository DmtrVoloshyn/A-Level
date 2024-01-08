namespace Homework5
{
    public class Actions
    {
        private readonly Logger logger = Logger.Instance;

        public Result FirstMethod()
        {
            logger.Log(LogLevel.Info, "Start method: FirstMethod");
            return new Result();
        }

        public Result SecondMethod()
        {
            logger.Log(LogLevel.Warning, "Skipped logic in method: SecondMethod");
            return new Result();
        }

        public Result ThirdMethod()
        {
            logger.Log(LogLevel.Error, "Action failed by a reason: I broke a logic");
            return new Result { Status = false };
        }
    }
}
