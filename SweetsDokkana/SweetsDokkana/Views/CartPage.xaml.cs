using Newtonsoft.Json;
using SweetsDokkana.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartPage : ContentPage
	{
        class Item
        {
            public string Name { get; set; }
            public string Discreption { get; set; }
            public string ImageUrl { get; set; }
        }

        public CartPage ()
		{
			InitializeComponent ();

            listView.ItemsSource = new List<Item>
            {
                new Item { Name = "Cake", ImageUrl ="https://www.fillmurray.com/100/100", Discreption = "3 levels wedding cake"},
                new Item {Name = "Basbosa", ImageUrl = "http://lorempixel.com/100/100/people/8", Discreption = "Delesious and tasty basbosa"},
                new Item {Name = "Chocolate", ImageUrl = "http://lorempixel.com/100/100/people/7", Discreption = "Sweet chocolate tasty cake"}
            };
        }

       

    }
}