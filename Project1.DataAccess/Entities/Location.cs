using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Location
    {
        public Location()
        {
            Inventory = new HashSet<Inventory>();
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int LocationId { get; set; }
        public int StoreId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
