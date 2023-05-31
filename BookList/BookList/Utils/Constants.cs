using System;
using System.Collections.Generic;
using System.Text;

namespace BookList.Utils
{
    public static class Constants
    {
        public static string ApiUrl = "https://www.googleapis.com/books/v1/volumes?q=ios";
        public static int MaxResult = 10;
        public static int StartIndex = 0;
    }
}
