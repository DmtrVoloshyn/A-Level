namespace Delegate
{
	public class CalculateEventHandler
	{
        public int _result1;
        public int _result2;

        public void HandleCalculate(object? sender, int sumResult)
        {
            if (_result1 == default)
                _result1 = sumResult;
            
            if (_result2 == default)
                _result2 = sumResult;
        }

        public int SumResults() => FirstClass.Sum(_result1, _result2);
    }
}