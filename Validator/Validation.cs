using System;

namespace TravelPal_Newton.Validator
{
    public class Validation
    {
        public Validation() { }

        //InputLength()
        // Användarnamn och lösenord måste vara minst 6 och högst 13 symboler. 
        public bool CheckInputLength(string input)
        {
            bool lengthIsOkay = false;

            if (input.Length < 6)
            {
                lengthIsOkay = false;
            }

            else if (input.Length >= 6 && input.Length <= 13)
            {
                lengthIsOkay = true;
            }

            return lengthIsOkay;
        }

        //  CheckEmptyNullWhiteSpace()
        // kollar om input är null, innehåller whitespace eller är tom. 
        public bool CheckEmptyNullWhiteSpace(string input)
        {
            bool isNullOrEmpty = string.IsNullOrEmpty(input);
            bool isNullOrWhiteSpace = string.IsNullOrEmpty(input);
            bool inputIsValid = false;

            if (isNullOrEmpty || isNullOrWhiteSpace)
            {
                inputIsValid = false;
            }

            else if (!isNullOrEmpty && !isNullOrWhiteSpace)
            {
                inputIsValid = true;
            }

            return inputIsValid;

        }


        // CountNumbers()
        // Räknar hur många siffror en sträng innehåller. 
        public int CountNumbers(string input)
        {
            bool isNumber = false;
            int countNumbers = 0;
            char[] inputToChar = input.ToCharArray();

            for (int i = 0; i <= input.Length; i++)
            {
                isNumber = Char.IsDigit(inputToChar[i]);
                if (isNumber)
                {
                    countNumbers++;
                }

            }
            return countNumbers;
        }
    }
}
