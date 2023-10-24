﻿using System.Collections.ObjectModel;
using System.Windows;
using TravelPal_Newton.Managers;
using TravelPal_Newton.Models;

namespace TravelPal_Newton.Windows
{

    public partial class TravelsWindow : Window
    {


        readonly ObservableCollection<Travel> observableTravels = new();

        /*
         ObservableCollection----------------------------------------------------------------
         Om en listview kopplas direkt till en vanlig array (dvs Listview.ItemsSource = array)
         så kommer innehållet i listview inte updateras när element i denna array uppdateras. 
         Eftersom jag vill att listview ska kunna uppdateras EFTER att ItemsSource är satt,
         så använder jag ObservableCollection. 
         -----------------------------------------------------------------------------------*/

        public TravelsWindow(string username, string password)
        {
            InitializeComponent();
            ListViewOverview.ItemsSource = observableTravels;

            if (UserManager.signedInUser?.GetType() == typeof(User))
            {
                // vanlig användare är inloggad --> det går bra att casta till en user. 
                User userCast = (User)UserManager.signedInUser;
                lblUsername.Content = userCast.Username;

                // undersök om användaren redan har resor tillagda. 
                if (userCast.travels != null)
                {
                    foreach (var travel in userCast.travels)
                    {
                        observableTravels.Add(travel);
                    }

                }

            }

            else if (UserManager.signedInUser?.GetType() == typeof(Admin))
            {
                // en admin är inloggad --> det går bra att casta till en admin.
                Admin adminCast = (Admin)UserManager.signedInUser;
                lblUsername.Content = adminCast.Username;
            }
        }



        private void btnUserDetailsWindow_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userdetailswindow = new();
            userdetailswindow.Show();
            Close();
        }

        private void btnAddtravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addtravelwindow = new AddTravelWindow();
            addtravelwindow.Show();
            Close();
        }
    }
}
