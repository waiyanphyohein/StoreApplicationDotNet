
using Microsoft.EntityFrameworkCore;
using NLog;
using Project1.DataAccess.Entities;
using Project1.Library.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Project1.Library.Modals;

namespace Project1.DataAccess.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly Project1DbContext _dbContext;

        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private bool disposedValue = false; // To detect redundant calls

        public string message = "";

        /// <summary>
        /// A constructor that will accept dbContext as an object copy to instantiate connection
        /// </summary>
        /// <param name="dbContext"> a dbContext used to instantiate</param>
        public StoreRepository(Project1DbContext dbContext)
            => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// A method that is used to add a new customer to database.
        /// </summary>
        /// <param name="FirstName"> First name of a customer </param>
        /// <param name="LastName"> Last name of a customer </param>
        /// <param name="address"> Address object of a customer </param>
        /// <returns></returns>
        public bool AddCustomer(string FirstName, string LastName, Address address)
        {
            _logger.Info($"Calling AddCustomer From StoreRepository");
            message += $"Calling AddCustomer From StoreRepository\n";
            try
            {
                
                _logger.Info($"Checking whether Database contains the same data.");
                message += $"Checking whether Database contains the same data.\n";
                if (_dbContext != null && !_dbContext.Customer.Any(c => c.FirstName == FirstName && c.LastName == LastName))
                {
                    _logger.Info($"Newly Entered Customer data doesn't exist. Proceeding with insertion.");
                    message += $"Newly Entered Customer data doesn't exist. Proceeding with insertion.\n";
                    var temp = new DataAccess.Entities.Customer
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        X = address.X,
                        Y = address.Y,
                    };
                    _dbContext.Customer.Add(temp);
                    _dbContext.SaveChanges();

                    _logger.Info($"Successfully Added New Customer to Database");
                    message += $"Successfully Added New Customer to Database\n";
                    return true;
                }
                else
                {
                    _logger.Warn($"Data Already Existed.");
                    message += $"Data Already Existed.";
                    return false;
                }
            }
            catch(Exception e)
            {
                _logger.Error($"ERROR: {e.Message} <dbContext IS NULL>");
                message += $"ERROR: {e.Message} <dbContext IS NULL>\n";
                return false;
            }
            
        }

        public bool AddCustomer(Library.Modals.Customer NewCustomer)
        {
            _logger.Info($"Checking if NewCustomer is null or not.");
            
            try
            {                
                if(_dbContext.Customer.Any(c => c.FirstName == NewCustomer.FirstName && c.LastName == NewCustomer.LastName))
                {
                    _logger.Warn($"Data Already Exists In Database. Terminating the process...");
                    message += $"Data Already Exists In Database. Terminating the process...\n";
                    return false;
                }
                else
                {
                    Entities.Customer customer = Mapper.Map(NewCustomer);
                    _dbContext.Customer.Add(customer);
                    _dbContext.SaveChanges();
                    _logger.Info($"Successfully Added New Customer. (Method: AddCustomer(Modals.Customer))");
                    message += "Successfully Added New Customer.\n";
                    return true;
                }
                
            }
            catch(ArgumentNullException e)
            {
                _logger.Warn($"Error : {e.Message}");
                message += $"Error : {e.Message}\n";
                return false;
            }
            catch(Exception e)
            {
                _logger.Warn($"Unexcepted Error: {e.Message}");
                message += $"Unexcepted Error : {e.Message}\n.";
                return false;
            }            
        }

        /// <summary>
        /// A method used to delete a customer data from database
        /// </summary>
        /// <param name="CustomerId"> a customer Id to search for Customer row</param>
        /// <returns> boolean that return whether the operation is successful or not. </returns>
        public bool DeleteCustomerById(int CustomerId)
        {
            _logger.Info($"Checking if Customer exists in the database by CustomerId.");
            try
            {
                if (_dbContext.Customer.Any(c => c.CustomerId == CustomerId))
                {
                    _logger.Info($"An existing record in Customer table found.");
                    message += $"An existing record in Customer table found.\n";

                    // DELETING THE RECORD IN PROGRESS
                    var ToBeDeleted = _dbContext.Customer.Find(CustomerId);
                    _dbContext.Customer.Remove(ToBeDeleted);
                    _dbContext.SaveChanges();

                    _logger.Info($"Record Deleted Succesfully.");
                    message += "Record Deleted Successfully.\n";
                    return true;
                }
                else
                {
                    _logger.Warn("Record Not Found in Database");
                    message += "Record Not Found in Database.\n";
                    return false;
                }
            }

            catch(InvalidOperationException e)
            {
                _logger.Warn($"Invalid CustomerId: {e.Message}.");
                message += "Invalid CustomerId: {e.Message}.\n";
                return false;
            }

            catch(Exception e)
            {
                _logger.Warn($"Unexpected Exception: {e.Message}");
                message += $"Unexpected Exception: {e.Message}\n.";
                return false;
            }
        }        

        public List<Library.Modals.Order> GetAllOrders()
        {
            IQueryable<OrderHistory> orderhist = _dbContext.OrderHistory.Include(oh => oh.location).Include(oh => oh.OrderHistoryDetail).Include(oh => oh.Customer);

            List<Order> orderList = new List<Order>();
            foreach(var eachOrder in orderhist)
            {
                Order newOrder = new Order
                {
                    CustomerId = eachOrder.CustomerId,
                    OrderId = eachOrder.OrderId,
                    CustomerName = eachOrder.Customer.FirstName + ' ' + eachOrder.Customer.LastName,
                    Location = new Address
                    {
                        X = eachOrder.location.X,
                        Y = eachOrder.location.Y,
                    },
                    ProductDetail = new Dictionary<string, int>(),
                    ProductPrice = new Dictionary<string, double>(),
                };
                foreach(var orderIn in eachOrder.OrderHistoryDetail)
                {
                    newOrder.ProductDetail.Add(orderIn.ProductName, orderIn.Quantity);
                    newOrder.ProductPrice.Add(orderIn.ProductName, (double) orderIn.Price);
                }
                orderList.Add(newOrder);
            }
            return orderList;
        }

        public bool AddLocation(int StoreId = -1, int X = 0, int Y = 0)
        {
            _logger.Info($"Checking if the location exists or not.");
            if (StoreId <= 0 || !_dbContext.Store.Any(s => s.StoreId == StoreId))
            {
                _logger.Warn("Invalid StoreID. Please make sure you have valid StoreId to add location.");
                message += "Invalid StoreID. Please make sure you have valid StoreId to add location.\n";
                return false;
            }
            try
            {
                if (_dbContext.Location.Any(l => l.StoreId == StoreId && l.X == X && l.Y == Y))
                {
                    _logger.Warn("Location already exists in the Database");
                    message += "Location already exists in the Database\n";
                    return false;
                }
                else
                {
                    _logger.Info("New Location is now in the process of insertion.");
                    message += "New Location is now in the process of insertion.\n";

                    Entities.Location newLoct = new Entities.Location
                    {
                        StoreId = StoreId,
                        X = X,
                        Y = Y,
                    };

                    _dbContext.Location.Add(newLoct);
                    _dbContext.SaveChanges();

                    _logger.Info("Location is added successfully.");
                    message += "Location is added successfully.\n";

                    return true;
                }
            }
            catch(ArgumentNullException e)
            {
                _logger.Warn($"Input values requirement not fulfilled. Message: {e.Message}");
                message += "Input values requirement not fulfilled.\n";
                return false;
            }
            catch(Exception e)
            {
                _logger.Warn($"Unexpected Error Occurred: {e.Message}");
                message += $"Unexpected Error Occurred: {e.Message}\n";
                return false;
            }
        }

        public bool AddLocation(Library.Modals.Store store, int X, int Y)
        {
            _logger.Info("Checking whether or not a new location can be added.");
            message += "Checking whether or not a new location can be added.\n";
            if (store == null)
            {
                _logger.Warn("Store Object Is Null.");
                message += "Store Object Is Null.\n";
                return false;
            }

            try
            {
                if (store != null && !_dbContext.Location.Any(l => l.StoreId == store.ID && l.X == X && l.Y == Y))
                {
                    _logger.Info("Existing Record found. Terminating with Adding Location.");
                    message += "Existing Record found. Terminating with Adding Location.\n";
                    return false;
                }
                else
                {
                    _logger.Info("Location Record Not Found In Database. Proceeding with insertion.");
                    message += "Location Record Not Found In Database. Proceeding with insertion.\n";
                    Entities.Location newLoct = new Entities.Location
                    {
                        StoreId = store.ID,
                        X = X,
                        Y = Y,
                    };
                    _dbContext.Location.Add(newLoct);
                    _dbContext.SaveChanges();

                    // DEBUGGING PURPOSE
                    _logger.Info("New Location Added Successfully.");
                    message += "New Location Added Successfully.\n";

                    return true;
                }
            }
            catch (ArgumentNullException e)
            {
                _logger.Warn($"Input Values Invalid: {e.Message}");
                message += $"Input Values Invalid: {e.Message}\n";
                return false;
            }
            catch (Exception e)
            {
                _logger.Warn($"Unexpected Error Occur: {e.Message}.");
                message += $"Unexpected Error Occur: {e.Message}.\n";
                return false;
            }
        } 

        public IEnumerable<Library.Modals.Product> GetAllProduct()
        {
            IQueryable<Entities.Product> productList = _dbContext.Product.AsNoTracking();            
            return productList?.Select(Mapper.Map);
        }
       
        public bool AddLocation(Library.Modals.Location location)
        {
            _logger.Info("Checking if location exists in database or not.");
            message += "Checking if location exists in database or not.\n";
            if(location == null)
            {
                _logger.Warn("Location Input is Empty.");
                message += "Location Input is Empty.\n";
                return false;
            }
            try
            {
                if (!_dbContext.Location.Any(l => l.LocationId == location.LocationID || (l.X == location.Address.X && l.Y == location.Address.Y && l.StoreId == location.ID))) 
                {
                    _logger.Info("Existing Record Not Found. Proceeding with adding a new location.");
                    message += "Existing Record Not Found. Proceeding with adding a new location.\n";

                    _dbContext.Location.Add(Mapper.Map(location));
                    _dbContext.SaveChanges();

                    _logger.Info("Location Created Successfully.");
                    message += "Location Created Successfully.\n";
                    return true;
                }                
            }
            catch(Exception e)
            {
                _logger.Warn($"Unexpected Error Caught: {e.Message}");
                message += $"Unexpected Error Caught: { e.Message}\n";
                return false;
            }
            _logger.Warn("Location already exists.");
            message += "Location already exists.\n";
            
            return false;
        }

        public IEnumerable<Library.Modals.Location> GetAllLocation()
        {
            _logger.Info("Getting All Location Exist in Database.");
            message += "Getting All Location Exist in Database.\n";
            IQueryable<Entities.Location> list = _dbContext.Location.Include(l => l.Store);            
            return list.Select(Mapper.Map) ?? null;
        }

        public bool AddProductToInventory(int LocationId = -1, int productId = -1, int amount = -1)
        {
            _logger.Info("Adding Product to Location's Inventory.");
            message +=  "Adding Product to Location's Inventory.\n";
            if(LocationId <= 0) {
                _logger.Warn("Invalid Location Search. Location Doesn't Exist.");
                message += "Invalid Location Search. Location Doesn't Exist.\n";
                return false;
            }
            if(productId <= 0){
                _logger.Warn("Invalid Product Entry. Product Doesn't Exist.");
                message += "Invalid Product Entry. Product Doesn't Exist.\n";
                return false;
            }            
            try{
                // Three tables include with .ThenInclude();
                // var dbLocation = _dbContext.Location.Include(l => l.Inventory).ThenInclude(l => l.Product).Where(l => l.LocationId == LocationId);                
                var dbInventory = _dbContext.Inventory.Include(i => i.Location).Include(i => i.Product).Where(i => i.LocationId == LocationId);

                if(dbInventory == null) {
                    _logger.Warn("Location Not Found.");
                    message += "Location Not Found.\n";
                    return false;
                }
                else{
                    // if(dbLocation.Any(l => l.Inventory.First(i => i.ProductId == productId)!= null))
                    if(dbInventory.Any(i => i.ProductId == productId))
                    {
                        _logger.Info("Product Founnd in Inventory. Restocking the product.");
                        message += "Product Founnd in Inventory. Restocking the product.\n";
                        
                        var invent = dbInventory.First(i => i.ProductId == productId);
                        invent.Unit += amount;
                        _dbContext.SaveChanges();

                        _logger.Info("Product Restock Successful.");
                        message += "Product Restock Successful.\n";
                        return true;
                    }
                    else{
                        if(!_dbContext.Product.Any(p => p.ProductId == productId)){
                            _logger.Warn("Invalid Product Access");
                            message += "Invalid Product Access\n";
                            return false;
                        }
                        _dbContext.Inventory.Add(
                            new Inventory{
                                ProductId = productId,
                                LocationId = LocationId,
                                Unit = amount,   
                            }
                        );
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
            }
            catch(Exception e){
                _logger.Warn($"Unexpected Error: {e.Message}.");
                message += $"Unexpected Error: {e.Message}.\n";
                return false;
            }                        
        }

        public bool AddProductToRegister(string name = null, string type = null, decimal price = -1, int restricterdAmount = -1)
        {
            if (name == null || price == -1)
            {
                _logger.Warn("Required Field Not FulFilled");
                return false;
            }
            if (_dbContext.Product.Any(p => p.Name == name))
            {
                _logger.Warn("Product With Same Name Already Exists.");
                return false;
            }
            try
            {
                Entities.Product newProd = new Entities.Product
                {
                    Name = name,
                    Type = type,
                    Price = price,
                    RestrictedAmount = restricterdAmount,
                };
                _dbContext.Product.Add(newProd);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.Warn($"Unexpected Error Occurred: {e.Message}");
                message += $"Unexpected Error Occurred: {e.Message}\n";
                return false;
            }
        }

        public bool AddStore(string Name = null, string Description = null, string Rules = null)
        {
            throw new NotImplementedException();
        }

        public bool DeleteLocationById(int LocationId = -1)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStore(string Name = null)
        {
            throw new NotImplementedException();
        }

        
        public bool DeleteCustomer(string FirstName, string LastName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Modals.Customer> GetAllCustomers()
        {
            IQueryable<Entities.Customer> customerList = _dbContext.Customer;
            var customerList2 = customerList.ToList();

            List<Library.Modals.Customer> customers = new List<Library.Modals.Customer>();

            foreach(var item in customerList2)
            {
                var eachone = new Library.Modals.Customer
                {
                    CustomerId = item.CustomerId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Address = new Address
                    {
                        X = item.X,
                        Y = item.Y,
                    }
                };
                customers.Add(eachone);
            }

            //var result = customerList.Select(m => new Library.Modals.Customer
            //{
            //    CustomerId = m.CustomerId,
            //    FirstName = m.FirstName,
            //    LastName = m.LastName,
            //    Address = new Address
            //    {
            //        X = m.X,
            //        Y = m.Y,
            //    },                
            //}) ;
            return customers;
        }

        public Library.Modals.Customer GetCustomer(string FirstName = null, string LastName = null)
        {
            _logger.Info($"Searching for a customer by their firstname and lastname");
            if (FirstName == null && LastName == null)
            {
                _logger.Warn($"Input is null. Customer: {FirstName} {LastName}");
                return null;
            }

            IQueryable<Entities.Customer> customersList = _dbContext.Customer.Include(x => x.OrderHistory).AsNoTracking();
            Entities.Customer outcome = customersList.First(c => c.FirstName == FirstName && c.LastName == LastName);
            if (outcome != null)
            {
                _logger.Info("Record Is Found and Mapping To Modals.Customer Object.");
                Library.Modals.Customer result = Mapper.Map(outcome);
                _logger.Info("Mapping Successfull.");
                return result;
            }
            else
            {
                _logger.Warn($"Record Not Found. Customer: {FirstName} {LastName}");
                return null;
            }
        }

        public Library.Modals.Customer GetCustomerById(int Id = -1)
        {
            _logger.Info($"Searching for a customer by their Id.");
            if (Id <= 0)
            {
                _logger.Warn($"Invalid ID. CustomerID: {Id}.");
                return null;
            }
            if (_dbContext.Customer.Any(c => c.CustomerId == Id))
            {
                _logger.Info("Record is Found And Mapping to Modals.Customer");
                var cust = (_dbContext.Customer.Include(c => c.OrderHistory).ThenInclude(o => o.OrderHistoryDetail).FirstOrDefault(c => c.CustomerId == Id));

                List<Library.Modals.Order> ListOfOrders = new List<Order>();
                foreach (var eachOrder in cust.OrderHistory)
                {
                    Dictionary<string, int> productPurchase = new Dictionary<string, int>();
                    Dictionary<string, double> productPrice = new Dictionary<string, double>();

                    foreach (var item in eachOrder.OrderHistoryDetail)
                    {
                        productPurchase.Add(item.ProductName,item.Quantity);
                        productPrice.Add(item.ProductName,(double)item.Price);
                    }
                    var locat = _dbContext.Location.Find(eachOrder.LocationId);
                    ListOfOrders.Add(new Order
                    {
                        OrderId = eachOrder.OrderId,
                        CustomerId = eachOrder.CustomerId,
                        LocationID = eachOrder.LocationId,
                        CustomerName = eachOrder.Customer.FirstName + ' ' + eachOrder.Customer.LastName,                        
                        Location = new Address {
                           X = locat.X,
                           Y = locat.Y,
                        },
                        ProductDetail = productPurchase,
                        ProductPrice = productPrice,
                        PurchaseDate = eachOrder.DateModified
                    });
                }

                Library.Modals.Customer result = new Library.Modals.Customer
                {
                    CustomerId = cust.CustomerId,
                    FirstName = cust.FirstName,
                    LastName = cust.LastName,
                    Address= new Address
                    {
                        X = cust.X,
                        Y = cust.Y
                    },
                    OrderHistory = ListOfOrders
                };
                _logger.Info("Mapping Successfully");                
                return result;
            }
            else
            {
                _logger.Warn($"ID Not Found. CustomerID: {Id}");
                return null;
            }
        }

        public bool DeleteProduct(int Id)
        {
            if(!_dbContext.Product.Any(p => p.ProductId== Id))
            {
                _logger.Warn("Product With Same ID Not Found");
                message += ("Product With Same ID Not Found\n");
                return false;
            }
            try
            {
                _logger.Info("Deleting Product.");
                message += ("Deleting Product.\n");
                Entities.Product prod = _dbContext.Product.Find(Id);
                _dbContext.Product.Remove(prod);
                _dbContext.SaveChanges();
                _logger.Info("Product Deleted.");
                message += "Product Deleted.\n";
                return true;
            }
            catch (Exception e)
            {
                _logger.Warn("Unexpected Error: "+e.Message);
                message += "Unexpected Error: " + e.Message + "\n";
                return false;
            }
        }

        public Library.Modals.Product GetProduct(string name = null)
        {
            _logger.Info("Searching for a product");
            if (name == null) return null;
            if (_dbContext.Product.Any(p => p.Name == name))
            {
                _logger.Info("Found A Product.");
                Entities.Product searchProduct = _dbContext.Product.First(p => p.Name == name);
                return Mapper.Map(searchProduct) ?? null;
            }
            else
                return null;
        }
        public ICollection<Library.Modals.Location> GetLocation(Library.Modals.Product product, int amount)
        {
            IQueryable<Entities.Inventory> inven = _dbContext.Inventory.Include(l => l.Location).Include(l=> l.Product).Include(l=>l.Location.Store);
            inven  = inven.Where(i=> i.ProductId == product.ProductID && i.Unit >= amount);
            List<Library.Modals.Location> result = new List<Library.Modals.Location>();
            foreach (var item in inven)
            {
                result.Add(Mapper.Map(item.Location));
            }
            return result;
        }

        public Dictionary<Library.Modals.Product,int> GetListOfProductsInInventory(int locationId = -1)
        {
            IQueryable<Entities.Location> inven = _dbContext.Location.Include(l => l.Inventory).ThenInclude(i => i.Product).Include(l => l.Store);
            Console.WriteLine(inven.Any(i => i.LocationId == locationId));
            var location = inven.FirstOrDefault(i => i.LocationId == locationId);
            Dictionary<Library.Modals.Product, int> list = new Dictionary<Library.Modals.Product, int>();
            foreach(var item in location.Inventory)
            {
                list.Add(Mapper.Map(item.Product),item.Unit);
            }
            return list;
        }

        public bool AddOrder(Library.Modals.Order order,Library.Modals.Customer client)
        {
            IQueryable<Entities.Location> inven = _dbContext.Location.Include(l => l.Inventory).Include(l => l.Store);
            
            Entities.Customer customer = _dbContext.Customer.First(c => (c.FirstName+ ' ' + c.LastName == order.CustomerName));
            if(customer == null)
            {
                Entities.Customer AddNewCustomer = new Entities.Customer
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    X = client.Address.X,
                    Y = client.Address.Y,
                };
                _dbContext.Customer.Add(AddNewCustomer);
                _dbContext.SaveChanges();
            }

            var location = inven.FirstOrDefault(i => i.LocationId == order.LocationID);
            //Dictionary<Library.Modals.Product, int> list = new Dictionary<Library.Modals.Product, int>();
            foreach (var inventory in location.Inventory)
            {                
                foreach (var item in order.ProductDetail)
                {
                    if(inventory.Product.Name == item.Key)
                    {
                        Inventory willModify = _dbContext.Inventory.Find(inventory.InventoryId);
                        willModify.Unit -= item.Value;
                        _dbContext.SaveChanges();
                    }
                }
            }
            customer = _dbContext.Customer.First(c => (c.FirstName + ' ' + c.LastName == order.CustomerName));
            IQueryable<OrderHistory> orderHist = _dbContext.OrderHistory.Include(o => o.location).Include(o => o.OrderHistoryDetail).Include(o => o.Customer);

            OrderHistory NewOrder = new OrderHistory
            {
                CustomerId = customer.CustomerId,
                LocationId = location.LocationId,
            };
            _dbContext.OrderHistory.Add(NewOrder);
            

            //_dbContext.OrderHistoryDetail.Add();
            _dbContext.SaveChanges();
            return false;
        }
        public IEnumerable<Library.Modals.Product> GetListOfProductsInInventory(string storeName = null)
        {
            var list = _dbContext.Inventory
                        .Include(i => i.Product)
                        .Include(i => i.Location)
                        .ThenInclude(l => l.Store)
                        .Where(i => i.Location.Store.Name == storeName)
                        .AsNoTracking();
            List<Entities.Product> listOfAvailableProduct = new List<Entities.Product>();
            foreach (var item in list)            
                listOfAvailableProduct.Add(item.Product);
            return listOfAvailableProduct.Select(Mapper.Map);
        }

        public IEnumerable<Library.Modals.Location> GetLocations(int X, int Y)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Modals.Location> GetStores(string store = null, Address currentLocation = null)
        {
            throw new NotImplementedException();
        }

        public bool ProductExists(string name = null)
        {
            return _dbContext.Product.Any(p => p.Name == name);
        }
        public bool RemoveProductFromInventory(int LocationId = -1, int productId = -1, int amount = -1)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLocation(Library.Modals.Location location)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStore(Library.Modals.Store store)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~StoreRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            
        }

        public bool RemoveProductFromRegister(int productId = -1)
        {
            if(productId <= 0) {
                _logger.Warn("Product ID Invalid. ");
                message += "Product ID Invalid. \n";
                return false;
            }
            else{
                if(!_dbContext.Product.Any(p => p.ProductId == productId)){
                    _logger.Warn("Product With Same Id not Found.");
                    message += "Product With Same Id not Found.\n";
                    return false;
                }
                else{
                    
                }
            }
            return false;
        }

        public bool UpdateProductFromRegister(Library.Modals.Product product = null)
        {
            if (!_dbContext.Product.Any(p => p.ProductId == product.ProductID)) return false;
            try
            {
                _logger.Info("Modifying An Existing Product.");
                DataAccess.Entities.Product currentProd = _dbContext.Product.Find(product.ProductID);
                DataAccess.Entities.Product newProduct = Mapper.Map(product);
                _dbContext.Entry(currentProd).CurrentValues.SetValues(newProduct);
                return true;
            }
            catch (Exception e)
            {
                _logger.Warn($"Update Failed. Error: {e.Message}");
                message += $"Update Failed. Error: {e.Message}\n";
                return false;
            }
        }

        public Library.Modals.Location GetLocation(string name, int X, int Y)
        {
            try
            {
                if (name == null) return null;
                Entities.Location newLocation = _dbContext.Location.Include(l => l.Store).Include(l => l.Inventory).FirstOrDefault(l =>l.X == X && l.Y == Y);
                return Mapper.Map(newLocation);
            }
            catch (Exception e)
            {
                _logger.Warn($"Unexpected Error: {e.Message}");
                return null;
            }
        }

        public bool PlaceOrder(Order NewOrder)
        {
            _logger.Info("Placing Order for a customer. ");
            try{
                
                var dbCustomer = _dbContext.Customer.Find(NewOrder.CustomerId);
                var dbLocation = _dbContext.Location.Find(NewOrder.LocationID);
                var dbInventory = _dbContext.Inventory
                                    .Where(i => i.LocationId == NewOrder.LocationID)
                                    .Include(i => i.Product);
                if (dbInventory == null) return false;
                
                var dbOrder = new Entities.OrderHistory{
                    Customer = dbCustomer,
                    location = dbLocation,
                };
                
                foreach(var item in NewOrder.ProductDetail)
                {
                    var temp = dbInventory.FirstOrDefault(i => i.Product.Name==item.Key);
                    if (item.Value > temp.Unit || item.Value > temp.Product.RestrictedAmount) return false;
                    temp.Unit -= item.Value;
                    dbOrder.OrderHistoryDetail.Add(new OrderHistoryDetail
                    {
                        ProductName = item.Key,
                        Quantity = item.Value,
                        Price = (decimal)NewOrder.ProductPrice[item.Key],
                    });
                }

                // Registering the order in Customer, Location and OrderHistory
                _dbContext.OrderHistory.Add(dbOrder);
                _dbContext.SaveChanges();
                return true;
            }
            catch(ArgumentNullException e){
                _logger.Warn($"Error: Order Input Empty [ Message: {e.Message}]");
                return false;
            }
            catch(Exception e){
                _logger.Warn($"Unexpected Exception: {e.Message}");
                return false;
            }
            
        }


        public Library.Modals.Product GetProduct(int ProductId)
        {
            if (_dbContext.Product.Any(p => p.ProductId == ProductId))
                return Mapper.Map(_dbContext.Product.Find(ProductId));
            return null;
        }

        public void Save()
        {
            _logger.Info($"Saving Changes To Database.");
            _dbContext.SaveChanges();
        }

        public Library.Modals.Location GetLocation(int Id)
        {
            var result = _dbContext.Location.Include(l => l.Store).Include(l=>l.OrderHistory);
            if (Id <= 0) return null;
            else
            {
                return Mapper.Map(result.FirstOrDefault(l => l.LocationId == Id));
            }
        }

        #endregion

    }
}
