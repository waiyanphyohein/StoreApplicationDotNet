using System;
using Project1.Library.Modals;
using System.Collections.Generic;
namespace Project1.Library.Interface
{
    public interface IStoreRepository: IDisposable
    {

        /// <summary>
        /// a method that will add a new customer object to Database.
        /// </summary>
        /// <param name="FirstName"> First name of a customer </param>
        /// <param name="LastName"> Last Name of a customer </param>
        /// <param name="address"> Address of a customer </param>
        bool AddCustomer(string FirstName,string LastName,Address address);

        /// <summary>
        /// A method that add a new customer using ModalsCustomer object
        /// </summary>
        /// <param name="NewCustomer"> A modals.cusotmer object that is used to add new customer info into database</param>
        /// <returns> boolean value that indicates operations session. true if success and false if failure </returns>
        bool AddCustomer(Project1.Library.Modals.Customer NewCustomer);

        /// <summary>
        /// A method that delete a customer data from customer table using customer id 
        /// </summary>
        /// <param name="CustomerId"> a customer id used to naviagte a row to delete customer data</param>
        /// <returns> boolean value that indicates operations session. true if success and false if failure </returns>
        bool DeleteCustomerById(int CustomerId);

        /// <summary>
        /// A method that delete a customer by first name and last name
        /// </summary>
        /// <param name="FirstName"> a customer's first name </param>
        /// <param name="LastName"> a customer's last name </param>
        /// <returns></returns>
        bool DeleteCustomer(string FirstName, string LastName);

        /// <summary>
        /// A method that save changes to database.
        /// </summary>
        void Save();

        bool DeleteProduct(int Id);

        /// <summary>
        /// A method that a new location to database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        bool AddLocation(Store store,int X, int Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        bool AddLocation(Location location = null);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Location> GetAllLocation();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        ICollection<Location> GetLocation(Product product, int amount);

        /// <summary>
        /// A method that gets a location by ID
        /// </summary>
        /// <param name="ID"> Location ID </param>
        /// <returns> return Location Object </returns>
        Location GetLocation(int ID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        Location GetLocation(string name, int X, int Y);

        /// <summary>
        /// A method that return a product by Id
        /// </summary>
        /// <param name="Id"> product Id</param>
        /// <returns> Entity Product Object </returns>
        Product GetProduct(int ProductId);

        /// <summary>
        /// A method that returns a product by name.
        /// </summary>
        /// <param name="name"> a product name </param>
        /// <returns> Return a enitity.product </returns>
        Product GetProduct(string name = null);



        /// <summary>
        /// A method that adds an order to the list.
        /// </summary>
        /// <param name="order"> a new order that will be placed in the DB </param>
        /// <param name="customer"> a customer who places an order. </param>
        /// <returns></returns>
        bool AddOrder(Order order,Customer customer);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Order> GetAllOrders();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewOrder"></param>
        /// <returns></returns>
        bool PlaceOrder(Order NewOrder);

        /// <summary>
        /// a method that returns all product in database.
        /// </summary>
        /// <returns> list of products. </returns>
        IEnumerable<Product> GetAllProduct();
        /// <summary>
        /// a method that returns all stores nearby user's current location with search input
        /// </summary>
        /// <param name="store"> a store search input from user </param>
        /// <param name="currentLocation"> an object that stores X and Y Coordinate </param>
        /// <returns> a list of locations of store nearby </returns>
        IEnumerable<Location> GetStores(string store = null,Address currentLocation = null);

        /// <summary>
        /// a method that will return all locations near current location of user
        /// </summary>
        /// <param name="X"> user's current X coordinate </param>
        /// <param name="Y"> user's current Y coordinate </param>
        /// <returns></returns>
        IEnumerable<Location> GetLocations(int X, int Y);

        /// <summary>
        /// a method that will return a list of all customers from DB. (FOR DEBUGGING PURPOSE)
        /// </summary>
        /// <returns> List of Customers who are registered in the DB </returns>
        IEnumerable<Customer> GetAllCustomers();

        /// <summary>
        /// A method that will get all products that are currently in the inventory.
        /// </summary>
        /// <param name="locationId"> a location id for searching inventory specific </param>
        /// <returns> a list of products that are in location's inventory </returns>
        Dictionary<Product,int> GetListOfProductsInInventory(int locationId = -1);

        /// <summary>
        /// Get a list of products available under the store. (It will return
        /// all products from the differnet locations that are under the same store
        /// </summary>
        /// <param name="storeName"> the name of store or brand </param>
        /// <returns> a list of products that are under the same store. </returns>
        IEnumerable<Product> GetListOfProductsInInventory(string storeName = null);


        /// <summary>
        /// a method that return a customer object by their First Name and Last Name
        /// </summary>
        /// <param name="FirstName"> a customer's first name </param>
        /// <param name="LastName"> a customer's last name </param>
        /// <returns> a customer object </returns>
        Customer GetCustomer(string FirstName = null, string LastName = null);

        /// <summary>
        /// a method that returns the customer object by their CustomerId
        /// </summary>
        /// <param name="Id"> a customer's Id</param>
        /// <returns> a customer object </returns>
        Customer GetCustomerById(int Id = -1);

        /// <summary>
        /// A method that will add a new store inside DB.
        /// </summary>
        /// <param name="Name"> New store's name </param>
        /// <param name="Description"> a description of a store</param>
        /// <param name="Rules"> rules of a store. </param>
        bool AddStore(string Name = null,string Description = null, string Rules = null);

        /// <summary>
        /// a method that will delete a store from Db.
        /// </summary>
        /// <param name="Name"> a name of store to be deleted </param>
        bool DeleteStore(string Name = null);

        /// <summary>
        /// a method that will update an existing store info with a newly input store object data.
        /// </summary>
        /// <param name="store">a store object that contains all latest info about store </param>
        bool UpdateStore(Store store);

        /// <summary>
        /// a method that will add a new location to DB.
        /// </summary>
        /// <param name="StoreId"> a store Id that is connected to this location </param>
        /// <param name="X"> X corrdinate </param>
        /// <param name="Y"> Y coordinate </param>
        bool AddLocation(int StoreId = -1, int X = 0, int Y = 0);

        /// <summary>
        /// A method that remove a location by Id
        /// </summary>
        /// <param name="LocationId"> a LocationID that is used to navigate location</param>
        bool DeleteLocationById(int LocationId = -1);

        /// <summary>
        /// a method that will update the location info based on current location object.
        /// </summary>
        /// <param name="location"> an object with all necessary updated info about location </param>
        bool UpdateLocation(Location location);

        /// <summary>
        /// a method that will add a product to a location's inventory
        /// </summary>
        /// <param name="LocationId"> a location id used to search l</param>
        /// <param name="productId"> a product Id used to add item to inventory as a newly created one or existing one</param>
        /// <param name="amount"> amount of products that will be added to inventory</param>
        bool AddProductToInventory(int LocationId = -1, int productId = -1, int amount = -1);

        /// <summary>
        /// a method that will remove a product from inventory
        /// </summary>
        /// <param name="LocationId"> location Id used to naviagte inventory id </param>
        /// <param name="productId"> product id to navigate which product to remove. </param>
        /// <param name="amount"> amount of product to be removed from inventory </param>
        bool RemoveProductFromInventory(int LocationId = -1, int productId = -1, int amount = -1);

        /// <summary>
        /// a method that will a newly introduced product to product table
        /// </summary>
        /// <param name="name"> name of a new product </param>
        /// <param name="type"> a type of a product </param>
        /// <param name="price"> a price of a product </param>
        /// <param name="restricterdAmount"> a restricted amount of a product </param>
        bool AddProductToRegister(string name = null,string type = null,decimal price = -1,int restricterdAmount = -1);

        /// <summary>
        /// a method that will remove a product from a list 
        /// </summary>
        /// <param name="productId"></param>
        bool RemoveProductFromRegister(int productId = -1);

        /// <summary>
        /// a method that will update a product info with new one
        /// </summary>
        /// <param name="product"> a product object that contains all latest info </param>
        bool UpdateProductFromRegister(Product product = null);

        bool ProductExists(string name = null);
    }
}
