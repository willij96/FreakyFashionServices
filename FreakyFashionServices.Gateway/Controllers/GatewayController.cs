
using EasyCaching.Core;
using FreakyFashionServices.Gateway.Data;
using FreakyFashionServices.Gateway.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Gateway.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpClientFactory clientFactory;

        private IEasyCachingProvider cachingProvider;
        private IEasyCachingProviderFactory cachingProviderFactory;

        public OrderController(ApplicationDbContext context, IHttpClientFactory clientFactory, IEasyCachingProviderFactory cachingProviderFactory)
        {
            this.context = context;
            this.clientFactory = clientFactory;
            this.cachingProviderFactory = cachingProviderFactory;
            cachingProvider = this.cachingProviderFactory.GetCachingProvider("redis-db");
        }

        [Route("products")]
        [HttpGet]
        public async Task<List<Product>> GetProductsAsync()
        {
            return await ConvertPrice();

        }

        private async Task<List<Product>> ConvertPrice()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44356/api/catalog/items"); //Catalog API

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedCatalog = await response.Content.ReadAsStringAsync();

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var catalog = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(serializedCatalog, serializeOptions);

            var articleNumberList = new List<string>();

            foreach (var productItem in catalog)
            {
                var articleNumber = productItem.ArticleNumber;
                articleNumberList.Add(articleNumber);
            }

            string stringQuery = string.Join(",", articleNumberList.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray());

            request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44392/api/productprice?products=" + stringQuery); //ProductPrice API

            request.Headers.Add("Accept", "application/json");

            client = clientFactory.CreateClient();

            response = await client.SendAsync(request);

            var serializedProduct = await response.Content.ReadAsStringAsync();

            var products = System.Text.Json.JsonSerializer.Deserialize<List<ProductPriceDto>>(serializedProduct, serializeOptions);

            var productList = new List<Product>();

            foreach (var c in catalog)
            {
                foreach (var p in products)
                {
                    if (c.ArticleNumber.ToLower() == p.ArticleNumber.ToLower())
                    {
                        c.Price = p.Price;
                        productList.Add(c);
                    }
                }
            }

            return productList;
        }

        [Route("basket/{id}")]
        public IActionResult PutItemsInBasket(int id, Basket basket)
        {
            var listOfProducts = ConvertPrice();
            foreach (var b in basket.Items)
            {
                foreach (var p in listOfProducts.Result)
                {
                    if (b.ArticleNumber.ToLower() == p.ArticleNumber.ToLower())
                    {
                        b.UnitPrice = p.Price;
                    }
                    else break;
       
                }
            }
            basket.Id = id;
            var serializedBasket = JsonConvert.SerializeObject(basket);
            cachingProvider.Set("Basket_" + id, serializedBasket, TimeSpan.FromDays(15));
            return NoContent();
        }

        [HttpPost]
        [Route("order")]
        public async Task<int> NewOrderAsync(OrderDto orderDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44332/api/basket/" + orderDto.CustomerIdentifier);

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedBasket = await response.Content.ReadAsStringAsync();

            var basketItems = System.Text.Json.JsonSerializer.Deserialize<Basket>(serializedBasket);

            var order = new Order(firstName: orderDto.FirstName, lastName: orderDto.LastName, basket: basketItems);

            order.Basket.Id = 0;

            foreach (var item in order.Basket.Items)
            {
                item.Id = 0;
            }

            context.Order.Add(order);

            await context.SaveChangesAsync();

            return order.Id;

        }

        public class OrderDto
        {
            public int CustomerIdentifier { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class ProductPriceDto 
        {
            public string ArticleNumber { get; set; }
            public int Price { get; set; }
        }
    }
}
