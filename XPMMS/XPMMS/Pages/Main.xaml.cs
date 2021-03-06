﻿using System;
using System.Collections.Generic;
//using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using Android.Text.Style;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XPMMS.DAL;
using XPMMS.Models;
using XPMMS.Pages;

//TODO: Fix font sizes and spacing to fit all screens and platforms
//TODO: Add getData() method/class to handle check for existing team, etc, and set instance variables to be passed in each page case
//TODO: Remove all unnecessary data that gets moved around
//TODO: Detect if connection to web service is not available and inform user. App currently hangs >.> 
//TODO: Consider making all components on form global

namespace XPMMS
{
    public partial class Main : ContentPage
    {
        
        private UserModel _user;
        private TeamModel team;
        private ProjectModel project;
        private TaskModel[] tasks;
        private UserModel[] members;

        public Main()
        {
            InitializeComponent();
            
            var jsonUserData = WebService.GetUser(UserLogin.UserEmail);
            var users = JsonConvert.DeserializeObject<UserModel[]>(jsonUserData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _user = users[0];
            setPage();
        }

        private void setPage()
        {
            Label header = new Label
            {
                Text = "Project Management Made Easy\n!",
                TextColor = Color.White,
                FontSize = 25,
                MinimumHeightRequest = 0
            };

            Padding = new Thickness(10, Device.OnPlatform(5, 0, 0), 10, 0);

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

            // all icons are from http://www.flaticon.com and no ownership is claimed by this app

            Grid gridMenu = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            gridMenu.Children.Add(btnProfile, 0, 0);
            gridMenu.Children.Add(btnTeam, 0, 2);
            gridMenu.Children.Add(new Label { Text = "Profile", FontSize = 20, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center }, 0, 1);
            gridMenu.Children.Add(new Label { Text = "Team", FontSize = 20, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center }, 0, 3);

            gridMenu.Children.Add(btnProject, 0, 4);
            gridMenu.Children.Add(btnTasks, 0, 6);
            gridMenu.Children.Add(new Label { Text = "Project", FontSize = 20, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center }, 0, 5);
            gridMenu.Children.Add(new Label { Text = "Tasks", FontSize = 20, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center }, 0, 7);

            btnProfile.Clicked += BtnProfile_Clicked;
            btnTeam.Clicked += BtnTeam_Clicked;
            btnProject.Clicked += BtnProject_Clicked;
            btnTasks.Clicked += BtnTasks_Clicked;

            Label lbl = new Label {Text = ""}; // until I figure out how to add padding underneath headers correctly....

            Content = new StackLayout
            {
                Padding = new Thickness(10, Device.OnPlatform(2, 0, 0), 10, 0),
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
            var jsonUserData = WebService.GetUser(_user.Email);
            var user = JsonConvert.DeserializeObject<UserModel[]>(jsonUserData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _user = user[0];

            await Navigation.PushAsync(new Profile(_user));  
        }

        private async void BtnTeam_Clicked(object sender, EventArgs e)
        {
            var jsonUserData = WebService.GetUser(_user.Email);
            var user = JsonConvert.DeserializeObject<UserModel[]>(jsonUserData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _user = user[0];

            var jsonUsersData = WebService.GetUser(_user.Email);
            var _members = JsonConvert.DeserializeObject<UserModel[]>(jsonUsersData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            members = _members;

            var jsonTeamContent = WebService.GetTeam(Convert.ToString(_user.Team_ID));
            if (jsonTeamContent == "[]")
            {
                team = null;
                members = null;
                project = null;
                tasks = null;

                await Navigation.PushAsync(new AddTeam(_user, members, team, project, tasks));
            }
            else
            {
                var teamData = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                team = teamData[0];

                var jsonProjectData = WebService.GetTeamProjects(Convert.ToString(team.Team_Name));
                if (jsonProjectData == "[]")
                {
                    project = null;
                    tasks = null;
                }
                else
                {
                    var projectData = JsonConvert.DeserializeObject<ProjectModel[]>(jsonProjectData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    project = projectData[0];

                    var jsonTasksData = WebService.GetAllTasks();
                    if (jsonTasksData == null)
                    {
                        tasks = null;
                    }
                    else
                    {
                        tasks = JsonConvert.DeserializeObject<TaskModel[]>(jsonTasksData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                        List<TaskModel> taskList = new List<TaskModel>();

                        foreach (TaskModel task in tasks)
                        {
                            if (task.Project_ID == team.Proj_ID)
                                taskList.Add(task);
                        }
                        if (taskList.Count == 0)
                            tasks = null;
                        else tasks = taskList.ToArray();
                    }
                }

                var jsonMembersData = WebService.GetTeamMembers(Convert.ToString(team.Team_ID));
                if (jsonMembersData == "[]")
                {
                    members = null;
                }
                else members = JsonConvert.DeserializeObject<UserModel[]>(jsonMembersData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                await Navigation.PushAsync(new Team(_user, members, team, project, tasks), false); // test to see if no animation looks better
            }

        }

        private async void BtnProject_Clicked(object sender, EventArgs e)
        {
            var jsonUserData = WebService.GetUser(_user.Email);
            var user = JsonConvert.DeserializeObject<UserModel[]>(jsonUserData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _user = user[0];

            var jsonUsersData = WebService.GetUser(_user.Email);
            var _members = JsonConvert.DeserializeObject<UserModel[]>(jsonUsersData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            members = _members;

            var jsonTeamContent = WebService.GetTeam(Convert.ToString(_user.Team_ID));
            if (jsonTeamContent == "[]")
            {
                team = null;
                members = null;
                project = null;
                tasks = null;

                await Navigation.PushAsync(new AddTeam(_user, members, team, project, tasks));
            }
            else
            {
                var teamData = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamContent,
                    new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
                team = teamData[0];

                var jsonProjectData = WebService.GetTeamProjects(Convert.ToString(team.Team_Name));
                if (jsonProjectData == "[]")
                {
                    project = null;
                    tasks = null;
                    await Navigation.PushAsync(new AddProject(_user, members, team, project, tasks));
                }
                else
                {
                    var projectData = JsonConvert.DeserializeObject<ProjectModel[]>(jsonProjectData,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
                    project = projectData[0];

                    var jsonTasksData = WebService.GetAllTasks();
                    if (jsonTasksData == null)
                    {
                        tasks = null;
                    }
                    else
                    {
                        tasks = JsonConvert.DeserializeObject<TaskModel[]>(jsonTasksData,
                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

                        List<TaskModel> taskList = new List<TaskModel>();

                        foreach (TaskModel task in tasks)
                        {
                            if (task.Project_ID == team.Proj_ID)
                                taskList.Add(task);
                        }
                        if (taskList.Count == 0)
                            tasks = null;
                        else tasks = taskList.ToArray();
                    }


                    var jsonMembersData = WebService.GetTeamMembers(Convert.ToString(team.Team_ID));
                    if (jsonMembersData == "[]")
                    {
                        members = null;
                    }
                    else
                        members = JsonConvert.DeserializeObject<UserModel[]>(jsonMembersData,
                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

                    await Navigation.PushAsync(new Project(_user, members, team, project, tasks));
                }
            }
        }

        private async void BtnTasks_Clicked(object sender, EventArgs e)
        {
            var jsonUserData = WebService.GetUser(_user.Email);
            var user = JsonConvert.DeserializeObject<UserModel[]>(jsonUserData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _user = user[0];

            var jsonUsersData = WebService.GetUser(_user.Email);
            var _members = JsonConvert.DeserializeObject<UserModel[]>(jsonUsersData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            members = _members;

            var jsonTeamContent = WebService.GetTeam(Convert.ToString(_user.Team_ID));
            if (jsonTeamContent == "[]")
            {
                team = null;
                members = null;
                project = null;
                tasks = null;

                await Navigation.PushAsync(new AddTeam(_user, members, team, project, tasks));
            }
            else
            {
                var teamData = JsonConvert.DeserializeObject<TeamModel[]>(jsonTeamContent,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                team = teamData[0];

                var jsonProjectData = WebService.GetTeamProjects(Convert.ToString(team.Team_Name));
                if (jsonProjectData == "[]")
                {
                    project = null;
                    tasks = null;
                }
                else
                {
                    var projectData = JsonConvert.DeserializeObject<ProjectModel[]>(jsonProjectData,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    project = projectData[0];

                    var jsonTasksData = WebService.GetAllTasks();
                    if (jsonTasksData == null)
                    {
                        tasks = null;
                    }
                    else
                    {
                        tasks = JsonConvert.DeserializeObject<TaskModel[]>(jsonTasksData,
                            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                        List<TaskModel> taskList = new List<TaskModel>();

                        foreach (TaskModel task in tasks)
                        {
                            if (task.Project_ID == team.Proj_ID)
                                taskList.Add(task);
                        }
                        if (taskList.Count == 0)
                            tasks = null;
                        else tasks = taskList.ToArray();
                    }
                }

                var jsonMembersData = WebService.GetTeamMembers(Convert.ToString(team.Team_ID));
                if (jsonMembersData == "[]")
                {
                    members = null;
                }
                else
                    members = JsonConvert.DeserializeObject<UserModel[]>(jsonMembersData,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                await Navigation.PushAsync(new Tasks(_user, members, team, project, tasks));
            }
        }
    }
}
