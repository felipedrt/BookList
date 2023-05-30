using System;
using System.Collections.Generic;
using System.Text;

namespace BookList.Models
{
    public class Offer
    {
        public int finskyOfferType { get; set; }
        public ListPrice listPrice { get; set; }
        public RetailPrice retailPrice { get; set; }
        public bool giftable { get; set; }
    }
}
