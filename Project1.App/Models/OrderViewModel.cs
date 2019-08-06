using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Project1.App.Models
{
    public class OrderViewModel
    {
        [Display(Name ="ID")]
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Order Address")]
        public string Location { get; set; }

        [Display(Name ="Product")]
        public IEnumerable<OrderDetailViewModel> Purchase { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

    }
}
