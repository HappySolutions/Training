using Refit;
using SweetsDokkana.Helpers;
using SweetsDokkana.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SweetProductsPage : ContentPage
	{

        public SweetProductsPage ()
		{
			InitializeComponent ();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CallApi();

            activity.IsEnabled = false;
            activity.IsRunning = false;
            activity.IsVisible = false;
        }

        async Task CallApi()
        {
            var apiResponce = RestService.For<ISweetDokkanaApi>("https://sweetsdokk.herokuapp.com/api/Products");
            var Products = await apiResponce.GetWesternProducts();
            SweetsList.ItemsSource = Products;
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
        private async void listView_Refreshing(object sender, EventArgs e)
        {
            await CallApi();

            //then we use this function to end the refreshing loading
            SweetsList.EndRefresh();
        }

    }
}