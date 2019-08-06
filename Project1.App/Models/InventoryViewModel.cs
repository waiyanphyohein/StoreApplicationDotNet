using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project1.App.Models
{
    public class InventoryViewModel
    {
        public int ProductID { get; set; }

        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Available Quantity")]
        public int AvailableUnits { get; set; }

        [Display(Name = "Restricted Amount")]
        public int RestrictedAmount { get; set; }
        
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name ="Amount To Purchase")]
        public int SelectAmount { get; set; }
    }
}
