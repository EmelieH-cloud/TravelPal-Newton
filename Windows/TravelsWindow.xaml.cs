using System.Collections.ObjectModel;
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
         Om en listview kopplas direkt till en vanlig lista så kommer innehållet i listview
        inte att updateras när listan uppdateras.  Eftersom jag vill att listview ska uppdateras 
        "automatiskt" så använder jag ObservableCollection. 
         -----------------------------------------------------------------------------------*/

        public TravelsWindow(string username, string password)
        {
            InitializeComponent();
            ListViewOverview.ItemsSource = observableTravels;

            uname = username;
            pword = password;

            if (UserManager.signedInUser?.GetType() == typeof(User))
            {
                // vanlig användare är inloggad, dvs det går bra att casta till en user. 
                User userCast = (User)UserManager.signedInUser;
                lblUsername.Content = userCast.Username;

                // undersök om användaren redan har resor tillagda. 
                if (userCast.travels != null)
                {
                    foreach (var travel in userCast.travels)
                    {
                        // om resor är tillagda, lägg till dessa i vår observablecollection. 
                        observableTravels.Add(travel);
                    }
                }
            }

            else if (UserManager.signedInUser?.GetType() == typeof(Admin))
            {
                // en admin är inloggad, det går bra att casta till en admin.
                Admin adminCast = (Admin)UserManager.signedInUser;
                lblUsername.Content = adminCast.Username;

                foreach (Travel travel in TravelManager.travels)
                {
                    observableTravels.Add(travel);
                }

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
            AddTravelWindow addtravelwindow = new AddTravelWindow(observableTravels);
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
    }
}
