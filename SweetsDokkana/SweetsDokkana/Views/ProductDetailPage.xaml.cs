using Refit;
using Rg.Plugins.Popup.Services;
using SweetsDokkana.Helpers;
using SweetsDokkana.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {

        public ProductDetailPage(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            InitializeComponent();

            BindingContext = new Product
            {
                Pro_Name = product.Pro_Name,
                Pro_Description = product.Pro_Description,
                Pro_IMG = product.Pro_IMG,
                Pro_Price = product.Pro_Price
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
 
                var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");

                var _cartOrder = await apiResponce.AddCartOrder(cartOrder);

              
                var answer = await DisplayAlert("Sucess", "Product is added to your cart. Do you want to go back to the product's list?", "Yes", "No");
                if (answer)
                {
                    await Navigation.PopAsync();
                }
                                   
             }
             else
             {
                   await DisplayAlert("Failure", "Please Select Quantity first", "Ok");
             }                                     
        }

        private async void Btnclient_Clicked(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            await PopupNavigation.PushAsync(new RatePopupPage());
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
