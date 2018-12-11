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
	public partial class ForgotPasswordPage : ContentPage
	{
		public ForgotPasswordPage ()
		{
			InitializeComponent ();
		}

        private async Task BtnSubmit_Clicked(object sender, EventArgs e)
        {
           await DisplayAlert("Done", "Recover Password Email Has Been Sent", "OK");
           await Navigation.PushAsync(new LoginPage());
        }
    }
}