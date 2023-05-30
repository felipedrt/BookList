using BookList.Services;
using BookList.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IBooksService, BooksService>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
