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
        private ObservableCollection<CartOrder> _Cartorder;


        public ProductDetailPage(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            BindingContext = product;

            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


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
            var cartOrder = new CartOrder();
            cartOrder.ProdName = lblName.Text;
            //cartOrder.ProdPrice = float.Parse (lbldscrption.Text);
            //cartOrder.ProdImage = proImg.Source.ToString();
        

            await _connection.CreateTableAsync<CartOrder>();

            int rows = await _connection.InsertAsync(cartOrder);
            if (rows > 0)
                await DisplayAlert("Success", "Experience succesfully inserter", "Ok");
            else
                await DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
            await Navigation.PopAsync();

        }


    }
}
