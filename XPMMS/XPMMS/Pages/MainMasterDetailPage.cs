using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XPMMS.Models;

namespace XPMMS.Pages
{
	public class BackMain : MasterDetailPage
	{

        /// <summary>
        /// This page is the page on which both Main and the Logout hamburger menu resides.
        /// </summary>
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
                if (item.Title == "Log Out")
                {
                    App.Current.MainPage = new NavigationPage(new Login());
                }
                else if (item.Title == "About Us")
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    logoutMenu.ListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "Contact Us")
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    logoutMenu.ListView.SelectedItem = null;
                    IsPresented = false;
                }
                else
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    logoutMenu.ListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }

    }
}
