using FreakyFashionServices.Order.Data;
using FreakyFashionServices.Order.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpClientFactory clientFactory;

        public OrderController(ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            this.context = context;
            this.clientFactory = clientFactory;
        }

        [HttpPost]
        public async Task<int> NewOrderAsync(OrderDto orderDto) 
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44332/api/basket/" + orderDto.CustomerIdentifier);

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedBasket = await response.Content.ReadAsStringAsync();

            var basketItems = JsonSerializer.Deserialize<Basket>(serializedBasket);

            var order = new Models.Order(firstName: orderDto.FirstName, lastName: orderDto.LastName, basket: basketItems);

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
    }
}
