﻿using System;
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
	public partial class AddTask : ContentPage
	{
        private UserModel _user;
        private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

        private Editor editTaskDesc;
        private Editor editTimeReq;
        private Editor editDueBy;

        public AddTask(UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
        {
            InitializeComponent();

            _user = user;
            _members = members;
            _team = team;
            _project = project;
            _tasks = tasks;

            editTaskDesc = null;
            editTimeReq = null;
            editDueBy = null;

            SetPage();
        }

	    private void SetPage()
	    {
            Label header = new Label
            {
                Text = "Add a new Task",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

	        Button btnCreateTask = new Button
	        {
                Text = "Create"
	        };

	        editTaskDesc = new Editor
	        {
	            Text = ""
	        };

	        editTimeReq = new Editor
	        {
	            Text = ""
	        };

	        editDueBy = new Editor
	        {
	            Text = ""
	        };

            Grid inputGrid = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            inputGrid.Children.Add(new Label { Text = "Task Description:" }, 0, 0);
            inputGrid.Children.Add(editTaskDesc, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Hours Required:" }, 0, 1);
            inputGrid.Children.Add(editTimeReq, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Due By:" }, 0, 2);
            inputGrid.Children.Add(editDueBy, 1, 2);

            inputGrid.Children.Add(btnCreateTask, 1, 3);

	        btnCreateTask.Clicked += BtnCreateTask_Clicked;

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    inputGrid
                }
            };
        }

        private async void BtnCreateTask_Clicked(object sender, EventArgs e)
        {
            WebService.AddTask(Convert.ToString(_project.Proj_ID), editTaskDesc.Text, editTimeReq.Text, DateTime.Today.ToString("yyyy-MM-dd"), editDueBy.Text);

            var jsonTasksData = WebService.GetAllTasks();
            _tasks = JsonConvert.DeserializeObject<TaskModel[]>(jsonTasksData, 
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            List<TaskModel> taskList = new List<TaskModel>();

            foreach (TaskModel task in _tasks)
            {
                if (task.Project_ID == _team.Proj_ID)
                    taskList.Add(task);
            }
            if (taskList.Count == 0)
                _tasks = null;
            else _tasks = taskList.ToArray();

            await Navigation.PushAsync(new Tasks(_user, _members, _team, _project, _tasks));
            Navigation.RemovePage(this);
        }
    }
}