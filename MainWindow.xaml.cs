using System.Windows;
using TravelPal_Newton.Managers;
using TravelPal_Newton.Windows;

namespace TravelPal_Newton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password.ToString();

            bool sucessOrFail = UserManager.SignInUser(username, password);
            if (sucessOrFail)
            {

            }

            else if (!sucessOrFail)
            {
                lblFeedback.Content = "Error";
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerwindow = new RegisterWindow();
            registerwindow.Show();
            Close();
        }
    }
}
