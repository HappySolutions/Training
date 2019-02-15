using Refit;
using SweetsDokkana.Helpers;
using SweetsDokkana.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SweetsDokkana.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditProfilePage : ContentPage
	{
        public string _id = Settings.GeneralSettings;

        public EditProfilePage ()
		{
			InitializeComponent ();
        }

        async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            var Updatedreg = new Customer();
            Updatedreg.id = _id;
            Updatedreg.UserName = lblUsername.Text;
            Updatedreg.Password = lblPassword.Text;
            Updatedreg.Email = lblMail.Text;
            Updatedreg.Address = lblAddress.Text;
            Updatedreg.Phone = lblPhone.Text;

            if (string.IsNullOrWhiteSpace(Updatedreg.UserName) && string.IsNullOrWhiteSpace(Updatedreg.Password) 
                && string.IsNullOrWhiteSpace(Updatedreg.Email) && string.IsNullOrWhiteSpace(Updatedreg.Address)
                && string.IsNullOrWhiteSpace(Updatedreg.Phone))
            {
                await DisplayAlert("Error", "Please complete all the feilds", "OK");
                return;
            }

            var apiResponce = RestService.For<ISweetDokkanaApi>("https://safe-garden-92092.herokuapp.com");
            var responce = await apiResponce.UpdateCustomers(_id, Updatedreg);
            await DisplayAlert("Sucess", "Your Profile is updated successfuly", "ok");
            await Navigation.PopAsync();
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}