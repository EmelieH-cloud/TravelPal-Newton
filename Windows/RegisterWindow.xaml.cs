using System;
using System.Windows;
using System.Windows.Media;
using TravelPal_Newton.Enums;
using Validation = TravelPal_Newton.Validator.Validation;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        Validation validation = new Validation();

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
            string password = txtRequestedPassword.Text;

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
                        lblregisterFeedback.Foreground = Brushes.Green;
                        lblregisterFeedback.Content = "Username and password is valid! Please choose your country.";

                        // fälten username och password ska inte gå att redigera längre. 
                        txtRequestedPassword.Clear();
                        txtRequestedUsername.Clear();
                        txtRequestedPassword.IsEnabled = false;
                        txtRequestedUsername.IsEnabled = false;

                        // synlighet för olika element. 
                        ComboBoxCountry.IsEnabled = true;
                        BtnSignUpReady.Visibility = Visibility.Hidden;
                        ComboBoxCountry.Visibility = Visibility.Visible;
                        lblCountry.Visibility = Visibility.Visible;
                        BtnCountry.Visibility = Visibility.Visible;

                    }
                }
            }


        }

        private void BtnCountry_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
