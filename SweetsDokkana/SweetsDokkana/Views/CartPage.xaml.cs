using Newtonsoft.Json;
using SQLite;
using SweetsDokkana.Models;
using SweetsDokkana.Presistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        /*class Item
        {
            public string Name { get; set; }
            public string Discreption { get; set; }
            public string ImageUrl { get; set; }
        }*/

        public CartPage ()
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            
        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            await LoadData();

            base.OnAppearing();
        }

        private async Task LoadData()
        {
            await _connection.CreateTableAsync<CartOrder>();

            var cartOrder = await _connection.Table<CartOrder>().ToListAsync();

            _cartOrder = new ObservableCollection<CartOrder>(cartOrder);

            listView.ItemsSource = _cartOrder;
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var cartOrder = _cartOrder[0];
            await _connection.DeleteAsync(cartOrder);

            _cartOrder.Remove(cartOrder);
        }
        /*
       async void OnUpdate(object sender, System.EventArgs e)
       {
           var recipe = _recipes[0];
           recipe.Name += "Updated";
           await _connection.UpdateAsync(recipe);
       }*/
    }
}