using System;
using System.Windows;
using System.Windows.Media;
using TravelPal_Newton.Enums;
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
        Travel selectedTravel;
        string uname = "";
        string pword = "";


        public TravelDetailsWindow(Travel travel, string username, string password)
        {
            InitializeComponent();
            selectedTravel = travel;
            txtCountry.Text = travel.TheCountry.ToString();
            txtDestination.Text = travel.Destination.ToString();
            txtTravelers.Text = travel.Travellers.ToString();
            txtTravelDays.Text = travel.TravelDays.ToString();
            txtStartDate.Text = travel.StartDate.ToShortDateString();
            txtEndDate.Text = travel.EndDate.ToShortDateString();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // göm knappen
            btnEdit.Visibility = Visibility.Hidden;

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
            // Hämta inputs.
            string newCountry = txtCountry.Text;
            string newDestination = txtDestination.Text;
            string newTravelers = txtTravelers.Text;
            string newStartDate = txtStartDate.Text;
            string newEndDate = txtEndDate.Text;

            // kolla vilka properties som ska uppdateras.
            bool updateCountry = string.IsNullOrEmpty(newCountry);
            bool updateDestination = string.IsNullOrEmpty(newDestination);
            bool updateTravelers = string.IsNullOrEmpty(newTravelers);
            bool updateStartDate = string.IsNullOrEmpty(newStartDate);
            bool updateEndDate = string.IsNullOrEmpty(newEndDate);

            // uppdatera Country------------------------------------------------------
            if (!updateCountry)
            {
                // kolla om angivet land finns i Enums.Country.
                bool newCountryIsAvailable = validation.CountryExists(newCountry);
                if (newCountryIsAvailable)
                {
                    // Gör en cast från string till enum. 
                    Country enumCast = (Country)Enum.Parse(typeof(Country), newCountry);
                    selectedTravel.TheCountry = enumCast;
                    lblTravelersFeedback.Foreground = Brushes.Green;
                    lblCountryFeedback.Content = "Country was successfully updated.";
                    txtCountry.Clear();
                }
                else if (!newCountryIsAvailable)
                {
                    lblTravelersFeedback.Foreground = Brushes.Red;
                    lblCountryFeedback.Content = "That country is unfortunately not available.";
                }
            }

            // Uppdatera Destination--------------------------------------------------
            if (!updateDestination)
            {
                selectedTravel.Destination = newDestination;
                lblDestinationFeedback.Content = "Destination was sucessfully updated";
            }

            // Uppdatera Travelers---------------------------------------------------
            if (!updateTravelers)
            {
                bool stringToIntConversion;
                int intResult;
                stringToIntConversion = int.TryParse(newTravelers, out intResult);
                if (stringToIntConversion)
                {
                    selectedTravel.Travellers = intResult;
                    lblTravelersFeedback.Foreground = Brushes.Green;
                    lblTravelersFeedback.Content = "Travelers was sucessfully updated";
                }
                else if (!stringToIntConversion)
                {
                    lblTravelersFeedback.Foreground = Brushes.Red;
                    lblTravelersFeedback.Content = "Please input the number of travelers as a digit";
                }
            }
            //Uppdatera Startdate----------------------------------------------
            if (!updateStartDate)
            {
                if (validation.CorrectDateFormat(newStartDate))
                {
                    DateTime dt = validation.CreateDateTimeObject(newStartDate);
                    MessageBox.Show(dt.ToLongDateString());
                }
            }

            //Uppdatera Enddate----------------------------------------------
            if (!updateEndDate)
            {
                if (validation.CorrectDateFormat(newEndDate))
                {
                    DateTime dt = Convert.ToDateTime(newEndDate);
                    selectedTravel.StartDate = dt;
                    lblEndDateFeedback.Content = "EndDate was sucessfully updated";
                }
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelswindow = new(uname, pword);
            travelswindow.Show();
            Close();
        }
    }
}

