using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project1.App.Models;
using Project1.Library.Interface;
using Project1.Library.Modals;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.App.Controllers
{
    public class ProductController : Controller
    {
        IStoreRepository _dbContext { get; }
        public ProductController(IStoreRepository repo) =>
            _dbContext = repo ?? throw new ArgumentNullException();

        // GET: /<controller>/
        public IActionResult Index([FromQuery] string search = null)
        {            
            if(search != null)
            {
                IEnumerable<ProductViewModel> viewModels = _dbContext.GetAllProduct().Where(x => x.Name.Contains(search)).Select(
                    m => new ProductViewModel
                    {
                        ID = m.ProductID,
                        Type = m.Type,
                        ProductName = m.Name,
                        Price = (decimal) m.Price,
                        RestrictedAmount = m.RestrictedAmount,
                    });
                return View(viewModels);
            }
            var productList = _dbContext.GetAllProduct().Select( m => new ProductViewModel
            {
                ID = m.ProductID,
                ProductName = m.Name,
                Type = m.Type,
                Price = (decimal) m.Price,
                RestrictedAmount = m.RestrictedAmount
            });
            return View(productList);                        
        }

        public ActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            if (!ModelState.IsValid)
                return View(product);
            else
            {
                if (product == null) return View("Error", new ErrorViewModel { Message = "Data Entry Empty"});
                if (_dbContext.ProductExists(product.ProductName))
                {
                    
                    return View("Error",new ErrorViewModel { Message = "Product With the same name exists."});
                }
                try
                {

                _dbContext.AddProductToRegister(product.ProductName,product.Type,product.Price,product.RestrictedAmount);
                return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("",e.Message);
                    return View(product);
                }
            }
        }

        public ActionResult Edit(int Id)
        {
            Product product = _dbContext.GetProduct(Id);
            var viewModel = new ProductViewModel
            {
                ProductName = product.Name,
                Type = product.Type,
                Price = (decimal) product.Price,
                RestrictedAmount = product.RestrictedAmount,
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int ID , [Bind("ProductName,Type,Price,RestrictedAmount")]ProductViewModel updateProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(updateProduct);
            }

            Product prod = _dbContext.GetProduct(ID);
            prod.Name = updateProduct.ProductName;
            prod.Price = (double)updateProduct.Price;
            prod.Type = updateProduct.Type;
            prod.RestrictedAmount = updateProduct.RestrictedAmount;
            _dbContext.UpdateProductFromRegister(prod);
            _dbContext.Save();
            return RedirectToAction(nameof(Index));
            
        }

        public ActionResult Delete(int ID)
        {
            Product currentProd = _dbContext.GetProduct(ID);
            ProductViewModel specificProd = new ProductViewModel
            {
                ID = currentProd.ProductID,
                ProductName = currentProd.Name,
                Type = currentProd.Type,
                Price = (decimal) currentProd.Price,
                RestrictedAmount = currentProd.RestrictedAmount,

            };
            return View(specificProd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id,[BindNever]IFormCollection collect)
        {
            bool result = _dbContext.DeleteProduct(Id);
            Console.WriteLine(result);
            return RedirectToAction(nameof(Index));
        }
    }
}
