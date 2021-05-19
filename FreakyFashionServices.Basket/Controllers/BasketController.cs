using EasyCaching.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;

namespace FreakyFashionServices.Basket.Controllers
{
    [ApiController]
    [Route("api/basket")]
    public class BasketController : ControllerBase
    {
        private IEasyCachingProvider cachingProvider;
        private IEasyCachingProviderFactory cachingProviderFactory;

        public BasketController(IEasyCachingProviderFactory cachingProviderFactory)
        {
            this.cachingProviderFactory = cachingProviderFactory;
            cachingProvider = this.cachingProviderFactory.GetCachingProvider("redis-db");
        }

        [HttpPut("{id}")]
        public IActionResult PutItemsInBasket(int id, Models.Basket basket)
        {
            basket.Id = id;
            var serializedBasket = JsonConvert.SerializeObject(basket);
            cachingProvider.Set(id.ToString(), serializedBasket, TimeSpan.FromDays(15));
            return NoContent();
        }
        
        [HttpGet("{id}")]
        public IActionResult GetItemsFromBasket(int id)
        {
            var result = cachingProvider.Get<string>(id.ToString());
            var serializedResult = JsonConvert.DeserializeObject(result.ToString());

            return Ok(serializedResult);
        }
    }
}
