namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskCountElementsInRange(-100, 100);
            TaskCreateNewArrayAndSort();
        }

        static void TaskCountElementsInRange(int rangeMin, int rangeMax)
        {
            var arraySize = new Random().Next(1, 100);
            int[] randomArray = ArrayGenerator.GenerateValues(arraySize, -500, 500);
            int countElements = 0;

            Console.WriteLine($"[First task] Given an array of integers with N={arraySize} elements in range 1-100. Determine the number of elements whose values are in the range -100 to +100.");
            Console.WriteLine("[Given array] " + string.Join(", ", randomArray));

            foreach (var item in randomArray)
            {
                if (item >= rangeMin && item <= rangeMax)
                {
                    countElements++;
                }
            }

            Console.WriteLine($"[Response] Found {countElements} elements in given array in the range from -100 to 100\n\n");
        }

        static void TaskCreateNewArrayAndSort()
        {
            Console.WriteLine(@"[Second task] An array of integers A[20] is given.
Create another array of integers B[20], which will include all the numbers of the original array that satisfy the condition:
A[i] <= 888, and then sort the elements of the array B[20] in descending order.");


            int[] randomArray = ArrayGenerator.GenerateValues(20, 0, 1000);

            Console.WriteLine("[Given random array with 20 elements] " + string.Join(", ", randomArray));
            int[] newArray = new int[randomArray.Length];
            var index = 0;

            foreach (var item in randomArray)
            {
                if (item <= 888)
                {
                    newArray[index] = item;
                    index++;
                }
            }

            int[] sortedArray = newArray.OrderByDescending(x => x).ToArray();

            Console.WriteLine("[Response] Sorted array elements: " + string.Join(", ", sortedArray));
        }
    }
}
