using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Catalog.Models
{
    public class Product
    {
        public Product()
        {

        }
        public Product(string name, string articleNumber, string description, int availableStock, int price)
        {
            Name = name;
            ArticleNumber = articleNumber;
            Description = description;
            AvailableStock = availableStock;
            Price = price;
        }

        public Product(int id, string articleNumber, string name, string description, int availableStock, int price)
        {
            Id = id;
            ArticleNumber = articleNumber;
            Name = name;
            Description = description;
            AvailableStock = availableStock;
            Price = price;
        }

        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableStock { get; set; }
        public int Price { get; set; }
        
    }
}
