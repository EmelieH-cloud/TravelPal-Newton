using System;
using System.Windows;
using TravelPal_Newton.Enums;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
        {
            InitializeComponent();

            // fyller comboboxen (Country)
            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                ComboTravelCountry.Items.Add(country);
            }


        }
    }
}
