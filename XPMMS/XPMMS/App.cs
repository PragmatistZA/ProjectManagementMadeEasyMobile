using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPMMS.Pages;

using Xamarin.Forms;

namespace XPMMS
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
            MainPage = new NavigationPage(new Login());
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
           // if(UserLogin.UserEmail != null)
                MainPage = new NavigationPage(new Main());
        }
	}
}
