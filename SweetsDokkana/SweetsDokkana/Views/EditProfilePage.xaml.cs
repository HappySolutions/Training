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
	public partial class EditProfilePage : ContentPage
	{
        SQLiteAsyncConnection _connection;
        IEntityController<RegEntity> _connectToEntity;
        public int _id;

        public EditProfilePage (int id)
		{
            this._id = id;
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connectToEntity = new EntityController<RegEntity>(_connection);

            BindingContext = new RegEntity()
            {
                UserName = lblUsername.Text,
                Address = lblAddress.Text,
                Password = lblPassword.Text,
                Phone = lblPhone.Text,
                Email = lblMail.Text
            };

        }

        async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            var Updatedreg = await  _connectToEntity.getbyId(_id);
            Updatedreg.UserName = lblUsername.Text;
            Updatedreg.Password = lblPassword.Text;
            Updatedreg.Email = lblMail.Text;
            Updatedreg.Address = lblAddress.Text;

            if (string.IsNullOrWhiteSpace(Updatedreg.UserName))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            await _connectToEntity.Update(Updatedreg);
            await Navigation.PopAsync();

        }
    }
}