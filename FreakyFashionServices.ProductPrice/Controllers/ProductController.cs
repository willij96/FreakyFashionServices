using FreakyFashionServices.ProductPrice.Extensions;
using FreakyFashionServices.ProductPrice.Models;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FreakyFashionServices.ProductPrice.Controllers
{
    [ApiController]
    [Route("api/productPrice")]
    public class ProductController : ControllerBase
    {
        public Product[] Products = new[]
        {
           new Product(1, "atq134", 1001),
           new Product(2 ,"vdw234", 1002),
           new Product(3, "opa554", 1003),
           new Product(4, "ort578", 1004),
           new Product(5, "ace548", 1005),
           new Product(6, "pob789", 1006),
           new Product(7, "acr467", 1007),
           new Product(8, "pav356", 1008),
           new Product(9, "zzz728", 1009),
           new Product(10, "xxx823", 1010),
        };

        public IEnumerable<Product> GetProducts(StrList products)
        {
            
            List<Product> productList = new List<Product>();

            foreach (var articleNumber in products)
            {
                foreach (var product in Products.Where(x => x.ArticleNumber.ToLower() == articleNumber.ToLower()))
                {
                    product.Id = 0;
                    productList.Add(product);
                }
            }

            return productList;
        }
    }
}
