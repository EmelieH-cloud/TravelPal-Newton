using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal_Newton.Create;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Interfaces;
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
                BtnOK.Visibility = Visibility.Hidden;
                btnfinish.Visibility = Visibility.Visible;
                txtDestination.Visibility = Visibility.Visible;
                txtEndDate.Visibility = Visibility.Visible;
                txtStartDate.Visibility = Visibility.Visible;
                txtTravelers.Visibility = Visibility.Visible;
                lbldest.Visibility = Visibility.Visible;
                lblend.Visibility = Visibility.Visible;
                lbltravelers.Visibility = Visibility.Visible;
                lblstartd.Visibility = Visibility.Visible;

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
                            }
                        }
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
                        }
                    }
                    ClearAllFields();
                    AskForPackingList();
                }

                else if (!validation.StringToInt(travelers))
                {
                    MessageBox.Show("Please provide the travelers input as a number.");
                    txtTravelers.Clear();
                }
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

        public void ClearAllFields()
        {
            txtDestination.Clear();
            txtStartDate.Clear();
            txtEndDate.Clear();
            txtTravelers.Clear();
            ComboTravelCountry.SelectedIndex = -1;
            ComboTravelType.SelectedIndex = -1;
            txtMeetingDetails.Visibility = Visibility.Hidden;
            checkInclusive.Visibility = Visibility.Hidden;
        }

        public void AskForPackingList()
        {
            string sMessageBoxText = "Travel created. Do you want to add a packing list?";
            string sCaption = "Packing List";
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxResult answerMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox);

            switch (answerMessageBox)
            {
                case MessageBoxResult.Yes:

                    // Visa alla element som behövs för att skapa ett PackingListItem 
                    txtPackingItem.Visibility = Visibility.Visible;
                    txtPackingItemQuantity.Visibility = Visibility.Visible;
                    BtnAddItem.Visibility = Visibility.Visible;

                    // Göm alla övriga element 
                    ComboTravelCountry.Visibility = Visibility.Hidden;
                    txtDestination.Visibility = Visibility.Hidden;
                    ComboTravelType.Visibility = Visibility.Hidden;
                    txtEndDate.Visibility = Visibility.Hidden;
                    txtStartDate.Visibility = Visibility.Hidden;
                    txtTravelers.Visibility = Visibility.Hidden;
                    lbldest.Visibility = Visibility.Hidden;
                    lblend.Visibility = Visibility.Hidden;
                    lblmdetails.Visibility = Visibility.Hidden;
                    lbltravelers.Visibility = Visibility.Hidden;
                    lblSelectTravel.Visibility = Visibility.Hidden;
                    lblselectCountry.Visibility = Visibility.Hidden;
                    btnfinish.Visibility = Visibility.Hidden;
                    txtMeetingDetails.Visibility = Visibility.Hidden;
                    checkInclusive.Visibility = Visibility.Hidden;

                    break;
                case MessageBoxResult.No:

                    break;


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

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            string itemName = txtPackingItem.Text;
            string itemQuantity = txtPackingItemQuantity.Text;

            if (validation.StringToInt(itemQuantity) && !string.IsNullOrEmpty(itemName))
            {
                int conversion = Convert.ToInt32(itemQuantity);
                OtherItem item = new(itemName, conversion);
                PackingItemsListview.Items.Add(item.GetInfo());
            }
            else
            {
                MessageBox.Show("Please fill in both fields and provide the quantity as a number.");
            }
        }

        private void BtnDonePacking_Click(object sender, RoutedEventArgs e)
        {
            // Användaren måste ha lagt till minst 1 item. 
            if (PackingItemsListview.Items.Count >= 1)
            {
                // Skapa en ny packinglist. 
                List<PackingListItem> packinglist = new();

                // lägg till alla items i denna packinglist. 
                foreach (PackingListItem item in PackingItemsListview.Items)
                {
                    packinglist.Add(item);
                }
                // Hämta den senast tillagda resan. 
                Travel travel = TravelManager.travels[^1];

                // tilldela packinglist 
                travel.packingList = packinglist;
                PackingItemsListview.Items.Remove(packinglist);
            }
        }
    }
}







