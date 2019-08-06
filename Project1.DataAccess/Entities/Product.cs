using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int? RestrictedAmount { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
