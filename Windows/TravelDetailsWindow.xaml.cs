using System;
using System.Windows;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Interfaces;
using TravelPal_Newton.Managers;
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

            // visa detaljer om vald resa: 
            selectedTravel = travel;
            txtCountry.Text = travel.TheCountry.ToString();
            txtDestination.Text = travel.Destination.ToString();
            txtTravelers.Text = travel.Travellers.ToString();
            txtTravelDays.Text = travel.TravelDays.ToString();
            txtStartDate.Text = travel.StartDate.ToShortDateString();
            txtEndDate.Text = travel.EndDate.ToShortDateString();
            txtTravelType.Text = travel.GetType().Name;

            if (travel.GetType().Name.Equals("Vacation"))
            {
                // visa checkbox för "all inclusive" om traveltype är Vacation. 
                checkAllinclusive.Visibility = Visibility.Visible;
                checkAllinclusive.IsEnabled = false;
                checkAllinclusive.DataContext = travel;
            }

            // Om typen är en worktrip, printa meetingdetails. 
            if (travel.GetType().Name.Equals("Worktrip"))
            {
                Worktrip work = (Worktrip)travel;
                ListViewMeetingDetails.Visibility = Visibility.Visible;
                lbldetails.Visibility = Visibility.Visible;
                ListViewMeetingDetails.Items.Add(work.MeetingDetails);
            }

            if (UserManager.signedInUser?.GetType() == typeof(Admin))
            {
                // En admin ska inte kunna redigera resor 
                btnEdit.Visibility = Visibility.Hidden;
            }

            // Mm det finns en packinglist, loopa igenom denna och printa infon om varje item. 
            if (travel.packingList != null && travel.packingList.Count > 0)
            {
                foreach (PackingListItem item in travel.packingList)
                {
                    ListViewPackingList.Items.Add(item.GetInfo());
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Göm Edit-knappen
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
            checkAllinclusive.IsEnabled = true;

            // Clear textboxes. 
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
                // kolla om givet land finns i Enums.Country.
                bool newCountryIsAvailable = validation.CountryExists(newCountry);
                if (newCountryIsAvailable)
                {
                    // Gör en cast från string till enum. 
                    Country enumCast = (Country)Enum.Parse(typeof(Country), newCountry);
                    selectedTravel.TheCountry = enumCast;
                    lblCountryFeedback.Content = "Country was successfully updated.";
                    txtCountry.Clear();
                }
                else if (!newCountryIsAvailable)
                {
                    lblCountryFeedback.Content = "Chosen country is unfortunately not available.";
                    txtCountry.Clear();
                }
            }

            // Uppdatera Destination--------------------------------------------------
            if (!updateDestination)
            {
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
                    lblTravelersFeedback.Content = "Travelers was sucessfully updated";
                    txtTravelers.Clear();
                }
                else if (!stringToIntConversion)
                {
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
                        lblStartDateFeedback.Content = "StartDate was sucessfully updated";
                        txtStartDate.Clear();
                    }

                    else if (!dateIsValid)
                    {
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
                        lblEndDateFeedback.Content = "EndDate was sucessfully updated";
                        txtEndDate.Clear();
                    }

                    else if (!dateIsValid)
                    {
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

