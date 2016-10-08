﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XPMMS.DAL;
using XPMMS.Models;

using Xamarin.Forms;
using System;

namespace XPMMS.Pages
{
	public partial class Login : ContentPage
	{
        private Button _btnLogin;
        private Button _btnRegister;
        private Editor _userEmail;
        private Entry _userPassword;

        public Login()
        {
            InitializeComponent();
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
                Text = "Log in",
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

            _userEmail = new Editor { Text = "cool@gmail.com" };
            _userPassword = new Entry { Text = "Password", IsPassword = true };
            _btnLogin = new Button { Text = "Login" };
            _btnRegister = new Button { Text = "Register" };
            _btnLogin.Clicked += BtnLogin_Clicked;
            _btnRegister.Clicked += BtnRegister_Clicked;

            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 0);
            inputGrid.Children.Add(_userEmail, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Password:" }, 0, 1);
            inputGrid.Children.Add(_userPassword, 1, 1);
            inputGrid.Children.Add(_btnLogin, 1, 2);
            inputGrid.Children.Add(_btnRegister, 1, 3);

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

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var jsonResult = WebService.VerifyUserLogin(_userEmail.Text, _userPassword.Text);
            if (jsonResult != "Incorrect")
            {
                await DisplayAlert("Alert", jsonResult, "OK");
                UserLogin.UserEmail = _userEmail.Text;
                App.Current.MainPage = new NavigationPage(new Main());
            }
            else
            {
                await DisplayAlert("Alert", jsonResult, "OK");
            }

        }
        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}

