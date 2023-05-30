using BookList.Models;
using BookList.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Linq;

namespace BookList.ViewModels
{
    public static class CurrentBook
    {
        public static Book SelectedBook { get; set; }
    }

    public class BooksViewModel : BaseModel
    {
        IBooksService _rest = DependencyService.Get<IBooksService>();

        #region Private Attributes
        
        private ObservableCollection<Book> books;
        private bool isLoading;
        private ICommand filterAllBooks;
        private string allBooksButtonBackground = "#2196F3";
        private string allBooksButtonTextColor = "White";

        private ICommand filterFavoriteBooks;
        private string filterFavoriteBooksButtonBackground;
        private string filterFavoriteBooksButtonTextColor;
        private Book selectedBook;

        #endregion

        #region Public Attributes

        public ObservableCollection<Book> Books
        {
            get
            {
                return books;
            }
            set
            {
                books = value;
                OnPropertyChanged("Books");
            }
        }

        public bool IsLoading
        {
            get 
            { 
                return isLoading; 
            }
            set
            {
                isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public ICommand FilterAllBooks
        {
            get
            {
                return filterAllBooks;
            }
            set
            {
                filterAllBooks = value;
                OnPropertyChanged("FilterAllBooks");

            }
        }

        public string AllBooksButtonBackground
        {
            get
            {
                return allBooksButtonBackground;
            }
            set
            {
                allBooksButtonBackground = value;
                OnPropertyChanged("AllBooksButtonBackground");
            }
        }

        public string AllBooksButtonTextColor
        {
            get 
            { 
                return allBooksButtonTextColor; 
            }
            set
            {
                allBooksButtonTextColor = value;
                OnPropertyChanged("AllBooksButtonTextColor");
            }
        }

        public ICommand FilterFavoriteBooks
        {
            get 
            { 
                return filterFavoriteBooks;
            }
            set
            {
                filterFavoriteBooks = value;
                OnPropertyChanged("FilterFavoriteBooks");
            }
        }
        
        public string FilterFavoriteBooksButtonBackground
        {
            get
            {
                return filterFavoriteBooksButtonBackground;
            }
            set
            {
                filterFavoriteBooksButtonBackground = value;
                OnPropertyChanged("FilterFavoriteBooksButtonBackground");
            }
        }

        public string FilterFavoriteBooksButtonTextColor
        {
            get
            {
                return filterFavoriteBooksButtonTextColor;
            }
            set
            {
                filterFavoriteBooksButtonTextColor = value;
                OnPropertyChanged("FilterFavoriteBooksButtonTextColor");
            }
        }

        public Book SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                selectedBook = value;
                CurrentBook.SelectedBook = selectedBook;
                OnPropertyChanged("SelectedBook");
            }
        }

        #endregion

        #region Constructor

        public BooksViewModel()
        {
            FilterAllBooks = new Command(FilterAllBooks_OnClick);
            FilterFavoriteBooks = new Command(FilterFavoriteBooks_OnClick);

            GetBooks();
        }

        #endregion

        #region Methods
        
        public async void GetBooks()
        {
            try
            {
                IsLoading = true;
                var result = await _rest.getBooks();
                if (result != null)
                {
                    Books = result;
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        private void FilterAllBooks_OnClick()
        {
            AllBooksButtonBackground = "#2196F3";
            AllBooksButtonTextColor = "White";

            FilterFavoriteBooksButtonBackground = "#D6D7D7";
            FilterFavoriteBooksButtonTextColor = "Black";
            GetBooks();
        }

        private void FilterFavoriteBooks_OnClick()
        {
            AllBooksButtonBackground = "#D6D7D7";
            AllBooksButtonTextColor = "Black";

            FilterFavoriteBooksButtonBackground = "#2196F3";
            FilterFavoriteBooksButtonTextColor = "White";

            IsLoading = true;
            var filteredBooks = Books.Where((book) => Preferences.Get(book.id, false)).ToList<Book>();
            Books = new ObservableCollection<Book>(filteredBooks);
            IsLoading = false;
        }

        #endregion
    }
}
