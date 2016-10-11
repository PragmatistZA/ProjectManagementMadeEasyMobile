using System;
using System.Collections.Generic;
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
    public partial class Register : ContentPage
    {
        public EventHandler RegisterSucceeded;

        private Button _btnRegister;
        private Entry _userName;
        private Entry _userSurname;
        private Entry _userEmail;
        private Entry _userPassword;
        private Entry _userConfirmPassword;

        private TextValidatorBehaviour textValidatorFirstName;
        private TextValidatorBehaviour textValidatorLastName;
        private EmailValidatorBehavior emailValidator;
        private PasswordValidatorBehavior passwordValidator;

        public Register()
        {
            InitializeComponent();
            SetPage();
        }

        private void SetPage()
        {
            Label header = new Label
            {
                Text = "Register",
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

            emailValidator = new EmailValidatorBehavior();
            passwordValidator = new PasswordValidatorBehavior();
            textValidatorFirstName = new TextValidatorBehaviour();
            textValidatorLastName = new TextValidatorBehaviour();

            _btnRegister = new Button { Text = "Register" };
            _userName = new Entry { Text = "" };
            _userName.Behaviors.Add(textValidatorFirstName);
            _userSurname = new Entry { Text = "" };
            _userName.Behaviors.Add(textValidatorLastName);
            _userEmail = new Entry { Text = "" };
            _userEmail.Behaviors.Add(emailValidator);
            _userPassword = new Entry { Text = "", IsPassword = true };
            _userPassword.Behaviors.Add(passwordValidator);
            _userConfirmPassword = new Entry { Text = "", IsPassword = true };
            _btnRegister.Clicked += BtnRegister_Clicked;

            inputGrid.Children.Add(new Label { Text = "First Name:" }, 0, 0);
            inputGrid.Children.Add(_userName, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Last Name:" }, 0, 1);
            inputGrid.Children.Add(_userSurname, 1, 1);
            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 2);
            inputGrid.Children.Add(_userEmail, 1, 2);
            //inputGrid.Children.Add(new Label { Text = emailValidator.IsValid ? "Email is valid" : "Enter a valid email" }, 1, 3);
            inputGrid.Children.Add(new Label { Text = "Password:" }, 0, 3);
            inputGrid.Children.Add(_userPassword, 1, 3);
            //inputGrid.Children.Add(new Label { Text = passwordValidator.IsValid ? "Password is valid" : "Enter a valid password" }, 1, 5);
            inputGrid.Children.Add(new Label { Text = "Confirm password:" }, 0, 4);
            inputGrid.Children.Add(_userConfirmPassword, 1, 4);
            inputGrid.Children.Add(_btnRegister, 1, 5);

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    inputGrid
                }
            };
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            string errors = "";
            bool errorFlag = false;
            if (_userPassword.Text == "")
            {
                errors += Environment.NewLine + "Please fill out password.";
                errorFlag = true;
            }
            else if (_userPassword.Text != _userConfirmPassword.Text)
            {
                errors += Environment.NewLine + "Passwords do not match.";
                errorFlag = true;
            }
            if (_userConfirmPassword.Text == "")
            {
                errors += Environment.NewLine + "Please confirm password.";
                errorFlag = true;
            }
            if (!passwordValidator.IsValid)
            {
                errors += Environment.NewLine + "Password must contain uppercase, lowercase, a special character, and be at least 8 characters in length.";
                errorFlag = true;
            }
            if (_userEmail.Text == "")
            {
                errors += Environment.NewLine + "Please fill out email.";
                errorFlag = true;
            }
            else if (!emailValidator.IsValid)
            {
                errors += Environment.NewLine + "Please use an existing email address.";
                errorFlag = true;
            }
            else
            {
                bool emailExistsFlag = false;

                var jsonAllUsers = WebService.GetAllUsers();
                var allUsers = JsonConvert.DeserializeObject<UserModel[]>(jsonAllUsers, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                if (jsonAllUsers != "[]")
                {
                    foreach (var itemUser in allUsers)
                    {
                        if (itemUser.Email == _userEmail.Text)
                        {
                            emailExistsFlag = true;
                        }
                    }
                    if (emailExistsFlag)
                    {
                        errors += Environment.NewLine + "Email address is already linked to an existing account.";
                        errorFlag = true;
                    }
                }
            }
            if (_userName.Text == "")
            {
                errors += Environment.NewLine + "Please fill out first name.";
                errorFlag = true;
            }
            else if (!textValidatorFirstName.IsValid)
            {
                errors += Environment.NewLine + "Please only use characters for first name.";
                errorFlag = true;
            }
            if (_userSurname.Text == "")
            {
                errors += Environment.NewLine + "Please fill out last name.";
                errorFlag = true;
            }
            else if (!textValidatorLastName.IsValid)
            {
                errors += Environment.NewLine + "Please only use characters for last name.";
                errorFlag = true;
            }
            if (!errorFlag)
            {
                WebService.AddNewUser(_userName.Text, _userSurname.Text, _userEmail.Text, _userPassword.Text);
                OnRegisterSucceeded();
                await Navigation.PopAsync();
                
            }
            else
            {
                await DisplayAlert("Invalid Registration", "Invalid details:" + errors, "OK");
            }

        }

        private void OnRegisterSucceeded()
        {
            RegisterSucceeded?.Invoke(this, new LoginStringEventArgs(_userEmail.Text + "-" + _userPassword.Text));
        }
    }
}