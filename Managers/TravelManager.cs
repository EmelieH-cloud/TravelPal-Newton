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
            new Vacation("Machu Picchu", 1, (new DateTime (2024, 01, 20)), (new DateTime(2024, 01,26)), Country.Peru, true),
            new Travel("Finnish Sauna", 1, (new DateTime (2024, 02, 20)), (new DateTime(2024, 02,26)), Country.Finland),
            new Worktrip("Rådhuskällaren", 12, (new DateTime (2023, 12, 22)), (new DateTime(2023, 12,23)), Country.Sweden, "Christmas summit"),
            new Travel("Den lille havefru", 1, (new DateTime (2024, 02, 20)), (new DateTime(2024, 02,26)), Country.Denmark),
            new Travel("Tapas", 1, (new DateTime (2024, 02, 20)), (new DateTime(2024, 02,26)), Country.Italy)
        };


    }

}