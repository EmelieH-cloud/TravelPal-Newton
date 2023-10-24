using System;
using TravelPal_Newton.Enums;

namespace TravelPal_Newton.Models
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        public Vacation(string destination, int travellers, DateTime startdate, DateTime enddate, Country theCountry, bool allInclusive) : base(destination, travellers, startdate, enddate, theCountry)
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo()
        {
            return $"VACATION Country: {TheCountry}, Destination: {Destination}, Startdate: {StartDate}, Enddate: {EndDate} ";
        }
    }
}
