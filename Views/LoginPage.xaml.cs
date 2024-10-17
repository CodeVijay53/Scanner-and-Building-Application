using HKLS_App.Services;
using HKLS_App.Views;
using Microsoft.Maui.Controls;
using System;


namespace HKLS_App.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthService _authService;

        public LoginPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            if (await _authService.LoginAsync(email, password))
            {
                await Navigation.PushAsync(new ProjectSelectionPage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid login credentials", "OK");
            }
        }

        private async void OnSignupClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage(_authService));
        }
    }
}
