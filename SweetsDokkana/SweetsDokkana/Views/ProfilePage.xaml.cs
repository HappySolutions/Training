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
        private bool _isDataLoaded;


        public ProfilePage ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

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
            await _connection.CreateTableAsync<RegEntity>();

            var regEntity = await _connection.Table<RegEntity>().ToListAsync();

            var test = regEntity.FirstOrDefault<RegEntity>() as RegEntity;
            
            var usename = test.UserName;
            var mail = test.Email;
            var address = test.Address;
            var phone = test.Phone;
            lblEmail.Text = mail;
            lblName.Text = usename;
            lblPhone.Text = phone;
            lblAddress.Text = address;
        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void BtnMyOrders_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyOrders());
        }

        private void BtnProfile_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditProfilePage());
        }
    }
}