using System.Windows;
using TravelPal_Newton.Managers;
using TravelPal_Newton.Models;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow(string username, string password)
        {
            InitializeComponent();

            if (UserManager.signedInUser?.GetType() == typeof(User))
            {
                // vanlig användare är inloggad. 
            }

            else if (UserManager.signedInUser?.GetType() == typeof(Admin))
            {
                // admin är inloggad. 
            }
        }
    }
}
