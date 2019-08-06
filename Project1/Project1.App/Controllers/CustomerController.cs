using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.App.Models;
using Project1.Library.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.App.Controllers
{
    public class CustomerController : Controller
    {
        private IStoreRepository _repo;

        public CustomerController(IStoreRepository repo) =>
            _repo = repo ?? throw new ArgumentNullException();

        // GET: /<controller>/
        public IActionResult Index(string searching)
        {
            var allCust = _repo.GetAllCustomers();
            if(searching == null)
            {
                IEnumerable<CustomerViewModel> result = allCust.Select( m =>
                new CustomerViewModel{
                    ID = m.CustomerId,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    X = m.Address.X,
                    Y = m.Address.Y,
                });
                return View(result);
            }
            else
            {
                IEnumerable<CustomerViewModel> result = allCust.Where(c => c.FirstName.Contains(searching) || c.LastName.Contains(searching)).Select(
                    m => new CustomerViewModel
                    {
                        ID = m.CustomerId,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        X = m.Address.X,
                        Y = m.Address.Y,
                    }                    
                    );
                return View(result);
            }
        }

        
        public ActionResult OrderDetail(int ID)
        {
            if (ID <= 0) return View("Error",new ErrorViewModel { Message = "ID Invalid"});
            var result = _repo.GetAllOrders();            
            var order = result.Find(o => o.OrderId==ID);
            List<OrderDetailViewModel> OrderDetails = new List<OrderDetailViewModel>();
            foreach (var orderDetail in order.ProductDetail)
            {
                OrderDetails.Add(new OrderDetailViewModel
                {
                    Price = (decimal)order.ProductPrice[orderDetail.Key],
                    ProductName = orderDetail.Key,
                    Quantity = orderDetail.Value,
                });
            }
            TempData["CustomerID"] = order.CustomerId;
            return View("_OrderDetail",OrderDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", new ErrorViewModel { Message = "Customer With the same name exists." });
            }            
            _repo.AddCustomer(customer.FirstName,customer.LastName, new Library.Modals.Address
            {
                X = customer.X,
                Y = customer.Y,
            });
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Detail(int ID)
        {
            if (ID <= 0)
            {
                return View("Error", new ErrorViewModel { Message = "Invalid ID" });
            }
            if(!ModelState.IsValid)
            {
                return View("Error", new ErrorViewModel { Message = "Customer With the same name doesn't exist." });
            }

            var customer = _repo.GetCustomerById(ID);
            if(customer == null) return View("Error", new ErrorViewModel { Message = "Customer Doesn't Exist." });

            List<OrderViewModel> Orders = new List<OrderViewModel>();
            foreach (var order in customer.OrderHistory)
            {
                
                var location = _repo.GetLocation(order.LocationID);                
                Orders.Add(new OrderViewModel
                {
                    ID = order.OrderId,
                    CustomerName = customer.FirstName + ' ' + customer.LastName,
                    Location = "("+location.Address.X.ToString() + ','+location.Address.Y.ToString()+")",                    
                    PurchaseDate = order.PurchaseDate,
                });
            }

            CustomerViewModel detailCust = new CustomerViewModel
            {
                ID = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                X = customer.Address.X,
                Y = customer.Address.Y,
                Orderlist = Orders
            };
            return View(detailCust);
        }
    }
}
