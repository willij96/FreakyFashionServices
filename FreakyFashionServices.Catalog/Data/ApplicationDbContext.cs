using FreakyFashionServices.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FreakyFashionServices.Catalog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var products = new List<Product>
            {
               new Product(1, "atq134","name1", "description1", 1, 101),
               new Product(2, "vdw234","name2", "description2", 2, 102),
               new Product(3, "opa554","name3", "description3", 3, 103),
               new Product(4, "ort578","name4", "description4", 4, 104),
               new Product(5, "ace548","name5", "description5", 5, 105),
               new Product(6, "pob789","name6", "description6", 6, 106),
               new Product(7, "acr467","name7", "description7", 7, 107),
               new Product(8, "pav356","name8", "description8", 8, 108),
               new Product(9, "zzz728","name9", "description9", 9, 109),
               new Product(10, "xxx823","name10", "description10", 10, 110),
            };

            products.ForEach(x => modelBuilder.Entity<Product>().HasData(x));
        }

    }
}
