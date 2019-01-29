using SweetsDokkana.Models;
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
        SqlHelper sqlHelper = new SqlHelper();

        public ForgotPasswordPage ()
		{
			InitializeComponent ();
		}

        private async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            RegEntity userDetail = await sqlHelper.CheckMail(mailEntry.Text);

            if(userDetail == null)
            {
                await DisplayAlert("Wrong Email", "This email is not registered", "OK");
            }
            
            else
            {
                await DisplayAlert("Done", "Recover Password Email Has Been Sent", "OK");
                await Navigation.PushAsync(new LoginPage());
            }

        }
    }
}