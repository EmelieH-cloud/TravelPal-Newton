using TravelPal_Newton.Enums;

namespace TravelPal_Newton.Interfaces
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }


    }

}
