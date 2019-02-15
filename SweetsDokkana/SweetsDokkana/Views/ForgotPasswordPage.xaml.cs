using Refit;
using SweetsDokkana.Helpers;
using SweetsDokkana.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPasswordPage : ContentPage
	{
        public ForgotPasswordPage ()
		{
			InitializeComponent ();
        }

        private async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mailEntry.Text))
            {
                await DisplayAlert("Error", "Please Enter the Email", "OK");
                return;
            }
            else
            {
                var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");

                var _customer = await apiResponce.GetCustomers();

                var userDetail = _customer.FirstOrDefault<Customer>(x => (x.Email == mailEntry.Text));

                if (userDetail != null)
                {
                    await DisplayAlert("Success", "An Email to recover your password has been sent", "OK");
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    var message = await DisplayAlert("Fail", "This email is not registered.. Do you want to sign up ","Yes","No");
                    if (message)
                    {
                       await Navigation.PushAsync(new SignUpPage());
                    }
                }
            }

        }
    }
}