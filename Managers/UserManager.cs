using System.Collections.Generic;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Interfaces;
using TravelPal_Newton.Models;

namespace TravelPal_Newton.Managers
{
    public static class UserManager
    {
        public static List<IUser> users { get; set; } = new();
        public static IUser? signedInUser { get; set; }


        // AddUser()
        // Tar emot en string och kontrollerar att användarnamnet inte redan finns i listan. Om det är ledigt, registreras en ny användare.
        public static void AddUser(string username, string password, Country location)
        {
            if (ValidateUsername(username))
            {
                User user = new(username, password, location);
                users.Add(user);
            }
        }


        //RemoveUser()
        // Använder SignInUser() för att kontrollera att användaren finns. Om den finns, tas användaren bort.
        public static void RemoveUser(IUser user)
        {
            string username = user.Username;
            string password = user.Password;

            if (SignInUser(username, password))
            {
                users.Remove(user);
            }

        }


        // ValidateUsername()
        // Söker igenom listan med registrerade användare för att kontrollera om användarnamnet är upptaget.
        public static bool ValidateUsername(string username)
        {
            bool usernameIsTaken = true;
            foreach (IUser user in users)
            {
                if (user.Username == username)
                {
                    usernameIsTaken = false;
                }
                else if (user.Username != username)
                {
                    usernameIsTaken = true;
                }
            }
            return usernameIsTaken;
        }

        // SignInUser()
        // Söker igenom listan med användare och returnerar "true" om det finns en användare med detta användarnamn + lösenord.
        public static bool SignInUser(string username, string password)
        {
            foreach (IUser user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;

        }


    }
}