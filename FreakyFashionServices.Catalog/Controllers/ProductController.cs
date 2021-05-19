using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashionServices.Catalog.Data;
using FreakyFashionServices.Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.Catalog.Controllers
{
    [ApiController]
    [Route("api/catalog/items")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;

   
        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return context.Product.ToList(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            context.Product.Add(product);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            context.Product.Remove(product);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
