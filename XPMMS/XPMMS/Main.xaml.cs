using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XPMMS
{
	public partial class Main : ContentPage
	{
        Label label;
        int clickTotal = 0;
        public Main ()
		{
			InitializeComponent ();

            Label header = new Label
            {
                Text = "Button",
                Font = Font.SystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            Button button = new Button
            {
                Text = "Click Me!",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            button.Clicked += OnButtonClicked;

            label = new Label
            {
                Text = "0 button clicks",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    button,
                    label
                }
            };
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            clickTotal += 1;
            label.Text = $"{clickTotal} button click{(clickTotal == 1 ? "" : "s")}";
        }
    }
}
