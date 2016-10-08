using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

//TODO: Add this Contact.xaml.cs to drop-down arrow under Contact.xaml (No freaking clue how)

namespace XPMMS.Pages
{
	public partial class Contact : ContentPage
	{
		public Contact ()
		{
			InitializeComponent ();
            SetPage();
		}

        private void SetPage()
        {
            Label header = new Label
            {
                Text = "Contact Us",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label lbl1 = new Label
            {
                Text = "Potchefstroom Campus",
                TextColor = Color.White,
                FontSize = 15,

                MinimumHeightRequest = 0
            };
            Label lbl2 = new Label
            {
                Text = "Hoffman Street",
                TextColor = Color.White,
                FontSize = 15,

                MinimumHeightRequest = 0
            };
            Label lbl3 = new Label
            {
                Text = "Potchefstroom",
                TextColor = Color.White,
                FontSize = 15,

                MinimumHeightRequest = 0
            };
            Label lbl4 = new Label
            {
                Text = "2520",
                TextColor = Color.White,
                FontSize = 15,

                MinimumHeightRequest = 0
            };
            Label lbl5 = new Label
            {
                Text = "South Africa",
                TextColor = Color.White,
                FontSize = 15,

                MinimumHeightRequest = 0
            };
            Label lbl6 = new Label
            {
                Text = " ",
                FontSize = 15,

                MinimumHeightRequest = 0
            };
            Label lbl7 = new Label
            {
                Text = "Support: ",
                TextColor = Color.White,
                FontSize = 15,

                MinimumHeightRequest = 0
            };
            Label lbl8 = new Label
            {
                Text = "projectmanagementmadeeasy.supp@gmail.com",
                TextColor = Color.Blue,
                FontSize = 15,

                MinimumHeightRequest = 0
            };

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);      

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    lbl1,
                    lbl2,
                    lbl3,
                    lbl4,
                    lbl5,
                    lbl6,
                    lbl7,
                    lbl8

                }
            };
        }
    }
}
