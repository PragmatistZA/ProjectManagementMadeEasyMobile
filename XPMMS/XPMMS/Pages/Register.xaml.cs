﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XPMMS.DAL;
namespace XPMMS.Pages
{
    public partial class Register : ContentPage
    {
        private Button _btnRegister;
        private Editor _userName;
        private Editor _userSurname;
        private Editor _userEmail;
        private Entry _userPassword;
        private Entry _userConfirmPassword;
        public Register()
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
                Text = "Register",
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
            _btnRegister = new Button { Text = "Register" };
            _userName = new Editor { Text = "John" };
            _userSurname = new Editor { Text = "Doe" };
            _userEmail = new Editor { Text = "john@gmail.com" };
            _userPassword = new Entry { Text = "Password", IsPassword = true };
            _userConfirmPassword = new Entry { Text = "Password", IsPassword = true };
            _btnRegister.Clicked += BtnRegister_Clicked;
            inputGrid.Children.Add(new Label { Text = "First Name:" }, 0, 0);
            inputGrid.Children.Add(_userName, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Last Name:" }, 0, 1);
            inputGrid.Children.Add(_userSurname, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 2);
            inputGrid.Children.Add(_userEmail, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Password:" }, 0, 3);
            inputGrid.Children.Add(_userPassword, 1, 3);
            inputGrid.Children.Add(new Label { Text = "Confirm password:" }, 0, 4);
            inputGrid.Children.Add(_userConfirmPassword, 1, 4);
            inputGrid.Children.Add(_btnRegister, 1, 5);
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
        public async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            if (_userPassword.Text == _userConfirmPassword.Text)
            {
                WebService.AddNewUser(_userName.Text, _userSurname.Text, _userEmail.Text, _userPassword.Text);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alert", "Passwords don't match", "OK");
            }

        }
    }
}