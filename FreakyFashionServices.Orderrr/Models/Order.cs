using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Models
{
    public class Order
    {
        public Order(string firstName, string lastName, Basket basket)
        {
            FirstName = firstName;
            LastName = lastName;
            Basket = basket;
        }

        public Order(int id, string firstName, string lastName, Basket basket)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Basket = basket;
            
        }
        public Order()
        {

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Basket Basket { get; set; }

    }
}
