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
        List<PackingListItem> packinglist = new();
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
            BtnOK.Visibility = Visibility.Visible;
            checkInclusive.Visibility = Visibility.Hidden;

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

                // "går det att konvertera antal travelers till en int?"
                if (validation.StringToInt(travelers))
                {
                    //konvertera isåfall...
                    int intTravelers = Convert.ToInt32(travelers);

                    // skapa en bool för vardera datum som kommer vara true om båda datum är i korrekt format. 
                    bool startdateFormat = validation.CorrectDateFormat(startdate);
                    bool enddateFormat = validation.CorrectDateFormat(enddate);

                    if (startdateFormat && enddateFormat)
                    {
                        // skapa en bool som kommer vara true om datumen är giltliga
                        bool dateIsValid = DateIsValid(startdate, enddate);

                        //---------------------- fortsätt endast om datumen är skrivna i rätt format och datumen är giltliga---------------------------------//
                        if (validation.CorrectDateFormat(startdate) && validation.CorrectDateFormat(enddate) && dateIsValid)
                        {
                            if (checkInclusive.IsVisible && checkInclusive.IsChecked == true)
                            {
                                // Skapa en vacation, all-inclusive. 
                                Vacation withAllInclusive = create.CreateVacation(startdate, enddate, destination, intTravelers, country, true);
                                TravelManager.travels.Add(withAllInclusive);
                                ClearFields();
                                MessageBox.Show("Travel created. You may now create a packlist");

                                if (UserManager.signedInUser?.GetType() == typeof(User))
                                {
                                    // hämta signedInUser och lägg till resa på usern. 
                                    User userCast = (User)UserManager.signedInUser;
                                    AddTravelToUser(withAllInclusive, userCast);
                                    addedTravel = withAllInclusive;
                                }
                            }

                            else if (checkInclusive.IsChecked == false)
                            {
                                // Skapa en vacation, utan all-inclusive 
                                Vacation WithoutAllInclusive = create.CreateVacation(startdate, enddate, destination, intTravelers, country, false);
                                TravelManager.travels.Add(WithoutAllInclusive);
                                ClearFields();
                                MessageBox.Show("Travel created. You may now create a packlist");

                                if (UserManager.signedInUser?.GetType() == typeof(User))
                                {
                                    // hämta signedInUser och lägg till denna resa på usern. 
                                    User userCast = (User)UserManager.signedInUser;
                                    AddTravelToUser(WithoutAllInclusive, userCast);
                                    addedTravel = WithoutAllInclusive;

                                }
                            }

                            else if (txtMeetingDetails.IsVisible)
                            {
                                // Skapa en worktrip
                                string meetingdetails = txtMeetingDetails.Text;
                                Worktrip worktrip = create.CreateWorktrip(startdate, enddate, destination, intTravelers, country, meetingdetails);
                                TravelManager.travels.Add(worktrip);
                                ClearFields();
                                MessageBox.Show("Travel created. You may now create a packlist");

                                if (UserManager.signedInUser?.GetType() == typeof(User))
                                {

                                    User userCast = (User)UserManager.signedInUser;
                                    AddTravelToUser(worktrip, userCast);
                                    addedTravel = worktrip;

                                }
                            }
                            else if (!checkInclusive.IsVisible && !txtMeetingDetails.IsVisible)
                            {
                                // Skapa en travel 
                                Travel travel = create.CreateTravel(startdate, enddate, destination, intTravelers, country);
                                TravelManager.travels.Add(travel);
                                ClearFields();
                                MessageBox.Show("Travel created. You may now create a packlist");

                                if (UserManager.signedInUser?.GetType() == typeof(User))
                                {
                                    User userCast = (User)UserManager.signedInUser;
                                    AddTravelToUser(travel, userCast);
                                    addedTravel = travel;

                                }
                            }
                            BtnConfirm.IsEnabled = true;
                            btnPackingListComplete.IsEnabled = true;
                            // avgör om länderna är utanför eller innanför EU 
                            checkEUcountries();

                        }

                        //-----------------------------------------------------------------------------------------------------------------//

                    }

                    else
                    {
                        MessageBox.Show("Startdate and enddate must be written in correct format. Startdate must also be earlier than enddate.");
                    }

                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
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

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            // göm confirm-knappen
            BtnConfirm.Visibility = Visibility.Hidden;
            // visa add-knappen
            btnAddTravelDocument.Visibility = Visibility.Visible;

            if (CheckTravelDocument.IsChecked == true)
            {
                // visa checkboxen "required?" 
                CheckRequired.Visibility = Visibility.Visible;
            }

            else if (CheckTravelDocument.IsChecked == false)
            {
                // visa textboxen för quantity 
                txtQuantity.Visibility = Visibility.Visible;
                lblquantity.Visibility = Visibility.Visible;
            }

        }

        private void checkEUcountries()
        {
            if (UserManager.signedInUser?.GetType() == typeof(User) && addedTravel != null)
            {
                User userCast = (User)UserManager.signedInUser;
                Country livingCountry = userCast.Location;
                Country travelCountry = addedTravel.TheCountry;
                bool userLivesinEU = false;
                bool travelCountryIsInEU = false;

                foreach (Country EUcountry in Enum.GetValues(typeof(EuropeanCountry)))
                {
                    if (livingCountry == EUcountry)
                    {
                        userLivesinEU = true;
                    }

                    if (travelCountry == EUcountry)
                    {
                        travelCountryIsInEU = true;
                    }
                } // loop avslutas
                  // kalla på metoden som avgör huruvida ett pass automatiskt ska läggas till i packlistan. 
                PassportHandler(userLivesinEU, travelCountryIsInEU);
            }
        }

        private void PassportHandler(bool userLivesinEU, bool travelCountryIsInEU)
        {
            // Om användaren bor utanför EU, oavsett destinationsland ska ett pass (med required true)
            // läggas till i packlistan
            if (!userLivesinEU)
            {
                TravelDocument RequiredPassport = new(true, "Passport");
                packingListView.Items.Add(RequiredPassport.GetInfo());
                packinglist.Add(RequiredPassport);
            }

            //Om resan går till ett land inom EU och användaren bor inom EU, ska ett
            //TravelDocument med name “Passport” (med required false) läggas till i packlistan.
            else if (userLivesinEU && travelCountryIsInEU)
            {
                TravelDocument NonRequiredPassport = new(false, "Passport");
                packingListView.Items.Add(NonRequiredPassport.GetInfo());
                packinglist.Add(NonRequiredPassport);
            }

            // Om resan går till ett land utanför EU och användaren bor inom EU ska ett TravelDocument
            // med name “Passport” (med required true) läggas till i packlistan.

            else if (userLivesinEU && !travelCountryIsInEU)
            {
                TravelDocument RequiredPassport = new(true, "Passport");
                packingListView.Items.Add(RequiredPassport.GetInfo());
                packinglist.Add(RequiredPassport);
            }

        }

        private void ClearFields()
        {
            txtDestination.Clear();
            txtEndDate.Clear();
            txtStartDate.Clear();
            txtTravelers.Clear();
            txtMeetingDetails.Clear();
        }


        private void btnAddTravelDocument_Click(object sender, RoutedEventArgs e)
        {
            string name = txtItemName.Text;
            btnAddTravelDocument.Visibility = Visibility.Hidden;
            BtnConfirm.Visibility = Visibility.Visible;
            // skapa ett required traveldocument
            if (CheckRequired.IsChecked == true)
            {
                TravelDocument traveldocument = create.CreateTravelDocument(true, name);
                packingListView.Items.Add(traveldocument.GetInfo());
                packinglist.Add(traveldocument);
            }

            // skapa ett non-required traveldocument
            else if (CheckTravelDocument.IsChecked == false)
            {
                TravelDocument traveldocument = create.CreateTravelDocument(false, name);
                packingListView.Items.Add(traveldocument.GetInfo());
                packinglist.Add(traveldocument);
            }

            // skapa ett vanligt item
            else if (txtQuantity.Visibility == Visibility.Visible)
            {
                string quantity = txtQuantity.Text;
                if (validation.StringToInt(quantity))
                {
                    OtherItem item = create.CreateItem(name, quantity);
                    packingListView.Items.Add(item);
                    packinglist.Add(item);
                }

                else if (!validation.StringToInt(quantity))
                {
                    MessageBox.Show("Please make sure to provide the quantity as a number.");
                }

            }
            txtItemName.Clear();
            txtQuantity.Visibility = Visibility.Hidden;
            lblquantity.Visibility = Visibility.Hidden;

        }

        private void btnPackingListComplete_Click(object sender, RoutedEventArgs e)
        {
            if (packinglist.Count > 0 && addedTravel != null)
            {
                addedTravel.packingList = packinglist;
                MessageBox.Show("Packinglist sucessfully added.");
                txtItemName.Clear();
                packingListView.Items.Clear();
            }

        }
    }
}





