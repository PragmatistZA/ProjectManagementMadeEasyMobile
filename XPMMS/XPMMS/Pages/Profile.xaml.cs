using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XPMMS.Pages
{
	public partial class Profile : ContentPage
	{
		public Profile ()
		{
			InitializeComponent ();
		    SetPage();
		}

	    private void SetPage()
	    {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "Profile",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };

            Label headerDescription = new Label
            {
                Text = "A mobile application tool designed to make projects much more bearable.",
                TextColor = Color.White,
                FontSize = 15,

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

            inputGrid.Children.Add(new Label { Text = "Title:" }, 0, 0);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "First Name:" }, 0, 1);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Last Name:" }, 0, 2);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 3);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 3);
            inputGrid.Children.Add(new Label { Text = "Password:" }, 0, 4);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 4);
            inputGrid.Children.Add(new Label { Text = "Contact:" }, 0, 5);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 5);
            inputGrid.Children.Add(new Label { Text = "Job:" }, 0, 6);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 6);
            inputGrid.Children.Add(new Button { Text = "Save" }, 1, 7);


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
