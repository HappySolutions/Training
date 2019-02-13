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
        const string UrI = "https://safe-garden-92092.herokuapp.com/Order/{0}";
        HttpClient clint = new HttpClient();

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
                var uri = new Uri(string.Format(UrI, id));
                var responce = await clint.DeleteAsync(uri);
                if (responce.IsSuccessStatusCode)
                {
                    await DisplayAlert("Sucess", "Item has been removed from your shopping cart", "ok");
                    await CallApi();

                }
            }
        }

        async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
           
                await DisplayAlert("Success", "Your Orders Have Been Submitted", "OK");

                await Navigation.PushAsync(new MainPage());
            
            

            
        }
    }
}