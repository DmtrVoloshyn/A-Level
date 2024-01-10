namespace Homework5
{
    public class Actions
    {

        public static Result FirstMethod()
        {
            Logger.Instance.Log(LogLevel.Info, "Start method: FirstMethod");
            return new Result();
        }

        public static Result SecondMethod()
        {
            Logger.Instance.Log(LogLevel.Warning, "Skipped logic in method: SecondMethod");
            return new Result();
        }

        public static Result ThirdMethod()
        {
            Logger.Instance.Log(LogLevel.Error, "Action failed by a reason: I broke a logic");
            return new Result { Status = false };
        }
    }
}
