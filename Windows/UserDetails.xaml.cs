using System;
using System.Windows;
using TravelPal_Newton.Enums;
using TravelPal_Newton.Managers;
using TravelPal_Newton.Models;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Window
    {
        public UserDetails()
        {
            InitializeComponent();

            if (UserManager.signedInUser?.GetType() == typeof(User))
            {
                User userCast = (User)UserManager.signedInUser;
                txtUsername.Text = userCast.Username;
                txtuserLocation.Text = userCast.Location.ToString();


                foreach (Country EUcountry in Enum.GetValues(typeof(EuropeanCountry)))
                {
                    if (Enum.IsDefined(typeof(EuropeanCountry), userCast.Location.ToString()))
                    {
                        lblEUmember.Content = "Yes";
                    }

                    else
                    {
                        lblEUmember.Content = "No";
                    }

                }
            }

        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
