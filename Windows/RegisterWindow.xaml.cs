using System;
using System.Windows;
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


        }
    }
}
