using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using XPMMS.DAL;
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

	    private Editor editTeamName;

        public AddTeam(UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
        {
            InitializeComponent();

            _user = user;
            _members = members;
            _team = team;
            _project = project;
            _tasks = tasks;

            editTeamName = null;

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

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Button btnRegisterTeam = new Button
            {
                Text = "Register"
            };

            Button btnJoinTeam = new Button
            {
                Text = "Teams"
            };

            editTeamName = new Editor
            {
                Text = ""
            };

            Grid inputGrid = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            inputGrid.Children.Add(new Label { Text = "Team Name:" }, 0, 0);
            inputGrid.Children.Add(editTeamName, 1, 0);

            inputGrid.Children.Add(btnRegisterTeam, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Join a Team", FontSize = 20 }, 0, 3);
            inputGrid.Children.Add(btnJoinTeam, 1, 3);

            btnJoinTeam.Clicked += BtnJoinTeam_Clicked;
            btnRegisterTeam.Clicked += BtnRegisterTeam_Clicked;

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    inputGrid
                }
            };
        }

        private async void BtnRegisterTeam_Clicked(object sender, EventArgs e)
        {

            WebService.UserAddNewTeam(_user.Email, editTeamName.Text);

            var jsonUserData = WebService.GetUser(_user.Email);
            var users = JsonConvert.DeserializeObject<UserModel[]>(jsonUserData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _user = users[0];

            var jsonTeamContent = WebService.GetTeam(Convert.ToString(_user.Team_ID));
            var teamData = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            TeamModel team = teamData[0];
            _team = team;

            await Navigation.PushAsync(new Team(_user, _members, _team, _project, _tasks));
        }

        private async void BtnJoinTeam_Clicked(object sender, EventArgs e)
        {
            var jsonTeamListContent = WebService.GetAllTeams();
            var teams = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamListContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            await Navigation.PushAsync(new ListTeams(teams, _user, _members, _team, _project, _tasks));
        }
    }
}
