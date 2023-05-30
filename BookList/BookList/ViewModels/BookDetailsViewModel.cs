using BookList.Models;
using BookList.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookList.ViewModels
{
    public class BookDetailsViewModel : BaseModel
    {
        #region Private Attributes

        private Book selectedBook;
        private bool buyButtonEnabled;
        private ICommand buyCommand;
        private ICommand favoriteOrUnfavoriteBook;
        private string favoriteButtonText;

        #endregion

        #region Public Attributes

        public Book SelectedBook
        {
            get
            {
                return this.selectedBook;
            }
            set
            {
                this.selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        public bool BuyButtonEnabled
        {
            get
            {
                if (SelectedBook.saleInfo.saleability == E_Saleability.FOR_SALE.ToString())
                    return true;
                return buyButtonEnabled;
            }
            set
            {
                buyButtonEnabled = value;
                OnPropertyChanged("BuyButtonEnabled");
            }
        }

        public ICommand BuyCommand
        {
            get
            {
                return buyCommand;
            }
            set
            {
                buyCommand = value;
                OnPropertyChanged("BuyCommand");
            }
        }

        public ICommand FavoriteOrUnfavoriteBook
        {
            get
            {
                return favoriteOrUnfavoriteBook;
            }
            set
            {
                favoriteOrUnfavoriteBook = value;
                OnPropertyChanged("FavoriteOrUnfavoriteBook");
            }
        }

        public string FavoriteButtonText
        {
            get
            {
                return GetFavoriteBook() ? "Set as Unfavorite Book" : "Set as Favorite Book";
            }
            set
            {
                favoriteButtonText = value;
                OnPropertyChanged("FavoriteButtonText");
            }
        }

        #endregion

        #region Constructor

        public BookDetailsViewModel()
        {
            SelectedBook = CurrentBook.SelectedBook;
            BuyCommand = new Command(BtnBuy_OnClick);
            FavoriteOrUnfavoriteBook = new Command(FavoriteOnUnfavorite_OnClick);
        }

        #endregion

        #region Methods

        private bool GetFavoriteBook()
        {
            return Preferences.Get(selectedBook.id, false);
        }

        public async void BtnBuy_OnClick()
        {
            await Browser.OpenAsync(SelectedBook.saleInfo.buyLink);
        }

        public void FavoriteOnUnfavorite_OnClick()
        {
            bool isFavorite = GetFavoriteBook();
            if (isFavorite)
            {
                Preferences.Set(selectedBook.id, false);
                FavoriteButtonText = "Set as Favorite Book";
            }
            else
            {
                Preferences.Set(selectedBook.id, true);
                FavoriteButtonText = "Set as Unfavorite Book";
            }
        }

        #endregion
    }
}
