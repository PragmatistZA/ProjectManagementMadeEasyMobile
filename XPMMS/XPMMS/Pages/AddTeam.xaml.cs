using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XPMMS.Models;

namespace XPMMS.Pages
{
	public partial class AddTeam : ContentPage
	{
        private UserModel _user;
        private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

        public AddTeam(UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
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

            Grid inputGrid = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            inputGrid.Children.Add(new Label { Text = "Team Name:" }, 0, 0);
            inputGrid.Children.Add(new Editor { Text = "John's Team" }, 1, 0);

            inputGrid.Children.Add(new Button { Text = "Register" }, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Join a Team", FontSize = 20 }, 0, 3);
            inputGrid.Children.Add(new Button { Text = "Teams" }, 1, 3);

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
