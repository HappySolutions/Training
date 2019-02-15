using SweetsDokkana.Models;
using System;
using System.Linq;
using SweetsDokkana.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Refit;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage ()
		{
			InitializeComponent ();
        }

        async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailEntry.Text) && string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Please complete all the feilds", "OK");
                return;
            }
            else
            {
                var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");

                var _customer = await apiResponce.GetCustomers();

                var userDetail = _customer.FirstOrDefault<Customer>(x => (x.Email == emailEntry.Text
                && x.Password == passwordEntry.Text));
                //T

                if (userDetail != null)
                {
                    var id = userDetail.id;
                    Settings.GeneralSettings = id.ToString();
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
                }
            }
            
        }

        private void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }

        private void BtnForgotPW_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}