using System.Windows;
using TravelPal_Newton.Models;
using Validation = TravelPal_Newton.Validator.Validation;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        Validation validation = new Validation();
        public TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();
            txtCountry.Text = travel.TheCountry.ToString();
            txtDestination.Text = travel.Destination.ToString();
            txtTravelers.Text = travel.Travellers.ToString();
            txtTravelDays.Text = travel.TravelDays.ToString();
            txtStartDate.Text = travel.StartDate.ToShortDateString();
            txtEndDate.Text = travel.EndDate.ToShortDateString();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Visa nedan element i UI 
            btnOK.Visibility = Visibility.Visible;
            lblFormatInstruction.Visibility = Visibility.Visible;

            // Gör nedan element redigerbara. 
            txtCountry.IsEnabled = true;
            txtDestination.IsEnabled = true;
            txtTravelers.IsEnabled = true;
            txtStartDate.IsEnabled = true;
            txtEndDate.IsEnabled = true;
            btnOK.IsEnabled = true;

            // Töm nedan textboxes. 
            txtCountry.Clear();
            txtDestination.Clear();
            txtTravelers.Clear();
            txtStartDate.Clear();
            txtEndDate.Clear();

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            // Hämta inputs
            string newCountry = txtCountry.Text;
            string newDestination = txtDestination.Text;
            string newTravelers = txtTravelers.Text;
            string newStartDate = txtStartDate.Text;
            string newEndDate = txtEndDate.Text;

            bool newCountryIsAvailable = validation.CountryExists(newCountry);


        }
    }
}

