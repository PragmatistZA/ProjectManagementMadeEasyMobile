﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static Xamarin.Forms.ImageSource;

namespace XPMMS
{
    public partial class Main : ContentPage
    {
        public Main()
        {
            InitializeComponent();
            setPage();
        }

        private void setPage()
        {
            Label header = new Label
            {
                Text = "Project Management Made Easy App!",
                TextColor = Color.White,
                FontSize = 25,
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

            Button btnProfile = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/profile.png"
            };

            Button btnTeam = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/team.png"
            };

            Button btnProject = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/project.png"
            };

            Button btnTasks = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/task.png"
            };

            Button btnContact = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/contact.png"
            };

            Button btnAbout = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/about.png"
            };

            Grid gridMenu = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            gridMenu.Children.Add(btnProfile, 0, 0);
            gridMenu.Children.Add(btnTeam, 1, 0);
            gridMenu.Children.Add(new Label { Text = "Profile", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 0, 1);
            gridMenu.Children.Add(new Label { Text = "Team", FontSize = 20 , HorizontalTextAlignment = TextAlignment.Center }, 1, 1);

            gridMenu.Children.Add(btnProject, 0, 2);
            gridMenu.Children.Add(btnTasks, 1, 2);
            gridMenu.Children.Add(new Label { Text = "Project", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 0, 3);
            gridMenu.Children.Add(new Label { Text = "Tasks", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 1, 3);

            gridMenu.Children.Add(btnContact, 0, 4);
            gridMenu.Children.Add(btnAbout, 1, 4);
            gridMenu.Children.Add(new Label { Text = "Contact Us", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 0, 5);
            gridMenu.Children.Add(new Label { Text = "About Us", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 1, 5);

            btnAbout.Clicked += BtnAbout_Clicked;

            Label lbl = new Label {Text = ""};

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    lbl,
                    lbl,
                    gridMenu
                }
            }; 
        }

        private static void BtnAbout_Clicked(object sender, EventArgs e)
        {
            ContentPage page = new ContentPage();

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

            page.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

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

            page.Content = new StackLayout
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
