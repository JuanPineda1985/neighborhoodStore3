using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace neighborhoodStore3.Models
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
    }
}

namespace neighborhoodStore3.Models
{
    public class ProductDetailDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
    }
}