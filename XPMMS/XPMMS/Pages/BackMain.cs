using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XPMMS.Pages
{
	public class BackMain : MasterDetailPage
	{
        private HamburgerMenuMasterPage logoutMenu;

        public BackMain ()
		{
            logoutMenu = new HamburgerMenuMasterPage();
            Master = logoutMenu;
            Detail = new NavigationPage(new Main());
            logoutMenu.ListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if (item.Title != "Log Out")
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    logoutMenu.ListView.SelectedItem = null;
                    IsPresented = false;
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new Login());
                }
            }
        }

    }
}
