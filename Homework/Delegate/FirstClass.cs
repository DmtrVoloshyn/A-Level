namespace Delegate
{
	public class FirstClass
	{
        public delegate void ShowDelegate(bool result);

		public int Multiply(int number, int number2) => number * number2;
	}
}