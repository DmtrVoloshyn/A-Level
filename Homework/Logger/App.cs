namespace Logger
{
    public class App
    {
        private readonly Actions _actions;

        public App(Actions actions)
        {
            _actions = actions;
        }
        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                var random = new Random().Next(1, 4);

                switch (random)
                {
                    case 1:
                        _actions.FirstMethod();
                        break;
                    case 2:
                        _actions.SecondMethod();
                        break;
                    default:
                        _actions.ThirdMethod();
                        break;
                }
            }
        }
    }
}