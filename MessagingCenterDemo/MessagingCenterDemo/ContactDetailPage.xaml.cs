using MessagingCenterDemo.Models;
using MessagingCenterDemo.Persistance;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingCenterDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailPage : ContentPage
	{
       // public event EventHandler<Contact> ContactAdded;
       // public event EventHandler<Contact> ContactUpdated;
        private SQLiteAsyncConnection _connection;

        public ContactDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException();

            BindingContext = contact;

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

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

            if (String.IsNullOrWhiteSpace(contact.FullName))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (contact.Id == 0)
            {
                await _connection.InsertAsync(contact);

                MessagingCenter.Send(this, Events.ContactAdded, contact);

                //ContactAdded?.Invoke(this, contact);
            }
            else
            {
                await _connection.UpdateAsync(contact);
                MessagingCenter.Send(this, Events.ContactUpdated, contact);

                //ContactUpdated?.Invoke(this, contact);
            }

            await Navigation.PopAsync();
        }
    }
}
