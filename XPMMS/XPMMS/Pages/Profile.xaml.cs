using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XPMMS.Models;

namespace XPMMS.Pages
{
	public partial class Profile : ContentPage
	{
        private UserModel _user;
        private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

        public Profile(UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
        {
            InitializeComponent();

            _user = user;
            _members = members;
            _team = team;
            _project = project;
            _tasks = tasks;

            SetPage();
        }

        private void SetPage()
	    {
            Label header = new Label
            {
                Text = "Profile",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Grid inputGrid = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            inputGrid.Children.Add(new Label { Text = "Title:" }, 0, 0);
            inputGrid.Children.Add(new Editor { Text = _user.Title }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "First Name:" }, 0, 1);
            inputGrid.Children.Add(new Editor { Text =_user.First_Name }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Last Name:" }, 0, 2);
            inputGrid.Children.Add(new Editor { Text = _user.Last_Name }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 3);
            inputGrid.Children.Add(new Editor { Text = _user.Email }, 1, 3);
            inputGrid.Children.Add(new Label { Text = "Password:" }, 0, 4);
            inputGrid.Children.Add(new Editor { Text = "" }, 1, 4);
            inputGrid.Children.Add(new Label { Text = "Contact:" }, 0, 5);
            inputGrid.Children.Add(new Editor { Text = _user.Contact }, 1, 5);
            inputGrid.Children.Add(new Label { Text = "Job:" }, 0, 6);
            inputGrid.Children.Add(new Editor { Text = _user.Job_Desc }, 1, 6);
            inputGrid.Children.Add(new Button { Text = "Save" }, 1, 7);

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    inputGrid
                }
            };
        }
	}
}
