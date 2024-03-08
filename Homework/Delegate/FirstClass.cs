namespace Delegate
{
    public delegate void ShowDelegate(bool result);

    public class FirstClass
	{
        public event EventHandler<int>? CalculateEvent;

        public void CalculateSum(int num, int num2)
        {
            var sumResult = Sum(num, num2);
            CalculateEvent?.Invoke(this, sumResult);
        }

        public static int Multiply(int number, int number2) => number * number2;

        public static int Sum(int number, int number2) => number + number2;
	}
}