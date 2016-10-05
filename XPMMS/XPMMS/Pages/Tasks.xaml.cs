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
	public partial class Tasks : ContentPage
	{
        private UserModel _user;
        private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

        public Tasks(UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
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
                Text = "Tasks",
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

            int count = 0;
            foreach (TaskModel task in _tasks)
            {
                if (_project.Proj_ID != task.Project_ID) continue;
                inputGrid.Children.Add(new Label { Text = "Task Description:" }, 0, count);
                inputGrid.Children.Add(new Label { Text = task.Task_Desc }, 1, count);
                inputGrid.Children.Add(new Label { Text = "Hours Required:" }, 0, count + 1);
                inputGrid.Children.Add(new Label { Text = Convert.ToString(task.Time_Req) }, 1, count + 1);
                inputGrid.Children.Add(new Label { Text = "Date Created:" }, 0, count + 2);
                inputGrid.Children.Add(new Label { Text = Convert.ToString(task.Task_Created, CultureInfo.CurrentCulture) }, 1, count + 2);
                inputGrid.Children.Add(new Label { Text = "Date Due By:" }, 0, count + 3);
                inputGrid.Children.Add(new Label { Text = Convert.ToString(task.Task_Due, CultureInfo.CurrentCulture) }, 1, count + 3);
                inputGrid.Children.Add(new Button { Text = "Delete" }, 1, count + 4);
                count += 5;
            }

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
