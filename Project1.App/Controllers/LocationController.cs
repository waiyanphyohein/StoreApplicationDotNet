using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Library.Interface;
using Project1.App.Models;
using Microsoft.AspNetCore.Http;
using Project1.Library.Modals;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.App.Controllers
{
    public class LocationController : Controller
    {

        IStoreRepository _repo;
        public LocationController(IStoreRepository repo) =>
            _repo = repo ?? throw new ArgumentNullException();

        // GET: /<controller>/
        public IActionResult Index(int CustomerID)
        {
            var allLocation = _repo.GetAllLocation();

            TempData["CustomerID"] = CustomerID;

            IEnumerable<LocationViewModel> result = allLocation.Select(m =>
            {
                // Parsing Location.Inventory into LocationViewModel.Inventory
                Dictionary<ProductViewModel, int> inven = new Dictionary<ProductViewModel, int>();
                foreach (var item in allLocation)
                {
                    foreach (var element in item.Inventory)
                    {
                        var product = new ProductViewModel
                        {
                            ID = element.Key.ProductID,
                            ProductName = element.Key.Name,
                            Price = (decimal) element.Key.Price,
                            RestrictedAmount = element.Key.RestrictedAmount,
                            Type = element.Key.Type,
                        };
                        inven.Add(product, element.Value);
                    }
                }
                // Returning a new locationViewModel
                return new LocationViewModel {
                    StoreName = m.Name,
                    LocationID = m.LocationID,
                    X = m.Address.X,
                    Y = m.Address.Y,
                    Inventory = inven,
                };
            });

            return View(result);
        }

        public ActionResult Select(int LocationID,int CustomerID)
        {
            var location = _repo.GetListOfProductsInInventory(LocationID);
            List<InventoryViewModel> inventory = new List<InventoryViewModel>();
            foreach (var item in location)
            {
                InventoryViewModel newItem = new InventoryViewModel
                {
                    ProductID = item.Key.ProductID,
                    ProductName = item.Key.Name,
                    Price = (decimal) item.Key.Price,
                    RestrictedAmount = item.Key.RestrictedAmount,
                    AvailableUnits = item.Value,                    
                };
                inventory.Add(newItem);
            }
            
            TempData["LocationID"] = LocationID;
            TempData["CustomerID"] = CustomerID;
            return View(inventory);
        }

        

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int ID)
        {
            var local = _repo.GetLocation(ID);
            LocationViewModel result = new LocationViewModel
            {
                LocationID = local.LocationID,
                X = local.Address.X,
                Y = local.Address.Y,
            };
            return View(result);
        }

        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrder(IFormCollection list,int LocationID,int CustomerID)
        {
            if (!ModelState.IsValid) return RedirectToActionPermanent("Index","Home");
            List<string> amount = new List<string>();
            List<string> productIdList = new List<string>();
            List<string> priceList = new List<string>();
            foreach(var item in list)
            {
                if (item.Key == "SelectAmount")
                    amount = item.Value.ToList();
                else if (item.Key == "ProductID")
                    productIdList = item.Value.ToList();
                else if (item.Key == "Price")
                    priceList = item.Value.ToList();
                else
                    break;
            }

            var allProds = _repo.GetAllProduct();            
            Dictionary<string, int> prodDetail = new Dictionary<string, int>();
            Dictionary<string, double> prodPrice = new Dictionary<string, double>();

            for (int i = 0; i < amount.Count; i++)
            {
                if (int.Parse(amount[i]) == 0) continue;
                Product prod = allProds.First(p => p.ProductID == int.Parse(productIdList[i]));
                prodDetail.Add(prod.Name,int.Parse(amount[i]));
                prodPrice.Add(prod.Name,double.Parse(priceList[i]));
            }

            Order newOrder = new Order
            {
                CustomerId = CustomerID,
                LocationID = LocationID,
                ProductDetail = prodDetail,
                ProductPrice = prodPrice
            };

            bool result = _repo.PlaceOrder(newOrder);
            if (!result) return View("Error", new ErrorViewModel {Message = "Operation Failed"});

            return RedirectToActionPermanent("Index","Home");
        }

        public ActionResult IndexOrder()
        {
            var allLocation = _repo.GetAllLocation();
            

            IEnumerable<LocationViewModel> result = allLocation.Select(m =>
            {
                // Parsing Location.Inventory into LocationViewModel.Inventory
                Dictionary<ProductViewModel, int> inven = new Dictionary<ProductViewModel, int>();
                foreach (var item in allLocation)
                {
                    foreach (var element in item.Inventory)
                    {
                        var product = new ProductViewModel
                        {
                            ID = element.Key.ProductID,
                            ProductName = element.Key.Name,
                            Price = (decimal)element.Key.Price,
                            RestrictedAmount = element.Key.RestrictedAmount,
                            Type = element.Key.Type,
                        };
                        inven.Add(product, element.Value);
                    }
                }
                // Returning a new locationViewModel
                return new LocationViewModel
                {
                    StoreName = m.Name,
                    LocationID = m.LocationID,
                    X = m.Address.X,
                    Y = m.Address.Y,
                    Inventory = inven,
                };
            });

            return View(result);
        }

        public ActionResult Detail(int LocationID)
        {
            if (LocationID <= 0)
            {
                return View("Error", new ErrorViewModel { Message = "Invalid ID" });
            }

            if (!ModelState.IsValid)
            {
                return View("Error", new ErrorViewModel { Message = "Customer With the same name doesn't exist." });
            }

            var location = _repo.GetLocation(LocationID);
            if (location == null) return View("Error", new ErrorViewModel { Message = "Customer Doesn't Exist." });

            List<OrderViewModel> Orders = new List<OrderViewModel>();
            foreach (var order in location.OrderHistory)
            {

                var customer = _repo.GetCustomerById(order.CustomerId);
                Orders.Add(new OrderViewModel
                {
                    ID = order.OrderId,
                    CustomerName = customer.FirstName + ' ' + customer.LastName,
                    Location = "(" + location.Address.X.ToString() + ',' + location.Address.Y.ToString() + ")",
                    PurchaseDate = order.PurchaseDate,
                });
            }            
            LocationViewModel detailLocation = new LocationViewModel
            {
                LocationID = location.LocationID,
                StoreName = location.Name,
                X = location.Address.X,
                Y = location.Address.Y,
                OrderHistory = Orders
            };
            return View(detailLocation);
        }
    }
}
