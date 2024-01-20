namespace Homework5
{
	public class Starter
	{
        public void Run()
		{

			for (int i = 0; i < 100; i++)
			{
                var random = new Random().Next(1, 4);

                _ = random switch
				{
					1 => Actions.FirstMethod(),
					2 => Actions.SecondMethod(),
					_ => Actions.ThirdMethod()
				};
			}

            Logger.Instance.SaveLogWithConfirmation();
        }
    }
}
