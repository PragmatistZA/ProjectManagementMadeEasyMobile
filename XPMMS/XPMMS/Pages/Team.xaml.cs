using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using XPMMS.Models;

namespace XPMMS.Pages
{
	public partial class Team : ContentPage
	{
	    private UserModel _user;
	    private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

        public Team (UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
		{
			InitializeComponent ();

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
                Text = "My Team",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };

            //Label headerDescription = new Label
            //{
            //    Text = "Join an existing Team",
            //    TextColor = Color.White,
            //    FontSize = 20,

            //    MinimumHeightRequest = 0
            //};
	        string leader = null;
	        for (int i = 0; i < _members.Length; i++)
	        {
	            if (_team.Team_Leader == _members[i].User_ID)
	                leader = _members[i].First_Name + " " + _members[i].Last_Name;
	        }

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Grid inputGrid = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            inputGrid.Children.Add(new Label { Text = "Team Name:" }, 0, 0);
            inputGrid.Children.Add(new Label { Text = _team.Team_Name }, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Team Leader:" }, 0, 1);
            inputGrid.Children.Add(new Label { Text =  leader}, 1, 1);
	        int count = 2;
            foreach (var user in _members)
	        {
	            if (user.User_ID != _team.Team_Leader)
	            {

                    inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, count);
	                inputGrid.Children.Add(new Label {Text = user.First_Name + " " + user.Last_Name}, 1, count);
	                count++;
	            }
            }

            //inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, 2);
            //inputGrid.Children.Add(new Label { Text = "James Young" }, 1, 2);
            //inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, 3);
            //inputGrid.Children.Add(new Label { Text = "Rica Page" }, 1, 3);
            //inputGrid.Children.Add(new Label { Text = "Member Name:" }, 0, 4);
            //inputGrid.Children.Add(new Label { Text = "David O'Reilly" }, 1, 4);


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
