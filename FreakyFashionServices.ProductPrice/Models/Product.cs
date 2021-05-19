using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.ProductPrice.Models
{
    public class Product
    {
        public Product(string articleNumber, int price)
        {
            ArticleNumber = articleNumber;
            Price = price;
        }

        public Product(int id, string articleNumber, int price)
        {
            Id = id;
            ArticleNumber = articleNumber;
            Price = price;
        }

        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public int Price { get; set; }
    }
}
