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
	public partial class OrderPage : ContentPage
	{

        private SQLiteAsyncConnection _connection;
        private string result;

        public OrderPage (string result)
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            this.result = result;
            total.Text = result;
        }

        async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            var Order = new Order();
            Order.OrderPrice = total.Text;
            Order.Name = NameEntry.Text;
            Order.Address1 = AddressEntry1.Text;
            Order.Address2 = AddressEntry2.Text;
            Order.City = lblCity.Text;
            Order.Phone = Phone.Text;
            Order.Payment = lblPayment.Text;


             await _connection.CreateTableAsync<Order>();

            int rows = await _connection.InsertAsync(Order);
            if (rows > 0)
                await DisplayAlert("Success", "Order Data succesfully Added", "Ok");
            else
                await DisplayAlert("Failure", "Order failed to be Added", "Ok");
            await Navigation.PopAsync();
        }
    }
}