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
            new Travel("Helsinki", 1, (new DateTime (2024, 02, 20)), (new DateTime(2024, 02,26)), Country.Finland),
            new Worktrip("Rådhuskällaren", 12, (new DateTime (2023, 12, 22)), (new DateTime(2023, 12,23)), Country.Sweden, "Conference"),
            new Travel("Ströget", 1, (new DateTime (2024, 02, 20)), (new DateTime(2024, 02,26)), Country.Denmark),
            new Travel("Aiko Sushi", 1, (new DateTime (2024, 02, 20)), (new DateTime(2024, 02,26)), Country.Sweden)
        };


    }

}