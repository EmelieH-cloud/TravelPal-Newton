using System;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Models;
using Validation = TravelPal_Newton.Validator.Validation;

namespace TravelPal_Newton.Create
{
    public class CreateObjects
    {
        Validation validation = new Validation();

        public Worktrip CreateWorktrip(string startdate, string enddate, string destination, int travelers, Country country, string details)
        {
            DateTime startDateObject = validation.CreateDateTimeObject(startdate);
            DateTime endDateObject = validation.CreateDateTimeObject(enddate);
            if (details.Length < 0 || details == null)
            {
                details = "Not filled in";
            }
            Worktrip worktrip = new(destination, travelers, startDateObject, endDateObject, country, details);
            return worktrip;
        }

        public OtherItem CreateItem(string name, string quantity)
        {
            int conversion = Convert.ToInt32(quantity);
            OtherItem item = new(name, conversion);
            return item;
        }


        public Vacation CreateVacation(string startdate, string enddate, string destination, int travelers, Country country, bool inclusive)
        {
            DateTime startDateObject = validation.CreateDateTimeObject(startdate);
            DateTime endDateObject = validation.CreateDateTimeObject(enddate);
            Vacation vacation = new(destination, travelers, startDateObject, endDateObject, country, inclusive);
            return vacation;
        }

        public Travel CreateTravel(string startdate, string enddate, string destination, int travelers, Country country)
        {
            DateTime startDateObject = validation.CreateDateTimeObject(startdate);
            DateTime endDateObject = validation.CreateDateTimeObject(enddate);
            Travel travel = new(destination, travelers, startDateObject, endDateObject, country);
            return travel;
        }
    }
}

