using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XPMMS.Models;

namespace XPMMS.Pages
{
	public partial class Project : ContentPage
	{
        private UserModel _user;
        private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

        public Project(UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
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

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Grid inputGrid = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            string manager = null;
            foreach (UserModel user in _members)
            {
                if (_project.Proj_Manager_ID == user.User_ID)
                    manager = user.First_Name + " " + user.Last_Name;
            }

            inputGrid.Children.Add(new Label { Text = "Project Name:" }, 0, 0);
            inputGrid.Children.Add(new Label { Text = _project.Project_Name }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Project Description:" }, 0, 1);
            inputGrid.Children.Add(new Label { Text = _project.Proj_Desc }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Project Due Date:" }, 0, 2);
            inputGrid.Children.Add(new Label { Text = Convert.ToString(_project.Proj_Due, CultureInfo.CurrentCulture) }, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Project Manager:" }, 0, 3);
            inputGrid.Children.Add(new Label { Text = manager }, 1, 3);

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
