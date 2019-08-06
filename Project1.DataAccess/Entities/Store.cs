using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Store
    {
        public Store()
        {
            Location = new HashSet<Location>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<Location> Location { get; set; }
    }
}
