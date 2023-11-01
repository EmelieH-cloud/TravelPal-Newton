using System.Windows;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
        }

        private void btnClosew_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
