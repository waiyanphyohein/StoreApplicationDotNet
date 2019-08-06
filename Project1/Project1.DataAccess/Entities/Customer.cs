using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Customer
    {        
        public Customer()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<OrderHistory> OrderHistory { get; set; }

    }
}
