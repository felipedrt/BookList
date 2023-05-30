using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BookList.Models
{
    public class Books
    {
        public string kind { get; set; }
        public int totalItems { get; set; }
        public ObservableCollection<Book> items { get; set; }
    }
}
