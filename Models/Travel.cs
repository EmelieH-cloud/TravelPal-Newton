﻿using System;
using System.Collections.Generic;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Interfaces;

namespace TravelPal_Newton.Models
{
    public class Travel
    {

        public string Destination { get; set; }
        public int Travellers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Country TheCountry { get; set; }
        public int TravelDays { get; set; }

        public List<PackingListItem>? packingList { get; set; }

        public Travel(string destination, int travellers, DateTime startdate, DateTime enddate, Country theCountry)
        {
            Destination = destination;
            Travellers = travellers;
            StartDate = startdate;
            EndDate = enddate;
            TheCountry = theCountry;
            TravelDays = CalculateTravelDays();

        }

        public virtual string GetInfo()
        {
            return $"Country: {TheCountry}, Destination: {Destination}, Startdate: {StartDate}, Enddate: {EndDate} ";
        }

        public int CalculateTravelDays()
        {
            int numberOfDays = (int)(EndDate - StartDate).TotalDays;
            return numberOfDays;
        }

    }

}
