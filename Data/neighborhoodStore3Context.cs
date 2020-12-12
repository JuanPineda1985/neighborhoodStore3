using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace neighborhoodStore3.Data
{
    public class neighborhoodStore3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public neighborhoodStore3Context() : base("name=neighborhoodStore3Context")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<neighborhoodStore3.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<neighborhoodStore3.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<neighborhoodStore3.Models.Sales> Sales { get; set; }
    }
}
