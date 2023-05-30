using System;
using System.Collections.Generic;
using System.Text;

namespace BookList.Models
{
    public class SaleInfo
    {
        public string country { get; set; }
        public string saleability { get; set; }
        public bool isEbook { get; set; }
        public ListPrice listPrice { get; set; }
        public RetailPrice retailPrice { get; set; }
        public string buyLink { get; set; }
        public IList<Offer> offers { get; set; }
    }
}
