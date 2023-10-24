using System.Collections.Generic;
using System.Windows;
using TravelPal_Newton.Managers;
using TravelPal_Newton.Models;
using TravelPal_Newton.Windows;
using Validation = TravelPal_Newton.Validator.Validation;

namespace TravelPal_Newton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Validation validation = new Validation();

        public MainWindow()
        {
            InitializeComponent();

            // hämta demo-user i "databasen" 
            User user = (User)UserManager.users[0];

            // hämta demo-travels i "databasen"
            Travel travel1 = (Travel)TravelManager.travels[0];
            Travel travel2 = (Travel)TravelManager.travels[1];

            // lägg demo-travels i en list
            List<Travel> userTravels = new();
            userTravels.Add(travel1);
            userTravels.Add(travel2);

            // tilldela denna list till demo-user
            user.travels = userTravels;

        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password.ToString();

            // kontrollera att input inte är null, empty eller innehåller whitespace. 
            if (validation.CheckEmptyNullWhiteSpace(username) && validation.CheckEmptyNullWhiteSpace(password))
            {
                // om input är ok, gå vidare med att leta efter detta username och password i listan av registrerade users.
                bool userExists = UserManager.SignInUser(username, password);
                if (userExists)
                {
                    // om användaren finns, öppna nytt fönster, skicka med username + password. 
                    TravelsWindow travelswindow = new(username, password);
                    travelswindow.Show();
                    Close();

                }

                else if (!userExists)
                {
                    lblFeedback.Content = "User not found.";
                    ClearAllFields();
                }
            }

            else if (!validation.CheckEmptyNullWhiteSpace(username) || !validation.CheckEmptyNullWhiteSpace(password))
            {
                // om input innehåller whitespace, är null eller empty...
                lblFeedback.Content = "Please fill in all fields";
                ClearAllFields();
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerwindow = new RegisterWindow();
            registerwindow.Show();
            Close();
        }

        public void ClearAllFields()
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
