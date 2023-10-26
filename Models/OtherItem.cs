using TravelPal_Newton.Interfaces;

namespace TravelPal_Newton.Models
{
    public class OtherItem : PackingListItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public OtherItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public string GetInfo()
        {
            return $"{Name} quantity: {Quantity}";
        }

    }
}
