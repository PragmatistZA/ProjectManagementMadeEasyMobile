using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static pmmeWS;

using Xamarin.Forms;

namespace XPMMS
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new View();

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
