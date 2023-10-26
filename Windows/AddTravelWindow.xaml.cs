using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal_Newton.Create;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Models;
using Validation = TravelPal_Newton.Validator.Validation;


namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        Validation validation = new Validation();
        CreateObjects create = new();
        public AddTravelWindow()
        {
            InitializeComponent();

            // fyller comboboxen med Enum.Country 
            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                ComboTravelCountry.Items.Add(country);
            }
        }
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            // om ett index är valt...
            if (ComboTravelType.SelectedIndex > -1)
            {
                // göm ok knappen
                BtnOK.Visibility = Visibility.Hidden;
                // gör finish knappen synlig
                btnfinish.Visibility = Visibility.Visible;

                // hämta detta comboBoxItem
                ComboBoxItem selected = (ComboBoxItem)ComboTravelType.SelectedItem;
                //.. och hämta sedan dess content som en string. 
                string content = (string)selected.Content;

                switch (content)
                {
                    case "Vacation":
                        checkInclusive.Visibility = Visibility.Visible;
                        MessageBox.Show("Please fill in the 'All Inclusive'-box according to your wish.");
                        break;
                    case "Worktrip":
                        lblmdetails.Visibility = Visibility.Visible;
                        txtMeetingDetails.Visibility = Visibility.Visible;
                        MessageBox.Show("(Optional) Please fill in the meeting details as you wish.");
                        break;
                }
            }
        }

        private void btnfinish_Click(object sender, RoutedEventArgs e)
        {
            string destination = txtDestination.Text;
            string startdate = txtStartDate.Text;
            string enddate = txtEndDate.Text;
            string travelers = txtTravelers.Text;

            if (!string.IsNullOrEmpty(destination)
                && !string.IsNullOrEmpty(startdate)
                && !string.IsNullOrEmpty(enddate)
                && !string.IsNullOrEmpty(travelers)
                && ComboTravelCountry.SelectedIndex > -1)
            {
                Country country = (Country)ComboTravelCountry.SelectedItem;

                if (validation.StringToInt(travelers))
                {
                    int intTravelers = Convert.ToInt32(travelers);
                    bool dateIsValid = DateIsValid(startdate, enddate);

                    if (validation.CorrectDateFormat(startdate) && validation.CorrectDateFormat(enddate) && dateIsValid && checkInclusive.IsVisible)
                    {
                        if (checkInclusive.IsChecked == true)
                        {
                            Vacation withAllInclusive = create.CreateVacation(startdate, enddate, destination, intTravelers, country, true);
                        }

                        else if (checkInclusive.IsChecked == false)
                        {
                            Vacation WithoutAllInclusive = create.CreateVacation(startdate, enddate, destination, intTravelers, country, false);
                        }
                    }

                    else if (validation.CorrectDateFormat(startdate) && validation.CorrectDateFormat(enddate) && dateIsValid && txtMeetingDetails.IsVisible)
                    {
                        string meetingdetails = txtMeetingDetails.Text;
                        Worktrip worktrip = create.CreateWorktrip(startdate, enddate, destination, intTravelers, country, meetingdetails);

                    }

                    else if (validation.CorrectDateFormat(startdate) && validation.CorrectDateFormat(enddate) && dateIsValid && !checkInclusive.IsVisible && !txtMeetingDetails.IsVisible)
                    {
                        Travel travel = create.CreateTravel(startdate, enddate, destination, intTravelers, country);
                    }
                }

                else if (!validation.StringToInt(travelers))
                {
                    MessageBox.Show("Please provide the travelers input as a number.");
                    txtTravelers.Clear();
                }
            }
        }
        public bool DateIsValid(string startdate, string enddate)
        {
            DateTime startDateObject = validation.CreateDateTimeObject(startdate);
            DateTime endDateObject = validation.CreateDateTimeObject(enddate);
            bool dateIsValid = validation.ChosenDateIsValid(startDateObject, endDateObject);

            if (!dateIsValid)
            {
                return false;
            }
            return true;
        }
    }
}







