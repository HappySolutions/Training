using BookStore.Models;
using BookStore.Persistance;
using BookStore.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStore
{
	public partial class MainPage : ContentPage
	{
        private ObservableCollection<Book> _books;
        private SQLiteAsyncConnection _connection;
        private bool _isDataLoaded;

        public MainPage()
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
            await _connection.CreateTableAsync<Book>();

            var books = await _connection.Table<Book>().ToListAsync();

            _books = new ObservableCollection<Book>(books);

            bookList.ItemsSource = _books;
        }

        private async void OnAddBook(object sender, EventArgs e)
        {

            var page = new BookDetailPage(new Book());

            // We can subscribe to the ContactAdded event using a lambda expression.
            page.BookAdded += (source, book) =>
            {
                // ContactAdded event is raised when the user taps the Done button.
                // Here, we get notified and add this contact to our 
                // ObservableCollection.
                _books.Add(book);
            };

            await Navigation.PushAsync(page);
        }

        private async void MenuItem_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedBook = e.SelectedItem as Book;

            bookList.SelectedItem = null;

            var page = new BookDetailPage(selectedBook);

            page.BookUpdated += (source, book) =>
            {
                // When the target page raises ContactUpdated event, we get 
                // notified and update properties of the selected contact. 

                selectedBook.Id = book.Id;
                selectedBook.BookName = book.BookName;
                selectedBook.Auther = book.Auther;
                selectedBook.ISBN = book.ISBN;
            };

            await Navigation.PushAsync(page);

        }

        private async void Delete_Book(object sender, EventArgs e)
        {
            var book = (sender as MenuItem).CommandParameter as Book;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {book.BookName}?", "Yes", "No"))
                _books.Remove(book);
            // we must add this line to make sure the contact is deleted from the database
            await _connection.DeleteAsync(book);


        }
    }
}