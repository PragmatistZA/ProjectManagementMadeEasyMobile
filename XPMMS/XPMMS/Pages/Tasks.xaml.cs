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
using Button = Xamarin.Forms.Button;

namespace XPMMS.Pages
{
	public partial class Tasks : ContentPage
	{
        private UserModel _user;
        private UserModel[] _members;
        private TeamModel _team;
        private ProjectModel _project;
        private TaskModel[] _tasks;

	    private List<Button> deleteButtons;
	    private List<TaskModel> currentTasks;

        public Tasks(UserModel user, UserModel[] members, TeamModel team, ProjectModel project, TaskModel[] tasks)
        {
            InitializeComponent();

            _user = user;
            _members = members;
            _team = team;
            _project = project;
            _tasks = tasks;

            currentTasks = null;

            SetPage();
        }

        private void SetPage()
	    {
            Label header = new Label
            {
                Text = "Tasks",
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

            deleteButtons = new List<Button>();
            currentTasks = new List<TaskModel>();

            if (_tasks != null)
            {
                 int count = 0;
                 foreach (TaskModel task in _tasks)
                 {
                    if (_project.Proj_ID != task.Project_ID) continue;

                    Button btnDelete = new Button { Text = "Delete"};
                    btnDelete.Clicked += BtnDeleteOnClicked;
                    inputGrid.Children.Add(new Label { Text = "Task Description:" }, 0, count);
                    inputGrid.Children.Add(new Label { Text = task.Task_Desc }, 1, count);
                    inputGrid.Children.Add(new Label { Text = "Hours Required:" }, 0, count + 1);
                    inputGrid.Children.Add(new Label { Text = Convert.ToString(task.Time_Req) }, 1, count + 1);
                    inputGrid.Children.Add(new Label { Text = "Date Created:" }, 0, count + 2);
                    inputGrid.Children.Add(new Label { Text = task.Task_Created.ToString("yyyy-MM-dd") }, 1, count + 2);
                    inputGrid.Children.Add(new Label { Text = "Date Due By:" }, 0, count + 3);
                    inputGrid.Children.Add(new Label { Text = task.Task_Due.ToString("yyyy-MM-dd") }, 1, count + 3);
                    inputGrid.Children.Add(btnDelete, 1, count + 4);
                    deleteButtons.Add(btnDelete);
                    currentTasks.Add(task);
                    count += 5;
                 }
            }

            Button btnAddTask = new Button
            {
                Text = "Add New Task"
            };

            btnAddTask.Clicked += BtnAddTask_Clicked;

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    inputGrid,
                    btnAddTask
                }
            };
        }

	    private void BtnDeleteOnClicked(object sender, EventArgs eventArgs)
	    {
	        Button button = sender as Button;
            int deleteButtonIndex = deleteButtons.IndexOf(button);

	        WebService.DeleteTask(Convert.ToString(currentTasks[deleteButtonIndex].Task_ID));

            DisplayAlert("Success!", "Task was deleted.", "OK");

            var jsonTasksData = WebService.GetAllTasks();
            if (jsonTasksData == null)
            {
                _tasks = null;
            }
            else
            {
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
            }

            SetPage();
        }

	    private async void BtnAddTask_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new AddTask(_user, _members, _team, _project, 
                _tasks), false);
            Navigation.RemovePage(this);
        }
    }
}
