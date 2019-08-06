using System;
using System.Collections.Generic;
using System.Linq;
using Project1.Library.Modals;
using Project1.DataAccess.Entities;

namespace Project1.DataAccess
{
    public static class Mapper
    {
        /// <summary>
        /// A method that convert DataAccess.Entities.Customer => Library.Customer
        /// </summary>
        /// <param name="customer"> a DataAcess.Entities.Customr that will be used to convert to Library.Customer </param>
        /// <returns> return a converted Library.Customer object </returns>
        public static Project1.Library.Modals.Customer Map(Project1.DataAccess.Entities.Customer customer)
        {
            return new Library.Modals.Customer
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = new Library.Modals.Address
                {
                    X = customer.X,
                    Y = customer.Y,
                },
                OrderHistory = Mapper.Map(customer.OrderHistory) ?? new List<Order>()
            };
        }

        /// <summary>
        /// A method used to convert Modals.Customer => Entities.Customer
        /// </summary>
        /// <param name="customer"> a customer object used to convert </param>
        /// <returns> return a Entities.Customer object </returns>
        public static Project1.DataAccess.Entities.Customer Map(Project1.Library.Modals.Customer customer)
        {
            return new Project1.DataAccess.Entities.Customer
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                OrderHistory = Mapper.Map(customer.OrderHistory) ?? new List<OrderHistory>(),
            };
        }
        /// <summary>
        /// A method that will convert the DataAcess.Entities.orderHistory 
        /// </summary>
        /// <param name="orderHistory"></param>
        /// <returns></returns>
        public static ICollection<OrderHistory> Map(List<Order> orderHistory)
        {
            ICollection<OrderHistory> result = new List<OrderHistory>();
            foreach(var order in orderHistory)
            {
                OrderHistory temp = new OrderHistory
                {
                    OrderId = order.OrderId,
                    CustomerId = order.CustomerId,
                    LocationId = order.LocationID,
                };
                result.Add(temp);
            }

            return result;
        }

        /// <summary>
        /// A method that convert DataAcces.Entities.OrderHistory => Library.Order
        /// </summary>
        /// <param name="orderHistory"> an order history of entity DataAccess Type</param>
        /// <returns> return a List of Library.Order </returns>
        public static List<Order> Map(ICollection<Project1.DataAccess.Entities.OrderHistory> orderHistory)
        {
            List<Order> result = new List<Order>();
            foreach(var order in orderHistory)
            {
                Order newOrder = new Order
                {
                   OrderId = order.OrderId,
                   Location = new Address
                   {
                       X = order.location.X,
                       Y = order.location.Y,
                   },
                   CustomerId = order.CustomerId,                
                   ProductDetail = Map(order.OrderHistoryDetail) ?? null,
                   ProductPrice = Mapper.Map(order.OrderHistoryDetail.ToList()) ?? null,
                   Rules = order.location.Store.Rules ?? "N/A",
                };
                result.Add(newOrder);
            }
            return result;
        }

        /// <summary>
        /// A method that converts the DataAcess.Entities.Location => Library.Modals.Location
        /// </summary>
        /// <param name="location"> DataAcess.Entities.Location to be converted to Library.Modals.Location </param>
        /// <returns> return a Library.Modals.Location</returns>
        public static Project1.Library.Modals.Location Map(Entities.Location location)
        {            
            Library.Modals.Location obj = new Project1.Library.Modals.Location
            {
                ID = location.StoreId,
                Name = location.Store.Name,
                Description = location.Store.Description,
                Rules = location.Store.Rules,
                LocationID = location.LocationId,
                Address = new Library.Modals.Address
                {
                    X = location.X,
                    Y = location.Y
                },                
            };
            return obj;
        }

        /// <summary>
        /// A method that convert Modals.Location to Entities.Location
        /// </summary>
        /// <param name="location"> Modals.Location that will be converted to Entities.Location </param>
        /// <returns> return an Entities.Location object s</returns>
        public static Project1.DataAccess.Entities.Location Map(Project1.Library.Modals.Location location)
        {
            return new DataAccess.Entities.Location
            {
                StoreId = location.ID,
                LocationId = location.LocationID,
                X = location.Address.X,
                Y = location.Address.Y,
            };
            
        }

        /// <summary>
        /// A method that will convert OrderHistoryDetail => Dictionary
        /// </summary>
        /// <param name="orderHistoryDetail"> a type OrderHistoryDetail to be converted </param>
        /// <returns> return a Dictionary library </returns>
        public static Dictionary<string, int> Map(ICollection<OrderHistoryDetail> orderHistoryDetail)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach(var order in orderHistoryDetail)            
               result.Add(order.ProductName,order.Quantity);
            
            return result;
        }


        public static Dictionary<string, double> Map(List<Entities.OrderHistoryDetail> orderHistory)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            foreach(var order in orderHistory)            
                result.Add(order.ProductName,Math.Round((double)order.Price,2));
            
            return result;
        }

        /// <summary>
        /// A method that will map between Inventory object and Dict(Library.Product,int)
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public static Dictionary<Library.Modals.Product, int> Map(ICollection<Project1.DataAccess.Entities.Inventory> inventory)
        {
            Dictionary<Library.Modals.Product, int> result = new Dictionary<Library.Modals.Product, int>();
            foreach(var item in inventory)
            {
                Library.Modals.Product pro = Mapper.Map(item.Product);
                result.Add(pro, item.Unit);
            }
            return result;
        }

        /// <summary>
        /// A method that convert Modals Prdocut => Entities.Product
        /// </summary>
        /// <param name="product"> a Modals.Product to convert</param>
        /// <returns> return a converted Modals.Product object</returns>
        public static DataAccess.Entities.Product Map(Library.Modals.Product product)
        {
            return new DataAccess.Entities.Product
            {
                ProductId = product.ProductID,
                Name = product.Name,
                Type = product.Type,
                Price = (decimal)product.Price,
                RestrictedAmount = product.RestrictedAmount,
            };
        }

        /// <summary>
        /// A method that convert Entities Product => Modals.Product
        /// </summary>
        /// <param name="product"> a Entities Product to convert</param>
        /// <returns> return a converted Entities.Product object</returns>
        public static Library.Modals.Product Map(DataAccess.Entities.Product product)
        {
            return new Library.Modals.Product
            {
                ProductID = product.ProductId,
                Name = product.Name,
                Type = product.Type,
                Price = (double)product.Price,
                RestrictedAmount = product.RestrictedAmount ?? 9999999,
            };
        }
    }
}
