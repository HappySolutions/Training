﻿using SQLite;
using Newtonsoft.Json;

using SweetsDokkana.Models;
using SweetsDokkana.Presistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BastryProductsPage : ContentPage
	{
        private const string Url = "https://safe-garden-92092.herokuapp.com/Product";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Product> _products;

        public BastryProductsPage ()
		{
			InitializeComponent ();
        }
        
        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            _products = new ObservableCollection<Product>(products);

            SweetsList.ItemsSource = _products;
            base.OnAppearing();
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

            SweetsList.ItemsSource = _products;

            //then we use this function to end the refreshing loading
            SweetsList.EndRefresh();
        }

    }
}