using System;
using System.Collections.Generic;
using Serilog;
/*
location
    . has an inventory
    . inventory decreases when orders are accepted
    . rejects orders that cannot be fulfilled with remaining inventory
    . relationship between products sold and inventory required must have some complexity for at least one product
    . has order history
 */

namespace Project1.Library.Modals
{
    /// <summary>
    /// Location that solely consists of Inventory of Products.
    /// </summary>
    public class Location : Store
    {

        private static ILogger _logger = new LoggerConfiguration().WriteTo.File("LocationModals.log").CreateLogger();
        // Default Constructor
        public Location(){
            LocationID = -1;
            Inventory = new Dictionary<Product, int>();            
            OrderHistory = new List<Order>();
        }

        // Overload Constructor
        public Location(Store store) : base(store) {            
            Inventory = new Dictionary<Product, int>();            
            OrderHistory = new List<Order>();
        }

        /// <summary>
        /// A constructor that will copy an existing location to current one.
        /// </summary>
        /// <param name="newLocation"> another existing location object </param>
        public Location(Location newLocation) : base(newLocation)
        {
            LocationID = newLocation.LocationID;
            Address = newLocation.Address;
            Inventory = newLocation.Inventory;
            OrderHistory = newLocation.OrderHistory;            
        }

        // Location ID
        public int LocationID;

        // An address of a store location
        public Address Address { set; get; }

        // A list of available items for that location.
        // For Inventory with number of items left.
        public Dictionary<Product, int> Inventory { set; get; }


        // A list of order history by customers
        public List<Order> OrderHistory { get; set; }


        /// <summary>
        /// a void method that restocks products in the inventory. If the product exists, it will increment the stocks.
        /// Else will register as a new product with new amount.
        /// </summary>
        /// <param name="product"> a product either newly registered or existing one </param>
        /// <param name="amount"> number of product to be added into inventory </param>
        public bool AddProduct(Product product,int amount)
        {
            if (product == null || amount < 1) return false;
            if (Inventory.ContainsKey(product))
                Inventory[product] += Inventory[product] + amount;
            else
                Inventory.Add(product, amount);
            return true;
        }

        /// <summary>
        /// A boolean method that will check whether the product with the certain amount can be purchased.
        /// For confirming whether the order can be placed by user request.
        /// </summary>
        /// 
        /// <param name="Product"> Product input to get the item detail </param>
        /// <param name="amount"> Amount used for unreasonable amount checking </param>
        /// <returns> Return if product meets the requirement to purchase </returns>

        protected bool CanPlaceOrder(Product Product, int amount)
        {
            // Check whether the product exists and the product amount ordered is still in stock.
            if (Inventory.ContainsKey(Product) && Inventory[Product] > amount)
            {
                // Check whether the product is part of restrict to buy product and amount ordered exceeds the restricted amount.
                if (amount > Product.RestrictedAmount && Product.RestrictedAmount > 0)
                {
                    _logger.Information("Order cannot be placed. Limit amount Exceeded.");
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Input Customer request and check if it can be fulfilled. If it can, the "Order" object will be returned.
        /// </summary>
        /// 
        /// <param name="AllProduct"> Product input to get the item detail </param>        
        /// <param name="Customer"> Customer to create an order </param>
        /// <returns> Return a new order if order can be placed else null </returns>


        public Order PlaceOrder(Dictionary<Product, int> AllProduct, Customer Customer)
        {
            if (AllProduct == null || Customer == null)
            {
                throw new ArgumentNullException(nameof(AllProduct), "You have not entered anything.");
            }

            Order Final_Order = new Order();
            foreach (var productItem in AllProduct)
            {
                if (!CanPlaceOrder(productItem.Key, productItem.Value))
                {
                    // LOGGING REQUIRED
                    _logger.Information($"WARNING: {productItem.Key.Name.ToUpper()} OUT OF STOCK OR EXCEEDED RESTRICTED AMOUNT. TRY AGAIN LATER.");
                    continue;
                }
                else
                {
                    Inventory[productItem.Key] -= productItem.Value;
                    Final_Order.AddProduct(productItem.Key, productItem.Value);
                }
            }

            Final_Order.CustomerId = Customer.CustomerId;
            Final_Order.CustomerName = Customer.FirstName + ' ' + Customer.LastName;
            
            // Registered the record of Customer order on Store Location site.
            OrderHistory.Add(Final_Order);

            // Then return the result of Finalized Order to Customer to save them as a record.

            return Final_Order.ProductDetail.Count >= 1 && Final_Order.ProductPrice.Count >= 1 ? Final_Order : null;                        
        }        
    }
}
