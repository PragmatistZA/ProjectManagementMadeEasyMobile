using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XPMMS;
using XPMMS.Models;

namespace XPMMS.Pages
{
	public partial class HamburgerMenuMasterPage : ContentPage
	{
        public ListView ListView { get { return listView; } }

	    ListView listView;

        public HamburgerMenuMasterPage ()
		{
			InitializeComponent ();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Log Out"
                //IconSource = "contacts.png",
            });
            //masterPageItems.Add(new MasterPageItem
            //{
            //    Title = "Main",
            //    TargetType = typeof(Main)
            //});

            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() => {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Title");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
                    return imageCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };

            Padding = new Thickness(0, 40, 0, 0);
            Icon = "hamburger.png";
            Title = "Personal Organiser";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    listView
                }
            };
        }
	}
}
