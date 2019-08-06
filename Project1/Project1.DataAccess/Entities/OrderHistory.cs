using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class OrderHistory
    {
        public OrderHistory()
        {
            OrderHistoryDetail = new HashSet<OrderHistoryDetail>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location location { get; set; }

        
        public virtual ICollection<OrderHistoryDetail> OrderHistoryDetail { get; set; }
    }
}
