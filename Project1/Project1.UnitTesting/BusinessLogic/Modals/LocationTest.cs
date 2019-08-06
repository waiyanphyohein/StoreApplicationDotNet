using Serilog;
using Xunit;
using Project1.Library.Modals;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Project1.UnitTesting.BusinessLogic.Modals
{
    public class LocationTest
    {
        private static ILogger _logger = new LoggerConfiguration().WriteTo.File("Location.log").CreateLogger();
        public LocationTest(ITestOutputHelper output) => this.output = output;

        private readonly ITestOutputHelper output;

        [Fact]
        public void LocationObjectShouldCreate()
        {
            // arrange

            // act
            var location = new Location();
            // assert
        }

        [Fact]
        public void LocationShouldSetAndGetCorrectly()
        {
            // arrange
            var LocationForSet = new Location();
            var LocationForGet = new Location
            {
                Name = "GetStore",
                ID = 1,
                LocationID = 1,
                Description = "Some Description",
                Rules = "Some Rules",
                Inventory = new System.Collections.Generic.Dictionary<Product, int>(),
                Address = new Address
                {
                    X = 1,
                    Y = 1,
                },
                OrderHistory = new System.Collections.Generic.List<Order>(),
            };


            // act
            LocationForSet.ID = 2;
            LocationForSet.Name = "SetStore";
            LocationForSet.Description = "Set Description";
            LocationForSet.Rules = "Set Rules";
            LocationForSet.LocationID = 2;
            LocationForSet.Address = new Address
            {
                X = 2,
                Y = 1,
            };
            LocationForSet.Inventory = new System.Collections.Generic.Dictionary<Product, int>();
            LocationForSet.OrderHistory = new System.Collections.Generic.List<Order>();

            // assert
            Assert.Equal("GetStore", LocationForGet.Name);
            Assert.Equal(1, LocationForGet.ID);
            Assert.Equal(1, LocationForGet.LocationID);
            Assert.Equal("Some Description", LocationForGet.Description);
            Assert.Equal("Some Rules", LocationForGet.Rules);
            Assert.Equal(1, LocationForGet.Address.X);
            Assert.Equal(1, LocationForGet.Address.Y);

            Assert.Equal("SetStore", LocationForSet.Name);
            Assert.Equal(2, LocationForSet.ID);
            Assert.Equal(2, LocationForSet.LocationID);
            Assert.Equal("Set Description", LocationForSet.Description);
            Assert.Equal("Set Rules", LocationForSet.Rules);
            Assert.Equal(2, LocationForSet.Address.X);
            Assert.Equal(1, LocationForSet.Address.Y);

        }

        [Fact]
        public void LocationShouldAddProduct()
        {
            // arrange
            var location = new Location();

            // act
            Product newProduct = new Product
            {
                ProductID = 1,
                Name = "Some Name",
                Type = "Some Type",
                Price = 100.23,
                RestrictedAmount = 20,
            };
            bool result = location.AddProduct(newProduct,20);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void LocationShouldPlaceOrderCorrectly()
        {
            // arrange
            var location = new Location();
            var customer = new Customer
            {
                CustomerId = 1,
                FirstName = "Fn",
                LastName = "Ln",
                Address = new Address
                {
                    X = 1,
                    Y = 1,
                },
                OrderHistory = new List<Order>()
            };

            // act
            Product newProduct = new Product
            {
                ProductID = 1,
                Name = "Some Name",
                Type = "Some Type",
                Price = 100.23,
                RestrictedAmount = 20,
            };
            bool result = location.AddProduct(newProduct, 200);

            Assert.True(result);

            Dictionary<Product, int> tempProductList = new Dictionary<Product, int>
            {
                { newProduct, 21 }
            };
            Order tryPlacingOrder = location.PlaceOrder(tempProductList, customer);
            if(tryPlacingOrder != null)
            {
                output.WriteLine(tryPlacingOrder.ToString());
                _logger.Information($"{tryPlacingOrder.ToString()}");
            }


            // assert
            Assert.Null(tryPlacingOrder);
        }
    }

}
