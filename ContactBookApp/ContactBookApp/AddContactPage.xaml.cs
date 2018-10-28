using ContactBookApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContactPage : ContentPage
	{
        private ContactDetailPage page;
        private AddContactPage page1;

        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

        public AddContactPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException();

            InitializeComponent();

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };

        }

        async void OnSave(object sender, System.EventArgs e)
        {
            var contact = BindingContext as Contact;

            //This to make sure the user enter a name
            if (String.IsNullOrWhiteSpace(contact.FullName))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (contact.Id == 0)
            {
                // This is just a temporary hack to differentiate between a
                // new and an existing Contact object. 
                contact.Id = 1;

                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                ContactUpdated?.Invoke(this, contact);
            }

            await Navigation.PopAsync();
        }
    }
}