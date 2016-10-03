using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementMadeEasyApp.Helpers;
using ProjectManagementMadeEasyApp.Models;
using Xamarin.Forms;
using XPMMS.DAL;
using Newtonsoft.Json;

namespace XPMMS
{
	public partial class View : ContentPage
	{
        public View ()
		{
			InitializeComponent ();
            hardCodedMainView();
            //hardCodedRegistrationView();
            //hardCodedLoginView();
            //hardCodedProfileView();
            //hardCodedAboutView();
            //hardCodedContactView();
            //hardCodedDashBoardView();
            //hardCodedMyTeamFalseView();
            //hardCodedTeamListView();
            //hardCodedMyTeamView();
            //hardCodedMyProjectView();
            //hardCodedMyTasksView();
            //hardCodedCreateProjectView();
            //hardCodedNoTasksView();
            //hardCodedAddTaskView();
            //PickerTest();
		}

        private void hardCodedAddTaskView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "Add a new Task",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "Join an existing Team",
                TextColor = Color.White,
                FontSize = 20,

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

            inputGrid.Children.Add(new Label { Text = "Task Description:" }, 0, 0);
            inputGrid.Children.Add(new Editor { Text = "John's First Task" }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Hours Required:" }, 0, 1);
            inputGrid.Children.Add(new Editor { Text = "8" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Due By:" }, 0, 2);
            inputGrid.Children.Add(new Editor { Text = "mm/dd/yyy" }, 1, 2);

            inputGrid.Children.Add(new Button { Text = "Create" }, 1, 3);


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

        private void hardCodedNoTasksView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "Tasks",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "Join an existing Team",
                TextColor = Color.White,
                FontSize = 20,

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

            inputGrid.Children.Add(new Button { Text = "Add New Task" }, 0, 0);


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

        private void hardCodedCreateProjectView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "Create a new Project",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "Join an existing Team",
                TextColor = Color.White,
                FontSize = 20,

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

            inputGrid.Children.Add(new Label { Text = "Project Name:" }, 0, 0);
            inputGrid.Children.Add(new Editor { Text = "John's Project." }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Project Description:" }, 0, 1);
            inputGrid.Children.Add(new Editor { Text = "John's first project." }, 1, 1);

            inputGrid.Children.Add(new Button { Text = "Create" }, 1, 2);


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

        private void hardCodedMyTasksView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "Tasks",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "Join an existing Team",
                TextColor = Color.White,
                FontSize = 20,

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

            inputGrid.Children.Add(new Label { Text = "Task Description:" }, 0, 0);
            inputGrid.Children.Add(new Label { Text = "MVC coding." }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Hours Required:" }, 0, 1);
            inputGrid.Children.Add(new Label { Text = "20" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Date Created:" }, 0, 2);
            inputGrid.Children.Add(new Label { Text = "16-08-2016" }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Date Due By:" }, 0, 3);
            inputGrid.Children.Add(new Label { Text = "20-09-2016" }, 1, 3);
            inputGrid.Children.Add(new Button { Text = "Delete" }, 1, 4);
            inputGrid.Children.Add(new Label { Text = "Task Description:" }, 0, 5);
            inputGrid.Children.Add(new Label { Text = "Web Service Consumption." }, 1, 5);
            inputGrid.Children.Add(new Label { Text = "Hours Required:" }, 0, 6);
            inputGrid.Children.Add(new Label { Text = "8" }, 1, 6);
            inputGrid.Children.Add(new Label { Text = "Date Created:" }, 0, 7);
            inputGrid.Children.Add(new Label { Text = "18-08-2016" }, 1, 7);
            inputGrid.Children.Add(new Label { Text = "Date Due By:" }, 0, 8);
            inputGrid.Children.Add(new Label { Text = "01-09-2016" }, 1, 8);
            inputGrid.Children.Add(new Button { Text = "Delete" }, 1, 9);
            inputGrid.Children.Add(new Button { Text = "Add New Task" }, 0, 10);


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

        private void hardCodedMyProjectView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "My Project",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "Join an existing Team",
                TextColor = Color.White,
                FontSize = 20,

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

            inputGrid.Children.Add(new Label { Text = "Project Name:" }, 0, 0);
            inputGrid.Children.Add(new Label { Text = "MVC PHP/MySQL" }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Project Description:" }, 0, 1);
            inputGrid.Children.Add(new Label { Text = "Set up entire architecture for web app and web service integration." }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Project Due Date:" }, 0, 2);
            inputGrid.Children.Add(new Label { Text = "29-08-2016" }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Project Manager:" }, 0, 3);
            inputGrid.Children.Add(new Label { Text = "John Doe" }, 1, 3);


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

        private void hardCodedMyTeamView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "My Team",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "Join an existing Team",
                TextColor = Color.White,
                FontSize = 20,

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

            inputGrid.Children.Add(new Label { Text = "Team Name:" }, 0, 0);
            inputGrid.Children.Add(new Label { Text = "Digital Anomaly" }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Team Leader:" }, 0, 1);
            inputGrid.Children.Add(new Label { Text = "John Doe" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, 2);
            inputGrid.Children.Add(new Label { Text = "James Young" }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, 3);
            inputGrid.Children.Add(new Label { Text = "Rica Page" }, 1, 3);
            inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, 4);
            inputGrid.Children.Add(new Label { Text = "David O'Reilly" }, 1, 4);


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

        private void hardCodedTeamListView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "List of Existing Teams",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "Join an existing Team",
                TextColor = Color.White,
                FontSize = 20,

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

            inputGrid.Children.Add(new Label { Text = "Science 'n Stuff" }, 0, 0);
            inputGrid.Children.Add(new Button { Text = "Join" }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "The Big Bang Theory" }, 0, 1);
            inputGrid.Children.Add(new Button { Text = "Join" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Greenday" }, 0, 2);
            inputGrid.Children.Add(new Button { Text = "Join" }, 1, 2);


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

        private void hardCodedMyTeamFalseView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "Create a Team",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "Join an existing Team",
                TextColor = Color.White,
                FontSize = 20,

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

            inputGrid.Children.Add(new Label { Text = "Team Name:" }, 0, 0);
            inputGrid.Children.Add(new Editor { Text = "John's Team" }, 1, 0);

            inputGrid.Children.Add(new Button { Text = "Register" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Join a Team" , FontSize = 20}, 0, 3);
            inputGrid.Children.Add(new Button { Text = "Teams" }, 1, 3);


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

        private void hardCodedDashBoardView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "Dashboard",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };
            Label header2 = new Label
            {
                Text = "You are not part of a team! Join a team or create your own.",
                TextColor = Color.White,
                FontSize = 15,
                MinimumHeightRequest = 0
            };
            Label headerDescription = new Label
            {
                Text = "You have no current projects.",
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
                "PMME",
                "My Team",
                "My Project",
                "My Tasks"
            };

            foreach (string navPage in navPages)
            {
                picker.Items.Add(navPage);
            }

            Content = new StackLayout
            {
                Children =
                {
                    picker,
                    header,
                    header2,
                    headerDescription
                }
            };
        }

        private void hardCodedContactView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

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




            Content = new StackLayout
            {
                Children =
                {
                    picker,
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

        private void hardCodedAboutView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

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




            Content = new StackLayout
            {
                Children =
                {
                    picker,
                    header,
                    headerDescription
                }
            };
        }

        private void hardCodedProfileView()
        {
            ToolbarItem btn1Item = new ToolbarItem
            {
                Text = "Test"
            };

            Label header = new Label
            {
                Text = "Profile",
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

            inputGrid.Children.Add(new Label { Text = "Title:" }, 0, 0);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "First Name:" }, 0, 1);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Last Name:" }, 0, 2);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 3);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 3);
            inputGrid.Children.Add(new Label { Text = "Password:" }, 0, 4);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 4);
            inputGrid.Children.Add(new Label { Text = "Contact:" }, 0, 5);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 5);
            inputGrid.Children.Add(new Label { Text = "Job:" }, 0, 6);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 6);
            inputGrid.Children.Add(new Button { Text = "Save" }, 1, 7);


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


        private void hardCodedLoginView()
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

            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 0);
            inputGrid.Children.Add(new Editor { Text = "john@gmail.com" }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Password:" }, 0, 1);
            inputGrid.Children.Add(new Editor { Text = "Password" }, 1, 1);
            inputGrid.Children.Add(new Button { Text = "Login" }, 1, 2);

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

        private void hardCodedRegistrationView()
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

            inputGrid.Children.Add(new Label { Text = "First Name:" }, 0, 0);
            inputGrid.Children.Add(new Editor { Text = "John" }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Last Name:" }, 0, 1);
            inputGrid.Children.Add(new Editor { Text = "Doe" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 2);
            inputGrid.Children.Add(new Editor { Text = "john@gmail.com" }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Password:" }, 0, 3);
            inputGrid.Children.Add(new Editor { Text = "Password" }, 1, 3);
            inputGrid.Children.Add(new Label { Text = "Confirm password:" }, 0, 4);
            inputGrid.Children.Add(new Editor { Text = "Password" }, 1, 4);
            inputGrid.Children.Add(new Button { Text = "Register" }, 1, 5);

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

	    private void PickerTest()
	    {
            // Dictionary to get Color from color name.
	        Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
	        {
	            {"Aqua", Color.Aqua},
	            {"Black", Color.Black},
	            {"Blue", Color.Blue},
	            {"Fuschia", Color.Fuschia},
	            {"Gray", Color.Gray},
	            {"Green", Color.Green},
	            {"Lime", Color.Lime},
	            {"Maroon", Color.Maroon},
	            {"Navy", Color.Navy},
	            {"Olive", Color.Olive},
	            {"Purple", Color.Purple},
	            {"Red", Color.Red},
	            {"Silver", Color.Silver},
	            {"Teal", Color.Teal},
	            {"White", Color.White},
	            {"Yellow", Color.Yellow}
	        };

            Label header = new Label
            {
                Text = "Picker",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Picker picker = new Picker
            {
                Title = "Color",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string colorName in nameToColor.Keys)
            {
                picker.Items.Add(colorName);
            }

            // Create BoxView for displaying picked Color
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    boxView.Color = Color.Default;
                }
                else
                {
                    string colorName = picker.Items[picker.SelectedIndex];
                    boxView.Color = nameToColor[colorName];
                }
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    picker,
                    boxView
                }
            };
        }

	    private void hardCodedMainView()
	    {
	        ToolbarItem btn1Item = new ToolbarItem
	        {
	            Text = "Test"
	        };

	        Label header = new Label
	        {
	            Text = "Welcome to Project Management Made Easy - Now On Mobile!",
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

            nav.Children.Add(new Button {Text = "XPMME"}, 0, 0);
            nav.Children.Add(new Button { Text = "DashBoard" }, 1, 0);
	        nav.Children.Add(new Button {Text = "About"}, 2, 0);
            nav.Children.Add(new Button { Text = "Contact" }, 3, 0);

	        string test = WebService.VerifyUserLogin("sheldor@gmail.com", SHA1.Encode("Password"));
            string test2 = WebService.AddNewUser("TestUser1", "TestUser1","testtest@gmail.com", SHA1.Encode("Password"));
            string test3 = WebService.GetUser("sheldor@gmail.com");

	        UserModel user = new UserModel();

	        var jsonContent = test3;
	        var users = JsonConvert.DeserializeObject<UserModel[]>(jsonContent,
	            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

            //var jsonContent = _ws.GetAllUsers();
            //var users = JsonConvert.DeserializeObject<UserModel[]>(jsonContent,
            //    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            //var userList = users.ToList();
            //return userList;

            Content = new StackLayout
            {
                Children =
                {
                    picker,
                    header,
                    headerDescription
                }
            };
        }
	}
}
