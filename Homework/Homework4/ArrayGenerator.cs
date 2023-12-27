namespace Homework4
{
    public class ArrayGenerator
    {
        public static int[] GenerateValues(int arraySize, int minValue, int maxValue)
        {
            int[] integerArray = new int[arraySize];
            for (int i = 0; i < integerArray.Length; i++)
            {
                integerArray[i] = new Random().Next(minValue, maxValue);
            }
            return integerArray;
        }
    }
}
