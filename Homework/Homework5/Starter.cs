namespace Homework5
{
	public class Starter
	{
        readonly Actions actions = new();
        readonly Logger logger = Logger.Instance;


        public void Run()
		{

			for (int i = 0; i < 100; i++)
			{
                var random = new Random().Next(1, 4);

                _ = random switch
				{
					1 => actions.FirstMethod(),
					2 => actions.SecondMethod(),
					_ => actions.ThirdMethod()
				};
			}

            logger.WriteLogsToFile();
        }
    }
}
