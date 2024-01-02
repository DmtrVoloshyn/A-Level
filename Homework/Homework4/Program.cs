using ArrayProcessing;
using StringCheckLibrary;

namespace Homework4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter the number of array elements: ");
            var input = Console.ReadLine();
            int arrayLenght = int.TryParse(input, out int result) ? result : 0;

            int[] array = ArrayGenerator.GenerateValues(arrayLenght, 1, 26);
            (int[] evenArray, int[] oddArray) = ArrayProcessor.DivideIntoEvenAndOdd(array);

            string[] lettersArrayFromEvenNumbers = ArrayProcessor.NumbersToLetters(evenArray);
            string[] lettersArrayFromOddNumbers = ArrayProcessor.NumbersToLetters(oddArray);

            lettersArrayFromEvenNumbers = StringChecker.CheckArray(lettersArrayFromEvenNumbers);
            lettersArrayFromOddNumbers = StringChecker.CheckArray(lettersArrayFromOddNumbers);

            Console.WriteLine("Letters array from the even numbers : " + string.Join(" ", lettersArrayFromEvenNumbers));
            Console.WriteLine("Letters array from the odd numbers : " + string.Join(" ", lettersArrayFromOddNumbers));

            var countUpperLettersInArrayFromEvenNumbers = StringChecker.CountUpperLetters(lettersArrayFromEvenNumbers);
            var countUpperLettersInArrayFromOddNumbers = StringChecker.CountUpperLetters(lettersArrayFromOddNumbers);

            CompareUpperLettersCountAndReturnResultToConsole(countUpperLettersInArrayFromEvenNumbers, countUpperLettersInArrayFromOddNumbers);
        }

        private static void CompareUpperLettersCountAndReturnResultToConsole(int countUpperLettersInArrayFromEvenNumbers, int countUpperLettersInArrayFromOddNumbers)
        {
            if (countUpperLettersInArrayFromEvenNumbers > countUpperLettersInArrayFromOddNumbers)
            {
                Console.WriteLine($"Letters array from the even numbers has more capital letters: {countUpperLettersInArrayFromEvenNumbers}");
            }
            else if (countUpperLettersInArrayFromEvenNumbers < countUpperLettersInArrayFromOddNumbers)
            {
                Console.WriteLine($"Letters array from the odd numbers has more capital letters: {countUpperLettersInArrayFromOddNumbers}");
            }
            else
            {
                Console.WriteLine($"Both arrays include an equal number of capital letters. First - {countUpperLettersInArrayFromEvenNumbers} and second {countUpperLettersInArrayFromOddNumbers}");
            }
        }
    }
}
