using System;
namespace Project1.App.Models
{
    public class OrderDetailViewModel
    {
        public int CustomerID { get; set; }
        public string ProductName { get; set; }
        
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
