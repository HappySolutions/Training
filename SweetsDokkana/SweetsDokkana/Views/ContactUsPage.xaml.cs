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
	public partial class ContactUsPage : ContentPage
	{
		public ContactUsPage ()
		{
			InitializeComponent ();
		}

        private void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) && string.IsNullOrWhiteSpace(EmailEntry.Text)
                && string.IsNullOrWhiteSpace(MessageEntry.Text))

                DisplayAlert("Fail", "Please complete All Feilds", "OK");
            else
                DisplayAlert("Sent", "Your Message Has been sent", "OK");

        }
    }
}