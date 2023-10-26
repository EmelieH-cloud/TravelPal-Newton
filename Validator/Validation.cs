using System;
using TravelPal_Newton.Enums;

namespace TravelPal_Newton.Validator
{
    public class Validation
    {
        public Validation() { }

        public bool StringToInt(string stringToInt)
        {
            bool conversionResult;
            int converted;
            conversionResult = int.TryParse(stringToInt, out converted);
            return conversionResult;
        }

        // ChosenDateIsValid()
        // jämför två datum och returnerar true om det första datumet är tidigare än det andra datumet.  
        public bool ChosenDateIsValid(DateTime startDate, DateTime endDate)
        {
            // blir <0 om startDate är tidigare än endDate 
            int value = DateTime.Compare(startDate, endDate);

            if (value < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // CreateDateTimeObject() 
        // Skapar ett DateTime objekt. 
        // Används i kombination med CorrectDateFormat som kontrollerar formatet på input. 
        public DateTime CreateDateTimeObject(string datestring)
        {

            char[] inputToChar = datestring.ToCharArray();
            char first = inputToChar[0];
            char second = inputToChar[1];
            string day = first.ToString() + second.ToString();
            int dayAsInt = Convert.ToInt32(day);

            char third = inputToChar[3];
            char fourth = inputToChar[4];
            string month = third.ToString() + fourth.ToString();
            int monthAsInt = Convert.ToInt32(month);

            char fifth = inputToChar[6];
            char sixth = inputToChar[7];
            char seventh = inputToChar[8];
            char eight = inputToChar[9];
            string year = fifth.ToString() + sixth.ToString() + seventh.ToString() + eight.ToString();
            int yearAsInt = Convert.ToInt32(year);

            DateTime newDateTime = new DateTime(yearAsInt, monthAsInt, dayAsInt);
            return newDateTime;
        }

        // CorrectDateFormat()
        // Tar in en sträng och kontrollerar att den följer formateringen DD/MM/YYYY
        public bool CorrectDateFormat(string datestring)
        {
            bool formatIsCorrect = false;
            char[] inputToChar = datestring.ToCharArray();
            int countNumbers = 0;

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
                    // om samtliga index hittils innehåller en siffra så är countNumbers = 8. 

                    if (countNumbers == 8)
                    {
                        if (inputToChar[2].Equals('/') && (inputToChar[5]).Equals('/'))
                        {
                            formatIsCorrect = true;
                        }

                    }
                }
            }
            return formatIsCorrect;
        }


        // CountryExists()
        // Tar in en sträng input och kontrollerar om det finns något land som matchar i Enum.Country
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
