using System.Collections.Generic;
using TravelPal_Newton.Interfaces;
using TravelPal_Newton.Models;

namespace TravelPal_Newton.Managers
{
    public static class PackingItemsManager
    {
        public static List<PackingListItem> packingList_1 = new()
        {
            new OtherItem("Medicine", 2),
            new OtherItem("Sunscreen", 1),
            new OtherItem("Lipbalm", 1)

        };

        public static List<PackingListItem> packingList_2 = new()
        {
            new OtherItem("Books", 2),
            new OtherItem("Banana", 1),
            new OtherItem("Pencil", 1)

        };

    }
}
