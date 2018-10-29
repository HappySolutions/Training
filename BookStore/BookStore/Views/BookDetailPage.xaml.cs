using BookStore.Models;
using BookStore.Persistance;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookDetailPage : ContentPage
	{
        public event EventHandler<Book> BookAdded;
        public event EventHandler<Book> BookUpdated;
        private SQLiteAsyncConnection _connection;

        public BookDetailPage (Book book)
        {
            if (book == null)
                throw new ArgumentNullException();

            BindingContext = book;

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

            if (String.IsNullOrWhiteSpace(book.BookName))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (book.Id == 0)
            {
                await _connection.InsertAsync(book);

                BookAdded?.Invoke(this, book);
            }
            else
            {
                await _connection.UpdateAsync(book);

                BookUpdated?.Invoke(this, book);
            }

            await Navigation.PopAsync();
        }
    }
}
