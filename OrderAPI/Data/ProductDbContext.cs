using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OrderAPI.Model;

namespace OrderAPI.Data
{
    public class ProductDb
    {
        public IList<Order> Orders { get; set; }
        public IDictionary<int, ProductType> ProductTypes { get; set; }
        public ProductDb()
        {
            Orders = new List<Order>();
            ProductTypes = new Dictionary<int, ProductType>() {
            {1, new ProductType { Id = 1, Name = "photoBook", Width = 19 }},
            { 2, new ProductType { Id = 2, Name = "calendar", Width = 10 }},
            { 3, new ProductType { Id = 3, Name = "canvas", Width = 16 } },
            { 4, new ProductType { Id = 4, Name = "cards", Width = 4.7m }},
            { 5, new ProductType { Id = 5, Name = "mug", Width = 94 } } };
        }

        public int GenerateNewOrderId()
        {
            return Orders.Count + 1;
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var phtoBook
        //    modelBuilder.Entity<ProductType>().HasData(
        //        new ProductType { Id = 1, Name = "photoBook", Width = 19 });
        //    modelBuilder.Entity<ProductType>().HasData(
        //        new ProductType { Id = 2, Name = "calendar", Width = 10 });
        //    modelBuilder.Entity<ProductType>().HasData(
        //        new ProductType { Id = 3, Name = "canvas", Width = 16 });
        //    modelBuilder.Entity<ProductType>().HasData(
        //        new ProductType { Id = 4, Name = "cards", Width = 4.7m });
        //    modelBuilder.Entity<ProductType>().HasData(
        //        new ProductType { Id = 5, Name = "mug", Width = 94 });

        //}

    }
}