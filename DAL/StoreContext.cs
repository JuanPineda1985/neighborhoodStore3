using neighborhoodStore3.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace neighborhoodStore3.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}