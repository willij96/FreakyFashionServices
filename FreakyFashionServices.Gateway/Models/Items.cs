using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Gateway.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
