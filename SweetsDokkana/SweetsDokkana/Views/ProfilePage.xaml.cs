using SQLite;
using SweetsDokkana.Models;
using SweetsDokkana.Presistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        IEntityController<RegEntity> _connectToEntity;

        private bool _isDataLoaded;
        public int id { get; set; }

        public ProfilePage ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connectToEntity = new EntityController<RegEntity>(_connection);

        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;
            await loadData();
           
            _isDataLoaded = false;

            base.OnAppearing();
        }

        async Task loadData()
        {
             _connectToEntity.CreateTableRegAsync();

            var regEntity = await _connection.Table<RegEntity>().ToListAsync();

            var test = regEntity.FirstOrDefault<RegEntity>() as RegEntity;

            id = test.ID;
            var usename = test.UserName;
            var mail = test.Email;
            var address = test.Address;
            var phone = test.Phone;

            lblEmail.Text = mail;
            lblName.Text = usename;
            lblPhone.Text = phone;
            lblAddress.Text = address;
        }

        private void BtnProfile_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditProfilePage(id));
        }

        private void BtnMyOrders_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyOrders());
        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        

        
    }
}