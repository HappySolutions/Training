using SQLite;
using SweetsDokkana.Models;
using SweetsDokkana.Presistance;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartPage : ContentPage
	{

        private SQLiteAsyncConnection _connection;
        private ObservableCollection<CartOrder> _cartOrder;
        private bool _isDataLoaded;
        string result;
        IEntityController<CartOrder> _connectToEntity;


        public CartPage ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connectToEntity = new EntityController<CartOrder>(_connection);

        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            await LoadData();

            base.OnAppearing();
            
        }

        private async Task LoadData()
        {
            try
            {

                await _connection.CreateTableAsync<CartOrder>();

                var cartOrder = await _connection.Table<CartOrder>().ToListAsync();

                _cartOrder = new ObservableCollection<CartOrder>(cartOrder);

                listView.ItemsSource = _cartOrder;

                var ent = await _connection.ExecuteScalarAsync<double>("SELECT SUM(SumPrice) FROM CartOrders");
                result = ent.ToString();
                total.Text = result;
                _isDataLoaded = false;

            }
            catch (Exception)
            {
                await DisplayAlert("Fail", "Your Cart is empty Please Add Some Products", "OK");
            }
            
        }

        private async void listView_Refreshing(object sender, EventArgs e)
        {

            listView.ItemsSource = _cartOrder;
            var ent = await _connection.ExecuteScalarAsync<double>("SELECT SUM(SumPrice) FROM CartOrders");
            var result = ent.ToString();
            total.Text = result;

            //then we use this function to end the refreshing loading
            listView.EndRefresh();
        }

        
        async void OnDelete(object sender, System.EventArgs e)
        {
            var item = (CartOrder)((Button)sender).BindingContext;

            await _connection.DeleteAsync(item);

            _cartOrder.Remove(item);
            try
            { 
            var ent = await _connection.ExecuteScalarAsync<double>("SELECT SUM(SumPrice) FROM CartOrders");
            var result = ent.ToString();
            total.Text = result;
            }
            catch (Exception)
            {
                total.Text = "0";
                await DisplayAlert("Fail", "Your Cart is empty Please Add Some Products", "OK");
            }
        }

        async void btnCheck_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ent = await _connection.ExecuteScalarAsync<double>("SELECT SUM(SumPrice) FROM CartOrders");
                var result = ent.ToString();
                total.Text = result;
                await Navigation.PushAsync(new OrderPage(result));

            }
            catch (Exception)
            {
                total.Text = "0";
                await DisplayAlert("Fail", "Your Cart is empty Please Add Some Products", "OK");
            }

        }             
    }
}