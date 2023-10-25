using System.Windows;
using TravelPal_Newton.Models;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        public TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();
            txtCountry.Text = travel.TheCountry.ToString();
            txtDestination.Text = travel.Destination.ToString();
            txtTravelers.Text = travel.Travellers.ToString();
            txtTravelDays.Text = travel.TravelDays.ToString();
            txtStartDate.Text = travel.StartDate.ToShortDateString();
            txtEndDate.Text = travel.EndDate.ToShortDateString();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtCountry.IsEnabled = true;
            txtDestination.IsEnabled = true;
            txtTravelers.IsEnabled = true;
            txtStartDate.IsEnabled = true;
            txtEndDate.IsEnabled = true;
            btnOK.IsEnabled = true;


        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            /*  string newStartDate = txtStartDate.Text;
            DateTime StartDateConversion;
            if (DateTime.TryParse(newStartDate, out StartDateConversion))
            {
               
            }
            else
            {
                Console.WriteLine("Invalid"); 
            }
          */
        }
    }
}

