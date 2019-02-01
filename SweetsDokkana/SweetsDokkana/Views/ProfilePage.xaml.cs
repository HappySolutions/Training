using SQLite;
using SweetsDokkana.Helpers;
using SweetsDokkana.Models;
using SweetsDokkana.Presistance;
using System;
using System.Linq;
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
        public int _id =int.Parse(Settings.GeneralSettings);

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
            await _connectToEntity.CreateTableAsync<RegEntity>();

            var regEntity = await _connectToEntity.getbyId(_id);

            var usename = regEntity.UserName;
            var mail = regEntity.Email;
            var address = regEntity.Address;
            var phone = regEntity.Phone;

            lblEmail.Text = mail;
            lblName.Text = usename;
            lblPhone.Text = phone;
            lblAddress.Text = address;
        }

        private async void BtnProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilePage());
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