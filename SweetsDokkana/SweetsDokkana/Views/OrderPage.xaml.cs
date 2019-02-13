using Refit;
using SQLite;
using SweetsDokkana.Helpers;
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
	public partial class OrderPage : ContentPage
	{

        public OrderPage ()
		{
			InitializeComponent ();
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

                /*await _connection.CreateTableAsync<Order>();

                int rows = await _connection.InsertAsync(Order);
                if (rows > 0)
                    await DisplayAlert("Success", "Order Data succesfully Added", "Ok");
                else
                    await DisplayAlert("Failure", "Order failed to be Added", "Ok");
                await Navigation.PopAsync();*/
            }
                  
        }
    }
}