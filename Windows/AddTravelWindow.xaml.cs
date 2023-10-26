using System;
using System.Windows;
using System.Windows.Controls;
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
        public AddTravelWindow()
        {
            InitializeComponent();

            // fyller comboboxen (Country)
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

            // fortsätt endast om samtliga fält är ifyllda...
            if (!string.IsNullOrEmpty(destination)
                && !string.IsNullOrEmpty(startdate)
                && !string.IsNullOrEmpty(enddate)
                && !string.IsNullOrEmpty(travelers)
                && ComboTravelCountry.SelectedIndex > -1)
            {
                // casta till en Enum.Country 
                Country country = (Country)ComboTravelCountry.SelectedItem;

                // ...undersök om travelers går att omvandla till int. 
                if (validation.StringToInt(travelers))
                {
                    //omvandla isåfall till int. 
                    int intTravelers = Convert.ToInt32(travelers);

                    // Alla fält är ifyllda, datum är korrekt ifyllt, traveltype är vacation 
                    if (validation.CorrectDateFormat(startdate) && validation.CorrectDateFormat(enddate) && checkInclusive.IsVisible)
                    {
                        // skapa en Vacation. 
                        CreateVacation(startdate, enddate, destination, intTravelers, country);
                    }
                }
            }
        }

        public void CreateVacation(string startdate, string enddate, string destination, int travelers, Country country)
        {
            DateTime startDateObject = validation.CreateDateTimeObject(startdate);
            DateTime endDateObject = validation.CreateDateTimeObject(enddate);
            bool dateIsValid = validation.ChosenDateIsValid(startDateObject, endDateObject);

            if (!dateIsValid)
            {
                MessageBox.Show("The start date must be sooner than the end date.");
                txtStartDate.Clear();
                txtEndDate.Clear();
            }

            else if (dateIsValid)
            {
                if (checkInclusive.IsChecked == true)
                {
                    Vacation vacation = new(destination, travelers, startDateObject, endDateObject, country, true);
                    MessageBox.Show("travel created");
                }
            }
        }



    }
}



//-----------------------------------------------------------------------------




