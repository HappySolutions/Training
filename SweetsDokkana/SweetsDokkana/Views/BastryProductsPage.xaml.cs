using SQLite;
using SweetsDokkana.Models;
using SweetsDokkana.Presistance;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BastryProductsPage : ContentPage
	{

        public BastryProductsPage ()
		{
			InitializeComponent ();

            SweetsList.ItemsSource = new List<Product>
            {
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=1080", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=999", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=995", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=835", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=889", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=882", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=824", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=772", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=755", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=674", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=493", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=488", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=429", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=431", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=360", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=326", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=312", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=306", discreption = "It is a long establish fact that a reader will.", price = 15}
            };
        }

        //function for item tapped in the list view
        async void SweetsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var itemT = e.Item as Product;
            // To unselect the tapped item
            SweetsList.SelectedItem = null;

            await Navigation.PushAsync(new ProductDetailPage(itemT));

        }

        // Function for search bar
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SweetsList.ItemsSource = e.NewTextValue;
        }

        //Function for pull to refresh
        private void listView_Refreshing(object sender, EventArgs e)
        {
            List<Product> itemList = new List<Product>
            {
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=1080", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=999", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=995", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=835", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=889", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=882", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=824", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=772", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=755", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=674", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=493", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=488", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=429", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=431", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=360", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=326", discreption = "It is a long establish fact that a reader will.", price = 15},
                new Product {name = "Lorem", image_link ="https://picsum.photos/200/300?image=312", discreption = "It is a long establish fact that a reader will.", price = 12},
                new Product {name = "Ibsom", image_link = "https://picsum.photos/200/300?image=306", discreption = "It is a long establish fact that a reader will.", price = 15}
            };

            SweetsList.ItemsSource = itemList;

            //then we use this function to end the refreshing loading
            SweetsList.EndRefresh();
        }

    }
}