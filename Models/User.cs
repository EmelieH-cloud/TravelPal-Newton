using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Interfaces;

namespace TravelPal_Newton.Models
{
    public class User : IUser
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required Country Location { get; set; }

        public List<Travel>? travels { get; set; }

        [SetsRequiredMembers]
        public User(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;
        }
    }
}