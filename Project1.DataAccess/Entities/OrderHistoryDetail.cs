using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class OrderHistoryDetail
    {
        public int OrderHistoryDetailId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal? Total { get; set; }

        public virtual OrderHistory Order { get; set; }
    }
}
