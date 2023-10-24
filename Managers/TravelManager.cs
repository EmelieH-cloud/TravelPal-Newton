using System;
using System.Collections.Generic;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Models;

namespace TravelPal_Newton.Managers
{
    public static class TravelManager
    {
        public static List<Travel> travels = new()
        {
            new Travel("Machu Picchu", 1, (new DateTime (2024, 01, 20)), (new DateTime(2024, 01,26)), Country.Peru)
        };
    }

}