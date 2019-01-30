using SQLite;
using SweetsDokkana.Models;
using SweetsDokkana.Presistance;
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
	public partial class ForgotPasswordPage : ContentPage
	{
        SQLiteAsyncConnection _connection;
        IEntityController<RegEntity> _connectToEntity;

        public ForgotPasswordPage ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connectToEntity = new EntityController<RegEntity>(_connection);

        }

        private async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            RegEntity userDetail = await _connectToEntity.CheckMail(mailEntry.Text);

            if(userDetail == null)
            {
                await DisplayAlert("Wrong Email", "This email is not registered", "OK");
            }
            
            else
            {
                await DisplayAlert("Done", "Recover Password Email Has Been Sent", "OK");
                await Navigation.PushAsync(new LoginPage());
            }

        }
    }
}