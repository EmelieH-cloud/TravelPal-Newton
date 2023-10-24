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
                // vanlig användare är inloggad, det är säkert att casta till en user. 
                User userCast = (User)UserManager.signedInUser;
                lblUsername.Content = userCast.Username;
            }

            else if (UserManager.signedInUser?.GetType() == typeof(Admin))
            {
                // vanlig användare är inloggad, det är säkert att casta till en admin.
                Admin adminCast = (Admin)UserManager.signedInUser;
                lblUsername.Content = adminCast.Username;

            }
        }
    }
}
