using System;
using System.Collections.Generic;
using System.Linq;
/*
customer
. has first name, last name, etc.
. has a default store location to order from
. cannot place more than one order from the same location within two hours
*/

namespace Project1.Library.Modals
{
    public class Customer
    {       
        // ASK: IF IT IS A GOOD PRACTISE OR NOT TO USE REQUIRED FIELD.        
        public int CustomerId { get; set; }

        public string FirstName {get;set;}
            

        
        public string LastName { set; get; }

        public Address Address { set; get; }

        // List of Customer Orders.
        public List<Order> OrderHistory { set; get; }

        /// <summary>
        /// A method that returns a string of Order History of Customer.
        /// </summary>
        /// <returns> return all OrderHistory of a customer </returns>
        public string OrderHistoryToString()
        {
            string Customer_OrderHistory = "";

            foreach(var order in OrderHistory)            
                Customer_OrderHistory += order.ToString();            
            return Customer_OrderHistory;
        }

        /// <summary>
        /// Return a summary description of Customer Detail
        /// </summary>
        /// <returns> string that tells about customer info</returns>        
        public override string ToString()
        {
            return "Name: " + FirstName + " " + LastName + "\n" +
                   "Address: "+ Address + "\n";
        }
        
    }
}
