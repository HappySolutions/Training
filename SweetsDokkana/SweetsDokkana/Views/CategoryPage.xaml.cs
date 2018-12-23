using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryPage : ContentPage
	{
		public CategoryPage ()
		{
			InitializeComponent ();
		}

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchResultsPage());
        }

        private void btnOriental_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrientalProductsPage());
        }

        private void BtnSweets_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SweetProductsPage());
        }

        private void BtnCakes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CakeProductsPage());
        }

        private void BtnBastry_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BastryProductsPage());
        }
    }
}