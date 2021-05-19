using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Gateway.Models
{
    public class Basket
    {
        public Basket(int id)
        {
            Id = id;
        }

        public Basket(int id, List<Items> items)
        {
            Id = id;
            Items = items;
        }

        public Basket()
        {

        }
        public int Id { get; set; }
        public IList<Items> Items { get; set; }
    }
}
