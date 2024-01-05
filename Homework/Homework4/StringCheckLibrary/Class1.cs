namespace StringCheckLibrary
{
    public class StringChecker
    {
        private static readonly char[] ValidChars = { 'a', 'e', 'i', 'd', 'h', 'j' };

        public static bool IsStringValid(char inputString)
        {
            return Array.IndexOf(ValidChars, inputString) != -1;
        }

        public static string[] CheckArray(string[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                char firstCharacterOfCurrentString = inputArray[i][0];

                if (IsStringValid(firstCharacterOfCurrentString))
                {
                    inputArray[i] = char.ToUpper(firstCharacterOfCurrentString).ToString();
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
