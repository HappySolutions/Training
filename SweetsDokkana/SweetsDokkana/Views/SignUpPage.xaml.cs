using System;
using SweetsDokkana.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Refit;
using SweetsDokkana.Helpers;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{

        public SignUpPage ()
		{
			InitializeComponent ();

        }

        async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            var Reg = new Customer();
            Reg.UserName = lblUsername.Text;
            Reg.Password = lblPassword.Text;
            Reg.Email = lblMail.Text;
            Reg.Phone = lblPhone.Text;
            Reg.Address = lblAddress.Text;


            if (string.IsNullOrWhiteSpace(Reg.UserName) && string.IsNullOrWhiteSpace(Reg.Password)
                && string.IsNullOrWhiteSpace(Reg.Email) && string.IsNullOrWhiteSpace(Reg.Phone)
                && string.IsNullOrWhiteSpace(Reg.Address))
            {
                await DisplayAlert("Error", "Please complete all the feilds", "OK");
                return;
            }
            else
            {
                var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");

                var _customer = await apiResponce.AddCustomer(Reg);

                await DisplayAlert("Sucess", "Account registerd. Please Sign in..", "OK");
                await Navigation.PushAsync(new LoginPage());
            }
        }

        private void BtnForgotPW_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }

        private void Btnclient_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}