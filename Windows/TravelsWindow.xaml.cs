﻿using System.Collections.ObjectModel;
using System.Windows;
using TravelPal_Newton.Managers;
using TravelPal_Newton.Models;

namespace TravelPal_Newton.Windows
{

    public partial class TravelsWindow : Window
    {

        string uname;
        string pword;
        readonly ObservableCollection<Travel> observableTravels = new();

        /*
         ObservableCollection----------------------------------------------------------------
         Om en listview kopplas direkt till en vanlig list så kommer innehållet i listviewn
        inte att updateras när listan uppdateras.  Eftersom jag vill att listview ska uppdateras 
         automatiskt så använder jag ObservableCollection. 
         -----------------------------------------------------------------------------------*/

        public TravelsWindow(string username, string password)
        {
            InitializeComponent();
            ListViewOverview.ItemsSource = observableTravels;

            uname = username;
            pword = password;

            if (UserManager.signedInUser?.GetType() == typeof(User))
            {
                // vanlig användare är inloggad, det går bra att casta till en user. 
                User userCast = (User)UserManager.signedInUser;
                lblUsername.Content = userCast.Username;

                // undersök om user redan har resor tillagda. 
                if (userCast.travels != null)
                {
                    foreach (var travel in userCast.travels)
                    {
                        // om resor är tillagda, lägg till dessa i observablecollection. 
                        observableTravels.Add(travel);
                    }
                }
            }

            else if (UserManager.signedInUser?.GetType() == typeof(Admin))
            {
                // En admin ska inte kunna lägga till resor, gömmer add-knappen. 
                btnAddtravel.Visibility = Visibility.Hidden;
                btnAddtravel.IsEnabled = false;
                Admin adminCast = (Admin)UserManager.signedInUser;
                lblUsername.Content = adminCast.Username;

                foreach (Travel travel in TravelManager.travels)
                {
                    observableTravels.Add(travel); // visa alla resor för admin 
                }
            }
        }



        private void btnAddtravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addtravelwindow = new AddTravelWindow();
            addtravelwindow.Show();
            Close();
        }
        private void btnTravelDetails_Click(object sender, RoutedEventArgs e)
        {

            Travel travel = (Travel)ListViewOverview.SelectedItem;
            if (travel != null)
            {
                TravelDetailsWindow traveldetailswindow = new(travel, uname, pword);
                traveldetailswindow.Show();
                Close();
            }

            else
            {
                MessageBox.Show("Please select a travel in the list");
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            Travel travel = (Travel)ListViewOverview.SelectedItem;
            if (travel != null)
            {
                string sMessageBoxText = "Are you sure you want to remove this travel?";
                string sCaption = "Remove travel";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage iconMessageBox = MessageBoxImage.Warning;
                MessageBoxResult resultMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, iconMessageBox);

                switch (resultMessageBox)
                {
                    case MessageBoxResult.Yes:
                        observableTravels.Remove(travel);
                        TravelManager.travels.Remove(travel);
                        break;
                }
            }
            else if (travel == null)
            {
                MessageBox.Show("Please select a travel in the list.");
            }
        }


        private void BtnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.Show();
        }

        private void btninfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }
    }
}
