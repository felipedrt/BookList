using BookList.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Services
{
    public class BooksService : IBooksService
    {
        public async Task<ObservableCollection<Book>> getBooks(int maxResult = 10, int startIndex = 1)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var uri = "https://www.googleapis.com/books/v1/volumes?q=ios&maxResults=" + maxResult + "&startIndex=" + startIndex + "";


                    HttpResponseMessage response = await client.GetAsync(uri);
                    var result = await response.Content.ReadAsStringAsync();

                    var books = JsonConvert.DeserializeObject<Books>(result);
                    return books.items;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
            throw new NotImplementedException();
        }
    }
}
