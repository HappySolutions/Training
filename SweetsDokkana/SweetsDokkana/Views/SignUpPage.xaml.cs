using SQLite;
using SweetsDokkana.Presistance;
using System;
using SweetsDokkana.Models;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        SqlHelper sqlHelper = new SqlHelper();

        public SignUpPage ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            var Reg = new RegEntity();
            Reg.UserName = lblUsername.Text;
            Reg.Password = lblPassword.Text;
            Reg.Email = lblMail.Text;
            Reg.Phone = lblPhone.Text;
            Reg.Address = lblAddress.Text;

            var regtest = await sqlHelper.InsertAsync<RegEntity>(Reg);
            if(regtest > 0)
            {
                await DisplayAlert("Success", "Account registerd", "OK");
            }
            else
            {
                await DisplayAlert("Success", "Account not registerd", "OK");
            }
            await Navigation.PushAsync(new LoginPage());
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