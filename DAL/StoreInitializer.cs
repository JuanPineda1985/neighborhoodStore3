using neighborhoodStore3.Models;
using System;
using System.Collections.Generic;

namespace neighborhoodStore3.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var Users = new List<User>
            {
                new User{FirstMidName="Carlos", LastName="Vargas", SalesDate=DateTime.Parse("2020-20-10")},
                new User{FirstMidName="Andres", LastName="Ramirez", SalesDate=DateTime.Parse("2020-23-01")},
                new User{FirstMidName="Luis", LastName="Molano", SalesDate=DateTime.Parse("2019-20-10")},
            };
            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            var products = new List<Product>
            {
                new Product{ProductID=1020, ProductName="Arroz", Price=1000,},
                new Product{ProductID=1002, ProductName="Frijol", Price=2000,},
                new Product{ProductID=1123, ProductName="Arepas", Price=1500,},
            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
            var sales = new List<Sales>
            {
                new Sales{UserID=1, PruductID=1020, ClientType=ClientType.A},
                new Sales{UserID=2, PruductID=1002, ClientType=ClientType.C},
                new Sales{UserID=3, PruductID=1123, ClientType=ClientType.D},
            };
            sales.ForEach(s => context.Sales.Add(s));
            context.SaveChanges();

        }
    }
}