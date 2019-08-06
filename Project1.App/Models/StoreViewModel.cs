using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1.App.Models
{
    public class StoreViewModel
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Rules { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public IEnumerable<LocationViewModel> Locations { get; set; }
    }
}
