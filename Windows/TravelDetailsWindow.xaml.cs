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
            lblTravelType.Content = travel.GetType().Name;

            if (travel.GetType().Name.Equals("Vacation"))
            {
                // visa checkbox för "all inclusive" om traveltypen är Vacation. 
                checkAllinclusive.Visibility = Visibility.Visible;
                checkAllinclusive.DataContext = travel;
            }

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

            // Töm textboxes. 
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
                    txtCountry.Clear();
                }
            }

            // Uppdatera Destination--------------------------------------------------
            if (!updateDestination)
            {
                lblTravelersFeedback.Foreground = Brushes.Green;
                selectedTravel.Destination = newDestination;
                lblDestinationFeedback.Content = "Destination was sucessfully updated";
                txtDestination.Clear();
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
                    txtTravelers.Clear();
                }
                else if (!stringToIntConversion)
                {
                    lblTravelersFeedback.Foreground = Brushes.Red;
                    lblTravelersFeedback.Content = "Please input the number of travelers as a digit";
                    txtTravelers.Clear();
                }
            }
            //Uppdatera Startdate----------------------------------------------
            if (!updateStartDate)
            {
                if (validation.CorrectDateFormat(newStartDate))
                {
                    DateTime startdate = validation.CreateDateTimeObject(newStartDate);
                    bool dateIsValid = validation.ChosenDateIsValid(startdate, selectedTravel.EndDate);

                    if (dateIsValid)
                    {
                        selectedTravel.StartDate = startdate;
                        lblStartDateFeedback.Foreground = Brushes.Green;
                        lblStartDateFeedback.Content = "StartDate was sucessfully updated";
                        txtStartDate.Clear();
                    }

                    else if (!dateIsValid)
                    {
                        lblStartDateFeedback.Foreground = Brushes.Red;
                        lblStartDateFeedback.Content = "StartDate must be sooner than EndDate";
                        txtStartDate.Clear();
                    }

                }
            }

            //Uppdatera Enddate----------------------------------------------
            if (!updateEndDate)
            {
                if (validation.CorrectDateFormat(newEndDate))
                {
                    DateTime endDate = validation.CreateDateTimeObject(newEndDate);
                    bool dateIsValid = validation.ChosenDateIsValid(selectedTravel.StartDate, endDate);

                    if (dateIsValid)
                    {
                        selectedTravel.EndDate = endDate;
                        lblTravelersFeedback.Foreground = Brushes.Green;
                        lblEndDateFeedback.Content = "EndDate was sucessfully updated";
                        txtEndDate.Clear();
                    }

                    else if (!dateIsValid)
                    {
                        lblEndDateFeedback.Foreground = Brushes.Red;
                        lblEndDateFeedback.Content = "StartDate must be sooner than EndDate";
                        txtEndDate.Clear();
                    }

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

