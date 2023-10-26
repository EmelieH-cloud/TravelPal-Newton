﻿using System.Collections.Generic;
using System.Windows;
using TravelPal_Newton.Interfaces;
using TravelPal_Newton.Managers;
using TravelPal_Newton.Models;
using TravelPal_Newton.Windows;
using Validation = TravelPal_Newton.Validator.Validation;

namespace TravelPal_Newton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Validation validation = new Validation();

        public MainWindow()
        {
            InitializeComponent();

            // Demo-users
            User user = (User)UserManager.users[0];

            // Demo-items 
            PackingListItem item1 = PackingItemsManager.packingList_1[0];
            PackingListItem item2 = PackingItemsManager.packingList_1[1];
            PackingListItem item3 = PackingItemsManager.packingList_1[2];

            // Demo-packinglist
            List<PackingListItem> packinglist1 = new();
            packinglist1.Add(item1);
            packinglist1.Add(item2);
            packinglist1.Add(item3);

            // Demo-travels
            Travel travel1 = (Travel)TravelManager.travels[0];
            Travel travel2 = (Travel)TravelManager.travels[1];
            Travel travel3 = (Travel)TravelManager.travels[2];
            List<Travel> userTravels = new();
            userTravels.Add(travel1);
            userTravels.Add(travel2);
            userTravels.Add(travel3);

            // Tilldela travels till user
            user.travels = userTravels;

            // Tilldela packinglist till user 
            travel1.packingList = packinglist1;

        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password.ToString();

            // kontrollera att input inte är null, empty eller innehåller whitespace. 
            if (validation.CheckEmptyNullWhiteSpace(username) && validation.CheckEmptyNullWhiteSpace(password))
            {
                // om input är ok, gå vidare med att leta efter detta username och password i listan av registrerade users.
                bool userExists = UserManager.SignInUser(username, password);
                if (userExists)
                {
                    // om användaren finns, öppna nytt fönster, skicka med username + password. 
                    TravelsWindow travelswindow = new(username, password);
                    travelswindow.Show();
                    Close();

                }

                else if (!userExists)
                {
                    lblFeedback.Content = "User not found.";
                    ClearAllFields();
                }
            }

            else if (!validation.CheckEmptyNullWhiteSpace(username) || !validation.CheckEmptyNullWhiteSpace(password))
            {
                // om input innehåller whitespace, är null eller empty...
                lblFeedback.Content = "Please fill in all fields";
                ClearAllFields();
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerwindow = new RegisterWindow();
            registerwindow.Show();
            Close();
        }

        public void ClearAllFields()
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
