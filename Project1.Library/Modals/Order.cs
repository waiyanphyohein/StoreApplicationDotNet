using System;
using System.Collections.Generic;
/*
order
. has a store location
. has a customer
. has an order time (when the order was placed)
. must have some additional business rules
*/

namespace Project1.Library.Modals
{
    public class Order
    {
        // Order ID
        public int OrderId { get; set; }

        // Location ID
        public int LocationID { get; set; }

        // Store Location
        public Address Location { set; get; }

        // Customer ID
        public int CustomerId { set; get; }

        // Customer Name
        public string CustomerName { get; set; }

        // Product Related Detail
        public Dictionary<string, int> ProductDetail { get; set; }

        // Product Price
        public Dictionary<string, double> ProductPrice { get; set; }

        // NOTE: How should we consider Business Rules here? How can it affect our application?
        public string Rules { get; set; }

        // Date the order was placed.
        public DateTime PurchaseDate { get; set; }
             
        /// <summary>
        /// Adding a product into order for customer can order multiple items
        /// </summary>
        /// <param name="product"> The customer product purchase </param>
        /// <param name="amount"> The number of product to be purchased </param>
        public bool AddProduct(Product product, int amount)
        {
            // SPECIAL CASE TO CONSIDER: IF THE RESTRICTED AMOUNT IS LESS THAN OR EQUAL TO 0, IT MEANS THERE IS NO LIMIT.
            if (product == null || amount <= 0 || (product.RestrictedAmount > 0 && product.RestrictedAmount < amount)) return false;

            ProductDetail.Add(product.Name, amount);
            ProductPrice.Add(product.Name, Math.Round(product.Price,2));
            return true;
        }

        /// <summary>
        /// A method that will add a buyer background detail to order.
        /// </summary>
        /// <param name="cust"> a customer detail </param>
        public bool UpdateCustomer(Customer cust)
        {
            if (cust == null) return false;
            this.CustomerId = cust.CustomerId;
            this.CustomerName = cust.FirstName + ' ' + cust.LastName;
            return true;
        }

        /// <summary>
        /// Setting a new location to order detail. (For example, user can change the order origin to anywhere.)
        /// </summary>
        /// <param name="NewAddress"> New Address for Location field </param>
        public bool UpdateLocation(Location NewAddress)
        {
            if (NewAddress == null) return false;            
            if (NewAddress.LocationID <= 0) return false;
            Location = new Address { X = NewAddress.Address.X, Y = NewAddress.Address.Y };
            LocationID = NewAddress.ID;
            return true;
        }        

        /// <summary>
        /// A summary output of an order.
        /// </summary>
        /// <returns> return a output stirng format for console log to be printed.</returns>
        override
        public string ToString()
        {
            string result = "Customer: " + CustomerName + "\n" +
                    "Location: " + Location + "\n"+
                    "Rules: "+ Rules + "\n";
            foreach(var item in ProductDetail)
            {
                result += item.ToString();
            }
            return result;
        }
        
    }
}
