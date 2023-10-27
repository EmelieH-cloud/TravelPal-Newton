using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal_Newton.Create;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Managers;
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
        Travel? addedTravel;


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
                // ..hämta comboBoxItem på valt index 
                ComboBoxItem selected = (ComboBoxItem)ComboTravelType.SelectedItem;
                //.. casta dess content till en string. 
                string content = (string)selected.Content;
                // gör antingen checkboxen eller textboxen synlig
                switch (content)
                {
                    case "Vacation":
                        checkInclusive.Visibility = Visibility.Visible;
                        break;
                    case "Worktrip":
                        lblmdetails.Visibility = Visibility.Visible;
                        txtMeetingDetails.Visibility = Visibility.Visible;
                        break;
                }
                btnFinish.Visibility = Visibility.Visible;
                BtnOK.Visibility = Visibility.Hidden;
            }
        }
        private void btnfinish_Click(object sender, RoutedEventArgs e)
        {
            // hämta inputs
            string destination = txtDestination.Text;
            string startdate = txtStartDate.Text;
            string enddate = txtEndDate.Text;
            string travelers = txtTravelers.Text;

            // går endast vidare om samtliga fält innehåller input 
            if (!string.IsNullOrEmpty(destination)
                && !string.IsNullOrEmpty(startdate)
                && !string.IsNullOrEmpty(enddate)
                && !string.IsNullOrEmpty(travelers)
                && ComboTravelCountry.SelectedIndex > -1)
            {
                // casta comboBoxItem till Enum.Country 
                Country country = (Country)ComboTravelCountry.SelectedItem;

                // kolla om det går att konvertera antal travelers till en int. 
                if (validation.StringToInt(travelers))
                {
                    //konvertera isåfall...
                    int intTravelers = Convert.ToInt32(travelers);

                    // skapa en bool för vardera datum som kommer vara true om datumen är i korrekt format. 
                    bool startdateFormat = validation.CorrectDateFormat(startdate);
                    bool enddateFormat = validation.CorrectDateFormat(enddate);

                    // skapa en bool som kommer vara true om datumen är giltliga
                    bool dateIsValid = DateIsValid(startdate, enddate);

                    // fortsätt endast om datumen är skrivna i rätt format, datumen är giltliga och checkboxen syns. 
                    if (validation.CorrectDateFormat(startdate) && validation.CorrectDateFormat(enddate) && dateIsValid && checkInclusive.IsVisible)
                    {
                        if (checkInclusive.IsChecked == true)
                        {
                            // Skapa en vacation med all-inclusive. 
                            Vacation withAllInclusive = create.CreateVacation(startdate, enddate, destination, intTravelers, country, true);
                            TravelManager.travels.Add(withAllInclusive);

                            if (UserManager.signedInUser?.GetType() == typeof(User))
                            {
                                // hämta signedInUser och lägg till denna resa på usern. 
                                User userCast = (User)UserManager.signedInUser;
                                AddTravelToUser(withAllInclusive, userCast);
                                addedTravel = withAllInclusive;
                            }
                        }

                        else if (checkInclusive.IsChecked == false)
                        {
                            // Skapa en vacation utan all-inclusive 
                            Vacation WithoutAllInclusive = create.CreateVacation(startdate, enddate, destination, intTravelers, country, false);
                            TravelManager.travels.Add(WithoutAllInclusive);

                            if (UserManager.signedInUser?.GetType() == typeof(User))
                            {
                                // hämta signedInUser och lägg till denna resa på usern. 
                                User userCast = (User)UserManager.signedInUser;
                                AddTravelToUser(WithoutAllInclusive, userCast);
                                addedTravel = WithoutAllInclusive;

                            }
                        }
                    }

                    if (!validation.CorrectDateFormat(startdate) || !validation.CorrectDateFormat(enddate) || !dateIsValid)
                    {
                        MessageBox.Show("Please make sure the date is written in correct format, and startdate must be earlier than enddate.");
                    }

                    else if (validation.CorrectDateFormat(startdate) && validation.CorrectDateFormat(enddate) && dateIsValid && txtMeetingDetails.IsVisible)
                    {
                        // Skapa en worktrip
                        string meetingdetails = txtMeetingDetails.Text;
                        Worktrip worktrip = create.CreateWorktrip(startdate, enddate, destination, intTravelers, country, meetingdetails);
                        TravelManager.travels.Add(worktrip);

                        if (UserManager.signedInUser?.GetType() == typeof(User))
                        {
                            // hämta signedInUser och lägg till denna resa på usern.
                            User userCast = (User)UserManager.signedInUser;
                            AddTravelToUser(worktrip, userCast);
                            addedTravel = worktrip;

                        }
                    }
                    else if (validation.CorrectDateFormat(startdate) && validation.CorrectDateFormat(enddate) && dateIsValid && !checkInclusive.IsVisible && !txtMeetingDetails.IsVisible)
                    {
                        // Skapa en travel 
                        Travel travel = create.CreateTravel(startdate, enddate, destination, intTravelers, country);
                        TravelManager.travels.Add(travel);

                        if (UserManager.signedInUser?.GetType() == typeof(User))
                        {
                            // hämta signedInUser och lägg till denna resa på usern.
                            User userCast = (User)UserManager.signedInUser;
                            AddTravelToUser(travel, userCast);
                            addedTravel = travel;

                        }
                    }

                }

                else if (!validation.StringToInt(travelers))
                {
                    MessageBox.Show("Please provide the travelers input as a number.");
                    txtTravelers.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }

        public void AddTravelToUser(Travel travel, User user)
        {
            if (user.travels != null)
            {
                user.travels.Add(travel);
            }

            else if (user.travels == null)
            {
                List<Travel> travelsList = new();
                travelsList.Add(travel);
                user.travels = travelsList;
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

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (UserManager.signedInUser?.GetType() == typeof(User))
            {
                User userCast = (User)UserManager.signedInUser;
                TravelsWindow travelswindow = new(userCast.Username, userCast.Password);
                travelswindow.Show();
                Close();
            }

        }

    }
}





