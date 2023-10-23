using System;
using System.Windows;
using TravelPal_Newton.Enums;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
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

        }
    }
}
