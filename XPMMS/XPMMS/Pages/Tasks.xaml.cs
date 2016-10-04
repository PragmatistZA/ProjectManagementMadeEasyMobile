using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XPMMS.Pages
{
	public partial class Tasks : ContentPage
	{
		public Tasks ()
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
                Text = "Tasks",
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

            inputGrid.Children.Add(new Label { Text = "Task Description:" }, 0, 0);
            inputGrid.Children.Add(new Label { Text = "MVC coding." }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Hours Required:" }, 0, 1);
            inputGrid.Children.Add(new Label { Text = "20" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Date Created:" }, 0, 2);
            inputGrid.Children.Add(new Label { Text = "16-08-2016" }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Date Due By:" }, 0, 3);
            inputGrid.Children.Add(new Label { Text = "20-09-2016" }, 1, 3);
            inputGrid.Children.Add(new Button { Text = "Delete" }, 1, 4);
            inputGrid.Children.Add(new Label { Text = "Task Description:" }, 0, 5);
            inputGrid.Children.Add(new Label { Text = "Web Service Consumption." }, 1, 5);
            inputGrid.Children.Add(new Label { Text = "Hours Required:" }, 0, 6);
            inputGrid.Children.Add(new Label { Text = "8" }, 1, 6);
            inputGrid.Children.Add(new Label { Text = "Date Created:" }, 0, 7);
            inputGrid.Children.Add(new Label { Text = "18-08-2016" }, 1, 7);
            inputGrid.Children.Add(new Label { Text = "Date Due By:" }, 0, 8);
            inputGrid.Children.Add(new Label { Text = "01-09-2016" }, 1, 8);
            inputGrid.Children.Add(new Button { Text = "Delete" }, 1, 9);
            inputGrid.Children.Add(new Button { Text = "Add New Task" }, 0, 10);


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
