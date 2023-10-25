using System;
using TravelPal_Newton.Enums;

namespace TravelPal_Newton.Validator
{
    public class Validation
    {
        public Validation() { }

        // CorrectDateFormat()
        // Tar in en sträng och kontrollerar att den följer formateringen DD/MM/YYYY
        public bool CorrectDateFormat(string datestring)
        {
            bool formatIsCorrect = false;
            char[] inputToChar = datestring.ToCharArray();
            int countNumbers = 0;

            // Gör bara följande om datestring.Length är lika med 10
            if (datestring.Length == 10)
            {
                // index i inputToChar[] som ska innehålla en siffra: 0 1 3 4 6 7 8 9,
                for (int i = 0; i < 5; i++)
                {
                    if (Char.IsDigit(inputToChar[i]))
                    {
                        countNumbers++;
                    }
                }
                // slut på loop som undersöker om index 0 till 5 innehåller en siffra.
                // fortsätt endast om samtliga index mellan 0 och 5 innehåller en siffra. 
                if (countNumbers == 4)
                {
                    for (int i = 6; i < 10; i++)
                    {
                        if (Char.IsDigit(inputToChar[i]))
                        {
                            countNumbers++;
                        }
                    }
                    // slut på loop som undersöker om index 6 till 9 innehåller en siffra.
                    // om samtliga index hittils innehåller en siffra så är countNumbers = 9. 

                    if (countNumbers == 8)
                    {
                        // index 2 och 5 ska innehålla backslash
                        if (inputToChar[2].Equals('/') && (inputToChar[5]).Equals('/'))
                        {
                            formatIsCorrect = true;
                        }

                    }
                }
            }
            return formatIsCorrect;
        }


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
