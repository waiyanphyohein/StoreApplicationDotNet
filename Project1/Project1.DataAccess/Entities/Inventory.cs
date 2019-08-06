﻿using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int Unit { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
        
    }
}
