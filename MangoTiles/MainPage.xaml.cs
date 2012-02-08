using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace MangoTiles
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += (s, e) =>
                {
                    PeopleListBox.ItemsSource = App.People;
                };
        }

        private void PeopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = PeopleListBox.SelectedItem as Person;
            if (selectedItem == null)
                return;
            var firstName = selectedItem.FirstName;
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?FirstName=" + firstName, UriKind.Relative));
        }
    }
}