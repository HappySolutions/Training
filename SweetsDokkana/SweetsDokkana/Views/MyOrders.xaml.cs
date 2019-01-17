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
	public partial class MyOrders : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Order> _myOrder;
        private bool _isDataLoaded = false;

        public MyOrders ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            await LoadData();

            base.OnAppearing();
        }

        public async Task LoadData()
        {
            await _connection.CreateTableAsync<Order>();

            var myOrder = await _connection.Table<Order>().ToListAsync();

            _myOrder = new ObservableCollection<Order>(myOrder);

            OrderlistView.ItemsSource = _myOrder;
            _isDataLoaded = true;

        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var myOrder = _myOrder[0];
            await _connection.DeleteAsync(myOrder);

            _myOrder.Remove(myOrder);

        }

        async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            if (_isDataLoaded)
                await DisplayAlert("Success", "Your Orders Have Been Saved", "OK");
            await Navigation.PushAsync(new MainPage());
        }
    }
}