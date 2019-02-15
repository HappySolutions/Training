using Refit;
using SweetsDokkana.Helpers;
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
	public partial class ContactUsPage : ContentPage
	{
		public ContactUsPage ()
		{
			InitializeComponent ();
		}

        private async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) && string.IsNullOrWhiteSpace(EmailEntry.Text)
                && string.IsNullOrWhiteSpace(MessageEntry.Text))
            {
                await DisplayAlert("Fail", "Please complete All Feilds", "OK");
            }
            else
            {
                var contactMessage = new Contact();
                contactMessage.Name = NameEntry.Text;
                contactMessage.Mail = EmailEntry.Text;
                contactMessage.Message = MessageEntry.Text;

                var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");

                var _customer = await apiResponce.SendMessage(contactMessage);

                await DisplayAlert("Sent", "Your Message Has been sent", "OK");

            }

        }
    }
}