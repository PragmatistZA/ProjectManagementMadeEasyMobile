using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using XPMMS.DAL;
using XPMMS.Models;
using XPMMS.Validation.Behaviours;

namespace XPMMS.Pages
{
	public partial class AddProject : ContentPage
	{
        private UserModel _user;
        private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

	    private Entry editProjectName;
	    private Entry editProjectDesc;

	    private TextValidatorBehaviour textValidatorProjectName;
	    private TextValidatorBehaviour textValidatorProjectDesc;

        public AddProject(UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
        {
            InitializeComponent();

            _user = user;
            _members = members;
            _team = team;
            _project = project;
            _tasks = tasks;

            editProjectName = null;
            editProjectName = null;

            SetPage();
        }

        private void SetPage()
        {
            Label header = new Label
            {
                Text = "Create a new Project",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Button btnCreateProject = new Button
            {
                Text = "Create"
            };

            textValidatorProjectName = new TextValidatorBehaviour();
            textValidatorProjectDesc = new TextValidatorBehaviour();

            editProjectName = new Entry
            {
                Text = ""
            };
            editProjectName.Behaviors.Add(textValidatorProjectName);

            editProjectDesc = new Entry
            {
                Text = ""
            };
            editProjectName.Behaviors.Add(textValidatorProjectDesc);

            Grid inputGrid = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            inputGrid.Children.Add(new Label { Text = "Project Name:" }, 0, 0);
            inputGrid.Children.Add(editProjectName, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Project Description:" }, 0, 1);
            inputGrid.Children.Add(editProjectDesc, 1, 1);

            inputGrid.Children.Add(btnCreateProject, 1, 2);

            btnCreateProject.Clicked += BtnCreateProject_Clicked;

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    inputGrid
                }
            };
        }

        private async void BtnCreateProject_Clicked(object sender, EventArgs e)
        {
            string errors = "";
            bool errorFlag = false;

            if (editProjectName == null && !textValidatorProjectName.IsValid)
            {
                errors += Environment.NewLine + "Please fill out project name.";
                errorFlag = true;
            }
            else if (!textValidatorProjectName.IsValid)
            {
                errors += Environment.NewLine + "Please only use characters for project name.";
                errorFlag = true;
            }
            if (editProjectDesc == null && !textValidatorProjectDesc.IsValid)
            {
                errors += Environment.NewLine + "Please fill out project description.";
                errorFlag = true;
            }
            else if (!textValidatorProjectDesc.IsValid)
            {
                errors += Environment.NewLine + "Please only use characters for project description.";
                errorFlag = true;
            }
            if (errorFlag)
            {
                await DisplayAlert("Invalid Registration", "Invalid details:" + errors, "OK");
            }
            else
            {
                WebService.AddNewProject(Convert.ToString(_user.User_ID), Convert.ToString(_team.Team_ID), editProjectDesc.Text,
                editProjectName.Text);

                var jsonProjectData = WebService.GetTeamProjects(Convert.ToString(_team.Team_Name));
                var projectData = JsonConvert.DeserializeObject<ProjectModel[]>(jsonProjectData,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                _project = projectData[0];

                await Navigation.PushAsync(new Project(_user, _members, _team, _project, _tasks));
                Navigation.RemovePage(this);
            }
        }
    }
}
