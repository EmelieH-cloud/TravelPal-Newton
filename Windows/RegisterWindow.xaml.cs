using System;
using System.Windows;
using System.Windows.Media;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Managers;
using TravelPal_Newton.Models;
using Validation = TravelPal_Newton.Validator.Validation;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        Validation validation = new Validation();
        string chosenUsername = "";
        string chosenPassword = "";

        public RegisterWindow()
        {
            InitializeComponent();
            // Fyller comboboxen med värden 
            foreach (var item in Enum.GetValues(typeof(Country)))
            {
                ComboBoxCountry.Items.Add(item);
            }
        }
        private void BtnSignUpReady_Click(object sender, RoutedEventArgs e)
        {
            string username = txtRequestedUsername.Text;
            string password = txtRequestedPassword.Password.ToString();

            // om någon av dessa inputs är empty, null eller innehåller whitespace...
            if (!validation.CheckEmptyNullWhiteSpace(username) || !validation.CheckEmptyNullWhiteSpace(password))
            {
                lblregisterFeedback.Content = "Please fill in both fields, no whitespaces allowed";
            }

            else if (validation.CheckEmptyNullWhiteSpace(username) && validation.CheckEmptyNullWhiteSpace(password))
            {
                // om inputs inte är empty, null eller innehåller whitespace: kontrollera längden på username + password. 
                if (!validation.CheckInputLength(username) || !validation.CheckInputLength(password))
                {
                    lblregisterFeedback.Content = "Username and password must contain at least 6 characters (max 13 characters)";
                }

                else if (validation.CheckInputLength(username) && validation.CheckInputLength(password))
                {
                    // om längden på username och password är ok - kontrollera antalet siffror i vardera input.
                    int numbersInUsername = validation.CountNumbers(username);
                    int numbersInPassword = validation.CountNumbers(password);
                    if (numbersInUsername < 3 || numbersInPassword < 3)
                    {
                        lblregisterFeedback.Foreground = Brushes.Red;
                        lblregisterFeedback.Content = $"Please try again! Username contains {numbersInUsername} numbers, password contains {numbersInPassword} numbers";
                        txtRequestedUsername.Clear();
                        txtRequestedPassword.Clear();
                    }

                    else if (numbersInUsername >= 3 && numbersInPassword >= 3)
                    {
                        bool isNotAvailable = UserManager.CheckAvailability(username, password);
                        if (!isNotAvailable)
                        {
                            lblregisterFeedback.Content = "Username and password is valid! Please choose your country.";
                            // sätt som globala variabler för tillgänglighetens skull. 
                            chosenUsername = username;
                            chosenPassword = password;

                            // ändra värden på "Visibility" och "IsEnabled" 
                            lblCountry.Visibility = Visibility.Visible;
                            txtRequestedPassword.Clear();
                            txtRequestedUsername.Clear();
                            txtRequestedPassword.IsEnabled = false;
                            txtRequestedUsername.IsEnabled = false;
                            ComboBoxCountry.Visibility = Visibility.Visible;
                            btnGo.Visibility = Visibility.Visible;
                            BtnSignUpReady.Visibility = Visibility.Hidden;

                        }
                        else if (isNotAvailable)
                        {
                            lblregisterFeedback.Foreground = Brushes.Red;
                            lblregisterFeedback.Content = "A user with this username and password already exists.";
                            txtRequestedPassword.Clear();
                            txtRequestedUsername.Clear();
                        }
                    }
                }
            }
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxCountry.SelectedIndex > -1)
            {
                Country selectedCountry = (Country)ComboBoxCountry.SelectedItem;
                User user = new(chosenUsername, chosenPassword, selectedCountry);
                UserManager.users.Add(user);



                MessageBox.Show("New user: " + user.Username + ", " + "lives in: " + user.Location);

                // sätt tillbaka startvärden på "visibility" och "IsEnabled" 
                btnGo.Visibility = Visibility.Hidden;
                BtnSignUpReady.Visibility = Visibility.Visible;
                ComboBoxCountry.Visibility = Visibility.Hidden;
                txtRequestedPassword.IsEnabled = true;
                txtRequestedUsername.IsEnabled = true;
                ComboBoxCountry.SelectedIndex = -1;
                lblCountry.Visibility = Visibility.Hidden;

            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new();
            mainwindow.Show();
            Close();

        }
    }
}



