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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
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
    }
}