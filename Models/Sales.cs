using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace neighborhoodStore3.Models
{
        public enum ClientType
        {
            A, B, C, D

        }

        public class Sales
        {
            public int SalesID { get; set; }
            public int PruductID { get; set; }
            public int UserID { get; set; }
            public ClientType? ClientType { get; set; }

            public virtual Product Product { get; set; }
            public virtual User User { get; set; }
        }
}
