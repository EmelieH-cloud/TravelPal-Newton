using System;
using TravelPal_Newton.Enums;

namespace TravelPal_Newton.Models
{
    public class Worktrip : Travel
    {
        public string MeetingDetails { get; set; }
        public Worktrip(string destination, int travellers, DateTime startdate, DateTime enddate, Country theCountry, string meetingDetails) : base(destination, travellers, startdate, enddate, theCountry)
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            return $"WORKTRIP Country: {TheCountry}, Destination: {Destination}, Startdate: {StartDate}, Enddate: {EndDate} ";
        }
    }
}
