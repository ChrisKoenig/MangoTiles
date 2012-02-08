using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MangoTiles
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                var firstName = NavigationContext.QueryString["FirstName"];
                var thePerson = App.People.Single(p => p.FirstName == firstName);
                this.DataContext = thePerson;
            };
        }

        private void PinTileToStartMenu()
        {
            var thePerson = this.DataContext as Person;

            // Check the existence of the secondary tile
            var shellTile = ShellTile.ActiveTiles.FirstOrDefault(
                x => x.NavigationUri.ToString().Contains("FirstName=" + thePerson.FirstName));

            if (shellTile != null)
                return;

            // Create the tile data with some proeprties
            var tileData = new StandardTileData
            {
                Title = String.Format("{0} {1}", thePerson.FirstName, thePerson.LastName),
                Count = DateTime.Now.Year - thePerson.BirthDate.Year,
                BackTitle = "Back page",
                BackContent = "This is the back page for " + thePerson.FirstName,
                BackBackgroundImage = new Uri("back.jpg", UriKind.Relative)
            };

            // create the tile at the start screen
            Uri newUri = new Uri("/DetailsPage.xaml?FirstName=" + thePerson.FirstName, UriKind.Relative);
            ShellTile.Create(newUri, tileData);

            foreach (var item in ShellTile.ActiveTiles)
            {
                Debug.WriteLine(item.NavigationUri);
            }
        }

        private void PinButton_Click(object sender, RoutedEventArgs e)
        {
            PinTileToStartMenu();
        }

        private void ChangeTileButton_Click(object sender, RoutedEventArgs e)
        {
            var thePerson = this.DataContext as Person;

            // find the tile
            var shellTile = ShellTile.ActiveTiles.FirstOrDefault(
                x => x.NavigationUri.ToString().Contains("FirstName=" + thePerson.FirstName));
            if (shellTile == null)
                return;

            // set new properties (only those that changed)
            var tileData = new StandardTileData
            {
                Count = 0,
                BackTitle = "UPDATED!",
                BackgroundImage = new Uri("front.jpg", UriKind.Relative)
            };

            // update the tile in place
            shellTile.Update(tileData);
        }
    }
}