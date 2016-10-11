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
using XPMMS.Validation.Behaviors;
using XPMMS.Validation.Behaviours;

namespace XPMMS.Pages
{
	public partial class AddTask : ContentPage
	{
        private UserModel _user;
        private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

        private Entry editTaskDesc;
        private Entry editTimeReq;
        private DatePicker editDueBy;

	    private NumberValidatorBehavior numberValidator;
	    private TextValidatorBehaviour textValidator;

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

	        numberValidator = new NumberValidatorBehavior();
	        textValidator = new TextValidatorBehaviour();

	        Button btnCreateTask = new Button
	        {
                Text = "Create"
	        };

	        editTaskDesc = new Entry
	        {
	            Text = ""
	        };
            editTaskDesc.Behaviors.Add(textValidator);

	        editTimeReq = new Entry
	        {
	            Text = ""
	        };
            editTimeReq.Behaviors.Add(numberValidator);

	        editDueBy = new DatePicker
	        {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand
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
            string errors = "";
            bool errorFlag = false;

            if (editTaskDesc.Text == "")
            {
                errors += Environment.NewLine + "Please fill out task description.";
                errorFlag = true;
            }
            else if (!textValidator.IsValid)
            {
                errors += Environment.NewLine + "Please only use characters in task description.";
                errorFlag = true;
            }
            if (editTimeReq.Text == "")
            {
                errors += Environment.NewLine + "Please fill out amount of hours needed for task.";
                errorFlag = true;
            }
            else if (!numberValidator.IsValid)
            {
                errors += Environment.NewLine + "Please only use numbers for hours needed for task.";
                errorFlag = true;
            }
            if (errorFlag)
            {
                await DisplayAlert("Invalid Registration", "Invalid details:" + errors, "OK");
            }
            else
            {
                WebService.AddTask(Convert.ToString(_project.Proj_ID), editTaskDesc.Text, editTimeReq.Text, DateTime.Today.ToString("yyyy-MM-dd"), editDueBy.Date.ToString("yyyy-MM-dd"));

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
}
