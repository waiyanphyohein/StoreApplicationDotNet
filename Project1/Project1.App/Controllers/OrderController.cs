using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Library.Interface;
using Project1.App.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.App.Controllers
{
    public class OrderController : Controller
    {
        public IStoreRepository _repo;

        public OrderController(IStoreRepository repo)
            =>
            _repo = repo ?? throw new ArgumentNullException();

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<OrderViewModel> AllOrders = _repo.GetAllOrders().Select(m =>
            {
                List<OrderDetailViewModel> productlist = new List<OrderDetailViewModel>();

                foreach(var item in m.ProductDetail)
                {
                    OrderDetailViewModel purchase = new OrderDetailViewModel
                    {
                        ProductName = item.Key,
                        Quantity = item.Value,
                        Price = (decimal) m.ProductPrice[item.Key],
                    };
                    productlist.Add(purchase);
                }
                return new OrderViewModel
                {
                    ID = m.OrderId,
                    CustomerName = m.CustomerName,
                    Location = (m?.Location.X + " "+m?.Location.Y),
                    Purchase = productlist,
                    PurchaseDate = m.PurchaseDate
                };
            });
            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(OrderViewModel NewOrder)
        {
            if (!ModelState.IsValid)
            {
                return View(NewOrder);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
