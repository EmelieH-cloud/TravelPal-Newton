using System.Collections.Generic;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Interfaces;
using TravelPal_Newton.Models;

namespace TravelPal_Newton.Managers
{
    public static class UserManager
    {
        public static List<IUser> users = new()
        {
            new Admin("admin", "password", Country.Sweden),
            new User ("user", "password", Country.Sweden)
        };

        public static IUser? signedInUser { get; set; }



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

        // CheckAvailability()
        // Söker igenom listan med registrerade användare för att kontrollera om användaren redan finns.
        public static bool CheckAvailability(string username, string password)
        {
            bool usernameAndPasswordIsTaken = false;
            foreach (IUser user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    usernameAndPasswordIsTaken = true;
                }
                else
                {
                    usernameAndPasswordIsTaken = false;
                }
            }
            return usernameAndPasswordIsTaken;
        }

        // SignInUser()
        // Söker igenom listan med användare och returnerar "true" om det finns en användare med detta användarnamn + lösenord.
        public static bool SignInUser(string username, string password)
        {
            foreach (IUser user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    signedInUser = user;
                    return true;

                }
            }
            return false;

        }


    }
}