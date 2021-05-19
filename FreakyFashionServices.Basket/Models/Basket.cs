using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Models
{
    public class Basket
    {
        public Basket(int id, List<Items> items)
        {
            Id = id;
            Items = items;
        }
        
        public int Id { get; set; }
        public IList<Items> Items { get; set; }
    }
}
