using Refit;
using SQLite;
using SweetsDokkana.Helpers;
using SweetsDokkana.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderPage : ContentPage
	{

        public OrderPage (string totalSum)
		{
			InitializeComponent ();
            total.Text = totalSum;
        }

        async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            var Order = new Order();
            Order.OrderPrice = total.Text;
            Order.Name = NameEntry.Text;
            Order.Address = Address.Text;
            Order.City = lblCity.Text;
            Order.Phone = Phone.Text;
            Order.Payment = lblPayment.Text;



            if (string.IsNullOrWhiteSpace(Order.Name)
                    && string.IsNullOrWhiteSpace(Order.Address) 
                    && string.IsNullOrWhiteSpace(Order.City) && string.IsNullOrWhiteSpace(Order.Phone) && string.IsNullOrWhiteSpace(Order.Payment))
            {
                await DisplayAlert("Error", "Please complete all the feilds", "OK");
                return;
            }
            else
            {
                var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");

                var _cartOrder = await apiResponce.AddOrder(Order);
                var answer = await DisplayAlert("Sucess", "Order is added to your Orders Page. Do you want to go back to go to it?", "Yes", "No");
                if (answer)
                {
                    await Navigation.PushAsync(new MyOrders());
                }
                else
                {
                    await Navigation.PopAsync();
                }
            }
                  
        }
    }
}