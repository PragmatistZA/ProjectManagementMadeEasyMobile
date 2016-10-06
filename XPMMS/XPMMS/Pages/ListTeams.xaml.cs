using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XPMMS.DAL;
using XPMMS.Models;
using ArrayList = System.Collections.ArrayList;

namespace XPMMS.Pages
{
	public partial class ListTeams : ContentPage
	{
        private UserModel _user;
        private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

	    private List<Button> teamButtons;
	    private List<Label> teamNameLabels;

        private TeamModel[] _teams;

        public ListTeams(TeamModel[] teams, UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
        {
            InitializeComponent();

            _teams = teams;

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
                Text = "List of Existing Teams",
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

            teamButtons = new List<Button>();
            teamNameLabels = new List<Label>();

            int count = 0;
            foreach (TeamModel team in _teams)
            {
                Label label = new Label {Text = team.Team_Name};
                Button button = new Button();
                button.Clicked += BtnJoinTeam_Clicked;
                button.Text = "Join";
                inputGrid.Children.Add(label, 0, count);
                teamNameLabels.Add(label);
                inputGrid.Children.Add(button, 1, count);
                teamButtons.Add(button);
                count ++;
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

        private async void BtnJoinTeam_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int teamNameIndex = teamButtons.IndexOf(button);

            WebService.AddUserToTeam(_user.Email, teamNameLabels[teamNameIndex].Text);

            await Navigation.PopAsync();
            await Navigation.PopAsync();
            await Navigation.PushAsync(new Team(_user, _members, _team, _project, _tasks));
        }
    }
}
