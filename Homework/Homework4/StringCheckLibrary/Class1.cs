namespace StringCheckLibrary
{
    public class StringChecker
    {
        private static readonly string[] ValidStrings = { "a", "e", "i", "d", "h", "j" };

        public static bool IsStringValid(string inputString)
        {
            return Array.IndexOf(ValidStrings, inputString) != -1;
        }

        public static string[] CheckArray(string[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                string currentString = inputArray[i];

                if (IsStringValid(currentString))
                {
                    inputArray[i] = currentString.ToUpper();
                }
            }

            return inputArray;
        }

        public static int CountUpperLetters(string[] inputArray)
        {
            int upperLetters = 0;

            foreach (string item in inputArray)
            {
                foreach (char letter in item)
                {
                    if (char.IsUpper(letter))
                    {
                        upperLetters++;
                        break;
                    }
                }
            }

            return upperLetters;
        }
    }
}
