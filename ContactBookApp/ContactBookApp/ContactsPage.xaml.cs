﻿using ContactBookApp.Modals;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactsPage : ContentPage
	{
        private ObservableCollection<Contact> _contacts;
        private SQLiteAsyncConnection _connection;
        private bool _isDataLoaded;

        public ContactsPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            await LoadData();

            base.OnAppearing();
        }

        private async Task LoadData()
        {
            await _connection.CreateTableAsync<Contact>();

            var contacts = await _connection.Table<Contact>().ToListAsync();

            _contacts = new ObservableCollection<Contact>(contacts);

            contactList.ItemsSource = _contacts;
        }

        private async void OnAddContact(object sender, EventArgs e)
        {

            var page = new ContactDetailPage(new Contact());

            // We can subscribe to the ContactAdded event using a lambda expression.
            // If you're not familiar with this syntax, watch my C# Advanced course. 
            page.ContactAdded += (source, contact) =>
            {
                // ContactAdded event is raised when the user taps the Done button.
                // Here, we get notified and add this contact to our 
                // ObservableCollection.
                _contacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        private async void MenuItem_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            contactList.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);

            page.ContactUpdated += (source, contact) =>
            {
                // When the target page raises ContactUpdated event, we get 
                // notified and update properties of the selected contact. 
                // Here we are dealing with a small class with only a few 
                // properties. If working with a larger class, you may want 
                // to look at AutoMapper, which is a convention-based mapping
                // tool. 
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;
            };

            await Navigation.PushAsync(page);

        }

        private async void Delete_Contact(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
                _contacts.Remove(contact);
        }
    }
}