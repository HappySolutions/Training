using SweetsDokkana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        SqlHelper sqlHelper = new SqlHelper();

		public LoginPage ()
		{
			InitializeComponent ();
		}
        async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            RegEntity userDetail = await sqlHelper.GetItem(emailEntry.Text, passwordEntry.Text);

            if (userDetail != null)
            {
                if (emailEntry.Text != userDetail.Email && passwordEntry.Text != userDetail.Password)
                {
                    await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
                }
                else
                {
                    await DisplayAlert("Registrtion", "Login Success ... Now Enjoy our Sweets Journy ", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
            }
            else
            {
                await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
            }

            //bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            //bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

        /*    if (isEmailEmpty || isPasswordEmpty)
            {
                DisplayAlert("Fail", "Please enter valid email and password", "Cancel");
            }
            else
            {
                Navigation.PushAsync(new MainPage());
            }*/

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