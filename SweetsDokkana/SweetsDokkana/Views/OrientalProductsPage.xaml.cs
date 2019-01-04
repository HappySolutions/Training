using Newtonsoft.Json;
using SweetsDokkana.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrientalProductsPage : ContentPage
	{
        //private const string Url = "http://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline";
       // private HttpClient _client = new HttpClient();
        //private ObservableCollection<Product> _products;

        public OrientalProductsPage ()
		{
			InitializeComponent ();

            SweetsList.ItemsSource = new List<Product>
            {
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=1080", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=999", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=995", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=835", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=889", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=882", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=824", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=772", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=755", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=674", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=493", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=488", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=429", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=431", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=360", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=326", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=312", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=306", discreption = "It is a long established fact that a reader will.", price = 15}
            };
        }
        /*protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            _products = new ObservableCollection<Product>(products);

            booksListView.ItemsSource = _products;

            base.OnAppearing();
        }*/

        private void listView_Refreshing(object sender, EventArgs e)
        {
            SweetsList.ItemsSource = new List<Product>
            {
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=1080", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=999", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=995", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=835", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=889", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=882", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=824", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=772", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=755", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=674", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=493", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=488", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=429", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=431", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=360", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=326", discreption = "It is a long established fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=312", discreption = "It is a long established fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=306", discreption = "It is a long established fact that a reader will.", price = 15}
            };
            //then we use this function to end the refreshing loading
            SweetsList.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SweetsList.ItemsSource = e.NewTextValue;
        }

        private void AddToCart_Clicked(object sender, EventArgs e)
        {

        }

        private void SweetsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        /*async void OnAdd(object sender, System.EventArgs e)
        {
            var product = new Product { name = "name " };
            _products.Insert(0, product);


            var content = JsonConvert.SerializeObject(product);

            await _client.PostAsync(Url, new StringContent(content));
        }*/

        /*async void OnDelete(object sender, System.EventArgs e)
        {
            var product = _products[0];
            _products.Remove(product);

            await _client.DeleteAsync(Url + "/" + product.Id);

        }*/
    }
}