using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XPMMS.Pages
{
	public partial class About : ContentPage
	{
		public About ()
		{
			InitializeComponent ();
		    SetPage();
		}

	    private void SetPage()
	    {
            Label header = new Label
            {
                Text = "About Us",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "We're a group of Information Technology students studying at North-West University, Potchefstroom Campus",
                TextColor = Color.White,
                FontSize = 15,

                MinimumHeightRequest = 0
            };

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

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

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    headerDescription
                }
            };
        }
	}
}
