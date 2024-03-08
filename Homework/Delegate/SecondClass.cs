namespace Delegate
{
	public class SecondClass
	{
		public delegate int MultiplyDelegate(int number, int number2);
		public delegate bool ResultDelegate(int number);

		private int _multiplyResult;

        public ResultDelegate Calc(int number, int number2, MultiplyDelegate multiplyDelegate)
        {
            _multiplyResult = multiplyDelegate(number, number2);

            return new ResultDelegate(Result);
        }

		public bool Result(int number)
		{
			return _multiplyResult % number == 0;
        }
	}
}

//implementation via delegate add-ons
public class SecondClass2
{
    private int _multiplyResult;

    public Predicate<int> Calc(int number, int number2, Func<int, int, int> multiplyDelegate)
    {
        _multiplyResult = multiplyDelegate(number, number2);

        return Result;
    }

    public bool Result(int number)
    {
        return _multiplyResult % number == 0;
    }
}

