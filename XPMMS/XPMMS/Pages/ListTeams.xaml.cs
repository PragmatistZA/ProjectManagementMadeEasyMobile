using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

            var jsonUserData = WebService.GetUser(_user.Email);
            var user = JsonConvert.DeserializeObject<UserModel[]>(jsonUserData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _user = user[0];

            var jsonTeamContent = WebService.GetTeam(Convert.ToString(_user.Team_ID));
            var teamData = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _team = teamData[0];

            var jsonProjectData = WebService.GetTeamProjects(Convert.ToString(_team.Team_Name));
            if (jsonProjectData == "[]")
            {
                _project = null;
                _tasks = null;
            }
            else
            {
                var projectData = JsonConvert.DeserializeObject<ProjectModel[]>(jsonProjectData,
                    new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
                _project = projectData[0];

                var jsonTasksData = WebService.GetAllTasks();
                if (jsonTasksData == null)
                {
                    _tasks = null;
                }
                else
                {
                    _tasks = JsonConvert.DeserializeObject<TaskModel[]>(jsonTasksData,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

                    List<TaskModel> taskList = new List<TaskModel>();

                    foreach (TaskModel task in _tasks)
                    {
                        if (task.Project_ID == _team.Proj_ID)
                            taskList.Add(task);
                    }
                    if (taskList.Count == 0)
                        _tasks = null;
                    else _tasks = taskList.ToArray();
                }
            }
            var jsonMembersData = WebService.GetTeamMembers(Convert.ToString(_team.Team_ID));
            if (jsonMembersData == "[]")
            {
                _members = null;
            }
            else _members = JsonConvert.DeserializeObject<UserModel[]>(jsonMembersData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            await Navigation.PushAsync(new Team(_user, _members, _team, _project, _tasks));
            Navigation.RemovePage(this);
        }
    }
}
