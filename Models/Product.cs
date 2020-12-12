 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace neighborhoodStore3.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}