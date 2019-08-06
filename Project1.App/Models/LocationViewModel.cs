using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1.App.Models
{
    public class LocationViewModel
    {
        [Display(Name = "Id")]
        public int LocationID { get; set; }

        [Display(Name ="Store Name")]
        public string StoreName { get; set; }

        [Required]
        public int X { get; set; }

        [Required]
        public int Y { get; set; }

        [Display(Name = "Product List")]
        public Dictionary<ProductViewModel,int> Inventory { get; set; }

        [Display(Name = "Order History")]
        public List<OrderViewModel> OrderHistory { get; set; }
    }
}
