namespace Delegate
{
    public delegate void ShowDelegate(bool result);

    public class FirstClass
	{
        public event Action<object, EventArgs> CalculateEvent;

        public void CalculateSum()
        {
            OnCalculate(EventArgs.Empty);
        }

        protected virtual void OnCalculate(EventArgs e)
        {
            CalculateEvent?.Invoke(this, e);
        }

        public int Multiply(int number, int number2) => number * number2;

        public int Sum(int number, int number2) => number + number2;
	}
}