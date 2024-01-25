namespace Logger.Models
{
    public class BusinessException : Exception
	{
        public BusinessException(string message) : base(message) { }
	}
}

