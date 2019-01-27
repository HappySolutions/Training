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

        public SignUpPage ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            var RegEntity = new RegEntity();
            RegEntity.UserName = lblUsername.Text;
            RegEntity.Password = lblPassword.Text;
            RegEntity.Email = lblMail.Text;
            RegEntity.Phone = lblPhone.Text;
            RegEntity.Address = lblAddress.Text;

            await _connection.CreateTableAsync<RegEntity>();

            int rows = await _connection.InsertAsync(RegEntity);
            if (rows != 0)
                await DisplayAlert("Success", "You have been regiesterd succesfully please Login Using your Data...", "Ok");
            else
                await DisplayAlert("Failure", "Register Failed", "Ok");
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