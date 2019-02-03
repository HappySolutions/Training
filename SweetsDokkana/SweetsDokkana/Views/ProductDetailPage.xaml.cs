using Rg.Plugins.Popup.Services;
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
    public partial class ProductDetailPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        IEntityController<CartOrder> _connectToEntity;

        public ProductDetailPage(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();


            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connectToEntity = new EntityController<CartOrder>(_connection);

            BindingContext = new Product
            {
                name = product.name,
                discreption = product.discreption,
                image_link = product.image_link,
                price = product.price
            };
        }

        async void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (quantity.SelectedItem != null)
            {
                var cartOrder = new CartOrder();
                cartOrder.ProdName = lblName.Text;
                cartOrder.ProdDescreption = lbldscrption.Text;
                cartOrder.ProdPrice = double.Parse(lblPrice.Text);
                cartOrder.SelectedQuantity = double.Parse(quantity.SelectedItem.ToString());
                cartOrder.SumPrice = cartOrder.ProdPrice * cartOrder.SelectedQuantity;

                await _connection.CreateTableAsync<CartOrder>();
            
                int rows = await _connectToEntity.Insert(cartOrder);

                if (rows > 0)
                    await DisplayAlert("Success", "Order succesfully Added", "Ok");
                else
                    await DisplayAlert("Failure", "Order failed to be Added", "Ok");
                await Navigation.PopAsync();
            }

            else await DisplayAlert("Failure", "Please Select Quantity first", "Ok");

        }

        private async void Btnclient_Clicked(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            await PopupNavigation.PushAsync(new RatePopupPage());
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
