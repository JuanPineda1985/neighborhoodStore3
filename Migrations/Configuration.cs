namespace neighborhoodStore3.Migrations
    
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using neighborhoodStore3.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<neighborhoodStore3.Data.neighborhoodStore3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(neighborhoodStore3.Data.neighborhoodStore3Context context)
        {
            context.Users.AddOrUpdate(x => x.ID,
                new User() { ID = 1, FirstMidName = "Daniel", LastName = "Hernandez", SalesDate = DateTime.Parse("2020-12-01")},
                new User() { ID = 2, FirstMidName = "Esteban", LastName = "Rojas", SalesDate = DateTime.Parse("2020-09-01") },
                new User() { ID = 3, FirstMidName = "Camilo", LastName = "Perez", SalesDate = DateTime.Parse("2020-05-12") }
                );
            context.Products.AddOrUpdate(x => x.ProductID,
                new Product() { ProductID = 2010, ProductName = "Arroz", Price = 1500 },
                new Product() { ProductID = 1254, ProductName = "Arepas", Price = 1500 },
                new Product() { ProductID = 2254, ProductName = "Lentejas", Price = 1500 }
                );
            context.Sales.AddOrUpdate(x => x.SalesID,
                new Sales() { SalesID = 1, PruductID = 2010, UserID = 1, ClientType = ClientType.A },
                new Sales() { SalesID = 2, PruductID = 1254, UserID = 2, ClientType = ClientType.C },
                new Sales() { SalesID = 3, PruductID = 2254, UserID = 3, ClientType = ClientType.C }
                );
        }
    }
}
