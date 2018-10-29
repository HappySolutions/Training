using BookStore.Models;
using BookStore.Persistance;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddBookPage : ContentPage
	{
        private BookDetailPage page;
        private AddBookPage page1;
        private SQLiteAsyncConnection _connection;

        public event EventHandler<Book> BookAdded;
        public event EventHandler<Book> BookUpdated;


        public AddBookPage (Book book)
		{
            if (book == null)
                throw new ArgumentNullException();

            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


            BindingContext = new Book
            {
                Id = book.Id,
                BookName = book.BookName,
                Auther = book.Auther,
                ISBN = book.ISBN,
            };

        }

        async void OnSave(object sender, System.EventArgs e)
        {
            var book = BindingContext as Book;

            //This to make sure the user enter a name
            if (String.IsNullOrWhiteSpace(book.BookName))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (book.Id == 0)
            {
                // This is just a temporary hack to differentiate between a
                // new and an existing Contact object. 
                book.Id = 1;

                BookAdded?.Invoke(this, book);
            }
            else
            {
                BookUpdated?.Invoke(this, book);
            }

            await Navigation.PopAsync();
        }
    }
}