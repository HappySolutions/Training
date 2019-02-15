using Refit;
using SweetsDokkana.Helpers;
using SweetsDokkana.Models;
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
        private bool _isDataLoaded;
        public string _id =Settings.GeneralSettings;

        public ProfilePage ()
		{
			InitializeComponent ();
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
            var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");

            var _customer = await apiResponce.GetCustomers();

            var customerDetail = _customer.FirstOrDefault<Customer>(x => (x.id == _id));

            var mail = customerDetail.Email;
            var username = customerDetail.UserName;
            var phone = customerDetail.Phone;
            var address = customerDetail.Address;

            lblEmail.Text = mail;
            lblName.Text = username;
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