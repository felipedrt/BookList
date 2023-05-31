using BookList.Models;
using BookList.Utils;
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
        public async Task<ObservableCollection<Book>> getBooks(int maxResult, int startIndex)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var url = Constants.ApiUrl + "&maxResults=" + maxResult + "&startIndex=" + startIndex + "";

                    HttpResponseMessage response = await client.GetAsync(url);
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
