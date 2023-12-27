namespace ArrayProcessing
{
    public class ArrayProcessor
    {
        public static (int[] evenArray, int[] oddArray) DivideIntoEvenAndOdd(int[] numbers)
        {
            int[] evenArray = new int[numbers.Length];
            int[] oddArray = new int[numbers.Length];

            int evenCount = 0;
            int oddCount = 0;

            foreach (var number in numbers)
            {
                if ((number % 2) == 0)
                {
                    evenArray[evenCount++] = number;
                }
                else
                {
                    oddArray[oddCount++] = number;
                }
            }

            Array.Resize(ref evenArray, evenCount);
            Array.Resize(ref oddArray, oddCount);

            return (evenArray, oddArray);
        }

        public static string[] NumbersToLetters(int[] numbers)
        {
            string[] resultArray = new string[numbers.Length];

            for (int i = 0; i < resultArray.Length; i++)
            {
                int number = numbers[i];

                if (number >= 1 && number <= 26)
                {
                    string letter = ((char)('a' + number - 1)).ToString();
                    resultArray[i] = letter;
                }
            }

            return resultArray;
        }
    }
}
