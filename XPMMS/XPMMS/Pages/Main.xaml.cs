﻿using System;
using System.Collections.Generic;
//using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XPMMS.DAL;
using XPMMS.Models;
using XPMMS.Pages;
using static Xamarin.Forms.ImageSource;

//TODO: Fix font sizes and spacing to fit all screens and platforms

namespace XPMMS
{
    public partial class Main : ContentPage
    {
        private readonly UserModel _loggedInUser;
        public Main()
        {
            InitializeComponent();

            // hard coded user login data
            var jsonUserData = WebService.GetUser("sheldor@gmail.com");
            var users = JsonConvert.DeserializeObject<UserModel[]>(jsonUserData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _loggedInUser = users[0];
            setPage();
        }

        private void setPage()
        {
            Label header = new Label
            {
                Text = "Project Management Made Easy App!",
                TextColor = Color.White,
                FontSize = 25,
                MinimumHeightRequest = 0
            };

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Button btnProfile = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/profile.png"
            };

            Button btnTeam = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/team.png"
            };

            Button btnProject = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/project.png"
            };

            Button btnTasks = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/task.png"
            };

            Button btnContact = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/contact.png"
            };

            Button btnAbout = new Button
            {
                BackgroundColor = Color.White,
                Image = "@drawable/about.png"
            };

            Grid gridMenu = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            gridMenu.Children.Add(btnProfile, 0, 0);
            gridMenu.Children.Add(btnTeam, 1, 0);
            gridMenu.Children.Add(new Label { Text = "Profile", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 0, 1);
            gridMenu.Children.Add(new Label { Text = "Team", FontSize = 20 , HorizontalTextAlignment = TextAlignment.Center }, 1, 1);

            gridMenu.Children.Add(btnProject, 0, 2);
            gridMenu.Children.Add(btnTasks, 1, 2);
            gridMenu.Children.Add(new Label { Text = "Project", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 0, 3);
            gridMenu.Children.Add(new Label { Text = "Tasks", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 1, 3);

            gridMenu.Children.Add(btnContact, 0, 4);
            gridMenu.Children.Add(btnAbout, 1, 4);
            gridMenu.Children.Add(new Label { Text = "Contact Us", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 0, 5);
            gridMenu.Children.Add(new Label { Text = "About Us", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center }, 1, 5);

            btnProfile.Clicked += BtnProfile_Clicked;
            btnTeam.Clicked += BtnTeam_Clicked;
            btnProject.Clicked += BtnProject_Clicked;
            btnTasks.Clicked += BtnTasks_Clicked;
            btnContact.Clicked += BtnContact_Clicked;
            btnAbout.Clicked += BtnAbout_Clicked;

            Label lbl = new Label {Text = ""}; // until I figure out how to add padding underneath headers correctly....

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    lbl,
                    lbl,
                    gridMenu
                }
            }; 
        }

        private async void BtnProfile_Clicked(object sender, EventArgs e)
        {
            var jsonTeamContent = WebService.GetTeam(Convert.ToString(_loggedInUser.Team_ID));
            var teamData = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            TeamModel team = teamData[0];

            var jsonProjectData = WebService.GetTeamProjects(Convert.ToString(team.Team_Name));
            var projectData = JsonConvert.DeserializeObject<ProjectModel[]>(jsonProjectData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            ProjectModel project = projectData[0];

            var jsonTasksData = WebService.GetAllTasks();
            var tasks = JsonConvert.DeserializeObject<TaskModel[]>(jsonTasksData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            List<TaskModel> taskList = new List<TaskModel>();

            foreach (var task in tasks)
            {
                if (task.Project_ID == team.Proj_ID)
                    taskList.Add(task);
            }
            tasks = taskList.ToArray();


            var jsonMembersData = WebService.GetTeamMembers(Convert.ToString(team.Team_ID));
            var members = JsonConvert.DeserializeObject<UserModel[]>(jsonMembersData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            await Navigation.PushAsync(new Profile(_loggedInUser, members, team, project, tasks));
        }

        private async void BtnTeam_Clicked(object sender, EventArgs e)
        {   
            var jsonTeamContent = WebService.GetTeam(Convert.ToString(_loggedInUser.Team_ID));
            var teamData = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            TeamModel team = teamData[0];

            var jsonProjectData = WebService.GetTeamProjects(Convert.ToString(team.Team_Name));
            var projectData = JsonConvert.DeserializeObject<ProjectModel[]>(jsonProjectData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            ProjectModel project = projectData[0];

            var jsonTasksData = WebService.GetAllTasks();
            var tasks = JsonConvert.DeserializeObject<TaskModel[]>(jsonTasksData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            List<TaskModel> taskList = new List<TaskModel>();

            foreach (var task in tasks)
            {
                if (task.Project_ID == team.Proj_ID)
                    taskList.Add(task);
            }
            tasks = taskList.ToArray();


            var jsonMembersData = WebService.GetTeamMembers(Convert.ToString(team.Team_ID));
            var members = JsonConvert.DeserializeObject<UserModel[]>(jsonMembersData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            await Navigation.PushAsync(new Team(_loggedInUser, members, team, project, tasks));
        }

        private async void BtnProject_Clicked(object sender, EventArgs e)
        {
            var jsonTeamContent = WebService.GetTeam(Convert.ToString(_loggedInUser.Team_ID));
            var teamData = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            TeamModel team = teamData[0];

            var jsonProjectData = WebService.GetTeamProjects(Convert.ToString(team.Team_Name));
            var projectData = JsonConvert.DeserializeObject<ProjectModel[]>(jsonProjectData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            ProjectModel project = projectData[0];

            var jsonTasksData = WebService.GetAllTasks();
            var tasks = JsonConvert.DeserializeObject<TaskModel[]>(jsonTasksData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            List<TaskModel> taskList = new List<TaskModel>();

            foreach (var task in tasks)
            {
                if (task.Project_ID == team.Proj_ID)
                    taskList.Add(task);
            }
            tasks = taskList.ToArray();


            var jsonMembersData = WebService.GetTeamMembers(Convert.ToString(team.Team_ID));
            var members = JsonConvert.DeserializeObject<UserModel[]>(jsonMembersData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            await Navigation.PushAsync(new Project(_loggedInUser, members, team, project, tasks));
        }

        private async void BtnTasks_Clicked(object sender, EventArgs e)
        {
            var jsonTeamContent = WebService.GetTeam(Convert.ToString(_loggedInUser.Team_ID));
            var teamData = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            TeamModel team = teamData[0];

            var jsonProjectData = WebService.GetTeamProjects(Convert.ToString(team.Team_Name));
            var projectData = JsonConvert.DeserializeObject<ProjectModel[]>(jsonProjectData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            ProjectModel project = projectData[0];

            var jsonTasksData = WebService.GetAllTasks();
            var tasks = JsonConvert.DeserializeObject<TaskModel[]>(jsonTasksData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            List<TaskModel> taskList = new List<TaskModel>();

            foreach (var task in tasks)
            {
                if (task.Project_ID == team.Proj_ID)
                    taskList.Add(task);
            }
            tasks = taskList.ToArray();


            var jsonMembersData = WebService.GetTeamMembers(Convert.ToString(team.Team_ID));
            var members = JsonConvert.DeserializeObject<UserModel[]>(jsonMembersData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            await Navigation.PushAsync(new Tasks(_loggedInUser, members, team, project, tasks));
        }

        private async void BtnContact_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contact());
        }

        private async void BtnAbout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }
    }
}
