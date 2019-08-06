using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1.App.Models
{
    public class CustomerViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Longitude")]
        public int X { get; set; }

        [Display(Name = "Latitude")]
        public int Y { get; set; }

        [Display(Name = "Order History")]
        public List<OrderViewModel> Orderlist { get; set; }
    }
}
