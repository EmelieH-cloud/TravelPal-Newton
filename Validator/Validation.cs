using System;
using TravelPal_Newton.Enums;

namespace TravelPal_Newton.Validator
{
    public class Validation
    {
        public Validation() { }



        // StringToDateTime()
        // Tar in en sträng och returnerar true om det går att konvertera den till ett datum. 
        public bool StringToDateTime(string datestring)
        {
            bool conversionIsSucessful = false;
            DateTime dateConversion;
            if (DateTime.TryParse(datestring, out dateConversion))
            {
                conversionIsSucessful = true;
            }

            return conversionIsSucessful;

        }

        // CountryExists()
        // Tar in en sträng input och kontrollerar om det finns något land som matchar detta i Enum.Country
        public bool CountryExists(string countryInput)
        {
            bool countryExists = false;
            if (!string.IsNullOrEmpty(countryInput))
            {
                foreach (Country country in Enum.GetValues(typeof(Country)))
                {
                    if (countryInput == country.ToString())
                    {
                        countryExists = true;
                    }
                }
            }
            return countryExists;
        }


        //InputLength()
        // Användarnamn + lösenord måste innehålla minst 6 och max 13 symboler, metoden returnerar true/false baserat på detta.
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
        // kollar om input är null, innehåller whitespace eller är empty.
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
        // Räknar hur många siffror en sträng innehåller och returnerar resultatet. 
        public int CountNumbers(string input)
        {
            bool isNumber = false;
            int countNumbers = 0;
            char[] inputToChar = input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
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
