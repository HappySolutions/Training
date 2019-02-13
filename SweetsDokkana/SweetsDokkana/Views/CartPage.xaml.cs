using Refit;
using SQLite;
using SweetsDokkana.Helpers;
using SweetsDokkana.Models;
using SweetsDokkana.Presistance;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartPage : ContentPage
	{
        const string UrI = "https://safe-garden-92092.herokuapp.com/CartOrder/{0}";
        HttpClient clint = new HttpClient();

        public CartPage ()
		{
			InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CallApi();
            activity.IsEnabled = false;
            activity.IsRunning = false;
            activity.IsVisible = false;
        }

        async Task CallApi()
        {
            var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");
            var CartOrders = await apiResponce.GetCartOrders();
            OrderslistView.ItemsSource = CartOrders;

            double totalResult = CartOrders.Sum(item => item.SumPrice);
            total.Text = totalResult.ToString();
        }

        private async void listView_Refreshing(object sender, EventArgs e)
        {
            await CallApi();
            
            //then we use this function to end the refreshing loading
            OrderslistView.EndRefresh();
        }

        
        async void OnDelete(object sender, System.EventArgs e)
        {
            var message = await DisplayAlert("Warning", "Are you Sure you want to remove this item", "Yes", "No");
            if (message)
            {
                var item = (CartOrder)((Button)sender).BindingContext;

                var id = item.Id;
                var uri = new Uri(string.Format(UrI, id));
                var responce = await clint.DeleteAsync(uri);
                if (responce.IsSuccessStatusCode)
                {
                    await DisplayAlert("Sucess", "Item has been removed from your shopping cart", "ok");
                    await CallApi();

                }
            }
        }

        async void btnCheck_Clicked(object sender, EventArgs e)
        {

            var TotalSum = total.Text;
            await Navigation.PushAsync(new OrderPage(TotalSum));
        }             
    }
}