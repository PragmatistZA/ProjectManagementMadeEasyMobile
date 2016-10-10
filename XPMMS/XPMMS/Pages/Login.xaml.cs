using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XPMMS.DAL;
using XPMMS.Models;

using Xamarin.Forms;
using System;

namespace XPMMS.Pages
{
	public partial class Login : ContentPage
	{
        private Button _btnLogin;
        private Button _btnRegister;
        private Editor _userEmail;
        private Entry _userPassword;

        public Login()
        {
            InitializeComponent();

            SetPage();
        }

        private void SetPage()
	    {
            Label header = new Label
            {
                Text = "Log in",
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

            _userEmail = new Editor { Text = "" };
            _userPassword = new Entry { Text = "", IsPassword = true };
            _btnLogin = new Button { Text = "Login" };
            _btnRegister = new Button { Text = "Register" };
            _btnLogin.Clicked += BtnLogin_Clicked;
            _btnRegister.Clicked += BtnRegister_Clicked;

            inputGrid.Children.Add(new Label { Text = "Email:" }, 0, 0);
            inputGrid.Children.Add(_userEmail, 1, 0);
            inputGrid.Children.Add(new Label { Text = "Password:" }, 0, 1);
            inputGrid.Children.Add(_userPassword, 1, 1);
            inputGrid.Children.Add(_btnLogin, 1, 2);
            inputGrid.Children.Add(_btnRegister, 1, 3);

            Content = new StackLayout
            {
                Children =
                {
                    header,
                    inputGrid
                }
            };
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var jsonResult = WebService.VerifyUserLogin(_userEmail.Text, _userPassword.Text);
            if (jsonResult == "Correct")
            {
                await DisplayAlert(jsonResult + "!", "Login Details Authenticated", "Continue");
                UserLogin.UserEmail = _userEmail.Text;
                App.Current.MainPage = new NavigationPage(new Main());
            }
            else
            {
                await DisplayAlert(jsonResult + "!", "Login Failed", "OK");
            }

        }
        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}

