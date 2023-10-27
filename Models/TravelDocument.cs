using TravelPal_Newton.Interfaces;

namespace TravelPal_Newton.Models
{
    public class TravelDocument : PackingListItem
    {
        public bool Required { get; set; }
        public string Name { get; set; }

        public TravelDocument(bool required, string name)
        {
            Required = required;
            Name = name;
        }
        public string GetInfo()
        {
            return $"{Name}, Required: {Required}";
        }
    }
}
