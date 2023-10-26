using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal_Newton.Enums;

namespace TravelPal_Newton.Windows
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        bool allFieldsAreFilledin = false;
        public AddTravelWindow()
        {
            InitializeComponent();

            // fyller comboboxen (Country)
            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                ComboTravelCountry.Items.Add(country);
            }

        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {

            // om ett index är valt...
            if (ComboTravelType.SelectedIndex > -1)
            {
                // hämta detta comboBoxItem
                ComboBoxItem selected = (ComboBoxItem)ComboTravelType.SelectedItem;
                //.. och hämta sedan dess content som en string. 
                string content = (string)selected.Content;

                switch (content)
                {
                    case "Vacation":
                        checkInclusive.Visibility = Visibility.Visible;
                        MessageBox.Show("Please fill in the 'All Inclusive'-box according to your wish.");
                        break;
                    case "Worktrip":
                        lblmdetails.Visibility = Visibility.Visible;
                        txtMeetingDetails.Visibility = Visibility.Visible;
                        MessageBox.Show("(Optional) Please fill in the meeting details as you wish.");
                        break;
                }

            }

        }

        // knappen kommer bara vara synbar efter att användaren valt traveltype. 
        private void btnfinish_Click(object sender, RoutedEventArgs e)
        {

            string destination = txtDestination.Text;
            string startdate = txtStartDate.Text;
            string enddate = txtEndDate.Text;
            string travelers = txtTravelers.Text;

            List<String> input = new();
            input.Add(destination);
            input.Add(startdate);
            input.Add(enddate);
            input.Add(travelers);
            int counter = 0;

            for (int i = 0; i < input.Count; i++)
            {
                bool isNullorEmpty = string.IsNullOrEmpty(input[i]);
                if (!isNullorEmpty)
                {
                    counter++;
                }
            }

            if (counter == 3) // kommer vara 3 om ingen av dessa strings är null/empty. 
                allFieldsAreFilledin = true;

            // gå ej vidare om alla fält inte är ifyllda. 
            if (!allFieldsAreFilledin) { MessageBox.Show("Please fill in all fields"); }

            // Alla fält är ifyllda, och travel är en vacation 
            else if (allFieldsAreFilledin && checkInclusive.Visibility == Visibility.Visible)
            {
                Country country = (Country)ComboTravelCountry.SelectedItem;

                // checkboxen är ifylld. 
                if (checkInclusive.IsChecked != null)
                {

                }
            }

        }
        //-----------------------------------------------------------------------------


    }

}
