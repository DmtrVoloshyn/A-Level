namespace ArrayProcessing
{
    public class ArrayProcessor
    {
        public static int[] DivideIntoEvenOrOdd(int[] numbers, bool even)
        {
            int[] resultArray = new int[numbers.Length];
            int resultCount = 0;

            foreach (var number in numbers)
            {
                if (number % 2 == 0 == even)
                {
                    resultArray[resultCount++] = number;
                }
            }

            Array.Resize(ref resultArray, resultCount);
            return resultArray;
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
