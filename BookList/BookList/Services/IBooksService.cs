using BookList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Services
{
    public interface IBooksService
    {
        Task<ObservableCollection<Book>> getBooks(int maxResult = 20, int startIndex = 0);
    }
}
