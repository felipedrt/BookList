using BookList.Models;
using BookList.Services;
using BookList.ViewModels;
using BookList.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookList.Views
{
    public partial class MainPage : ContentPage
    {
        private BooksService booksService = new BooksService();
        private int maxResult = 10;
        private int startIndex = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            //var scrollView = sender as ScrollView;
            //double remainingItemsThreshold = maxResult;

            //if (scrollView.ContentSize.Height - scrollView.ScrollY <= scrollView.Height + remainingItemsThreshold)
            //{
            //    maxResult += 10;
            //    startIndex += 1;
            //    await booksService.getBooks(maxResult, startIndex);
            //}
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushAsync(new BookDetails());
        }
    }
}
