using System;

namespace TravelPal_Newton.Validator
{
    class Validation
    {

        //InputLength()
        // Användarnamn och lösenord måste vara minst 6 symboler kort, och högst 13 symboler långt. 
        public bool InputLength(string input)
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
