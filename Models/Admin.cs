using TravelPal_Newton.Enums;
using TravelPal_Newton.Interfaces;

namespace TravelPal_Newton.Models
{
    public class Admin : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public Admin(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;
        }
    }
}
