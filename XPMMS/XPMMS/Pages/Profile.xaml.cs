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
	public partial class Profile : ContentPage
	{
        private UserModel _user;

	    private Editor editTitle;
	    private Editor editFirstName;
        private Editor editLastName;
        private Editor editEmail;
        private Editor editContact;
        private Editor editJobDesc;


        public Profile(UserModel user)
        {
            InitializeComponent();

            _user = user;

            SetPage();
        }

        private void SetPage()
	    {
            Label header = new Label
            {
                Text = "Profile",
                TextColor = Color.White,
                FontSize = 20,
                MinimumHeightRequest = 0
            };

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Button btnApplyChanges = new Button
            {
                Text = "Save"
            };

            editTitle = new Editor
            {
                Text = _user.Title
            };

            editFirstName = new Editor
            {
                Text = _user.First_Name
            };

            editLastName = new Editor
            {
                Text = _user.Last_Name
            };

            editEmail = new Editor
            {
                Text = _user.Email
            };

            editContact = new Editor
            {
                Text = _user.Contact
            };

            editJobDesc = new Editor
            {
                Text = _user.Job_Desc
            };

            Grid inputGrid = new Grid
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            inputGrid.Children.Add(new Label { Text = "Title:" }, 0, 0);
            inputGrid.Children.Add(editTitle, 1, 0);
            inputGrid.Children.Add(new Label { Text = "First Name:" }, 0, 1);
            inputGrid.Children.Add(editFirstName, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Last Name:" }, 0, 2);
            inputGrid.Children.Add(editLastName, 1, 2);
            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 3);
            inputGrid.Children.Add(editEmail, 1, 3);
            inputGrid.Children.Add(new Label { Text = "Contact:" }, 0, 4);
            inputGrid.Children.Add(editContact, 1, 4);
            inputGrid.Children.Add(new Label { Text = "Job:" }, 0, 5);
            inputGrid.Children.Add(editJobDesc, 1, 5);
            inputGrid.Children.Add(btnApplyChanges, 1, 6);

            btnApplyChanges.Clicked += BtnApplyChanges_Clicked;

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    inputGrid
                }
            };
        }

        private void BtnApplyChanges_Clicked(object sender, EventArgs e)
        {
            WebService.EditUser(Convert.ToString(_user.User_ID), editTitle.Text, editFirstName.Text, editLastName.Text,
                editJobDesc.Text, editEmail.Text, editContact.Text);

            DisplayAlert("Success!", "Your details were changed.", "OK");

            var jsonUserData = WebService.GetUser(_user.Email);
            var user = JsonConvert.DeserializeObject<UserModel[]>(jsonUserData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _user = user[0];

            SetPage();
        }
    }
}
