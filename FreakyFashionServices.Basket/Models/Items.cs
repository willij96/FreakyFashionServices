using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Models
{
    public class Items
    {
        public Items(int id, string articleNumber, string productName, int unitPrice, int quantity)
        {
            Id = id;
            ArticleNumber = articleNumber;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }


        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
