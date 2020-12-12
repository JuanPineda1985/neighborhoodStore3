using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace neighborhoodStore3.Models
{
    public class User
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime SalesDate { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }

        internal static void ForEach(Func<object, User> p)
        {
            throw new NotImplementedException();
        }
    }
}