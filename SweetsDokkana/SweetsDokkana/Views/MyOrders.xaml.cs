using Refit;
using SQLite;
using SweetsDokkana.Helpers;
using SweetsDokkana.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyOrders : ContentPage
	{
        public MyOrders ()
		{
			InitializeComponent ();
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
            var Orders = await apiResponce.GetOrders();
            OrderlistView.ItemsSource = Orders;
        }


        async void OnDelete(object sender, System.EventArgs e)
        {
            var message = await DisplayAlert("Warning", "Are you Sure you want to remove this item", "Yes", "No");
            if (message)
            {
                var item = (Order)((Button)sender).BindingContext;

                var id = item.Id;

                var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");
                await apiResponce.DeleteOrder(id, item);
                await DisplayAlert("Sucess", "Order has been removed from your orders history", "ok");
                await CallApi();

            }
        }

        async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushAsync(new MainPage());                
        }
    }
}