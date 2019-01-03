﻿using Newtonsoft.Json;
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
	public partial class SweetProductsPage : ContentPage
	{
        private const string Url = "http://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Product> _products;

        public SweetProductsPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            _products = new ObservableCollection<Product>(products);

            booksListView.ItemsSource = _products;

            base.OnAppearing();
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            booksListView.ItemsSource = _products;
            //then we use this function to end the refreshing loading
            booksListView.EndRefresh();
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            booksListView.ItemsSource = e.NewTextValue;
        }
        async void OnAdd(object sender, System.EventArgs e)
        {
            var product = new Product { name = "name " };
            _products.Insert(0, product);


            var content = JsonConvert.SerializeObject(product);

            await _client.PostAsync(Url, new StringContent(content));
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var product = _products[0];
            _products.Remove(product);

            await _client.DeleteAsync(Url + "/" + product.Id);

        }
    }
}