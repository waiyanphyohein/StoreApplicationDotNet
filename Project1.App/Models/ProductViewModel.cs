using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1.App.Models
{
    public class ProductViewModel
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string ProductName { get; set; }

        [MaxLength(50)]
        public string Type { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        public int RestrictedAmount { get; set; }
    }
}
