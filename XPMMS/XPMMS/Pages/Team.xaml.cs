using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XPMMS.Models;

namespace XPMMS.Pages
{
	public partial class Team : ContentPage
	{
	    private UserModel loggedInUser;

		public Team (UserModel loggedInUser)
		{
			InitializeComponent ();
		    this.loggedInUser = loggedInUser;
		    SetPage();
		}

	    private void SetPage()
	    {

            Label header = new Label
            {
                Text = "My Team",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "Join an existing Team",
                TextColor = Color.White,
                FontSize = 20,

                MinimumHeightRequest = 0
            };

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            //BackgroundColor = Color.Black;

            Picker picker = new Picker
            {
                Title = "PMME Navigation",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            string[] navPages =
            {
                "Dashboard",
                "About",
                "Contact",
                "Login",
                "Register"
            };

            foreach (string navPage in navPages)
            {
                picker.Items.Add(navPage);
            }

            Grid nav = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,


            };

            nav.Children.Add(new Button { Text = "XPMME" }, 0, 0);
            nav.Children.Add(new Button { Text = "DashBoard" }, 1, 0);
            nav.Children.Add(new Button { Text = "About" }, 2, 0);
            nav.Children.Add(new Button { Text = "Contact" }, 3, 0);

            Grid inputGrid = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            inputGrid.Children.Add(new Label { Text = "Team Name:" }, 0, 0);
            inputGrid.Children.Add(new Label { Text = "Digital Anomaly" }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Team Leader:" }, 0, 1);
            inputGrid.Children.Add(new Label { Text = "John Doe" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, 2);
            inputGrid.Children.Add(new Label { Text = "James Young" }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, 3);
            inputGrid.Children.Add(new Label { Text = "Rica Page" }, 1, 3);
            inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, 4);
            inputGrid.Children.Add(new Label { Text = "David O'Reilly" }, 1, 4);


            Content = new StackLayout
            {
                Children =
                {
                    picker,
                    header,
                    inputGrid
                }
            };
        }
	}
}
