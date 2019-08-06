using Xunit;
using Project1.Library.Modals;
using Xunit.Abstractions;

namespace Project1.UnitTesting
{
    public class CustomerTest
    {
        private readonly ITestOutputHelper output;

        public CustomerTest(ITestOutputHelper output) => this.output = output;

        [Fact]
        public void CustomerDefaultConstructorShouldWork()
        {
            // arrange

            // act
            var cust = new Customer();

            // assert
            Assert.Equal("N/A", cust.FirstName);
            Assert.Equal("N/A", cust.LastName);
            Assert.Equal(0, cust.Address.X);
            Assert.Equal(0, cust.Address.Y);
        }

        [Fact]
        public void CustomerOverloadConstructorShouldWork()
        {
            // arrange

            // act
            var cust = new Customer
            {
                FirstName = "FN",
                LastName = "LN",
                Address = new Address
                {
                    X = 1,
                    Y = 1
                }
            };
            // assert
            Assert.Equal("FN", cust.FirstName);
            Assert.Equal("LN", cust.LastName);
            Assert.Equal(1, cust.Address.X);
            Assert.Equal(1, cust.Address.Y);
        }

        [Fact]
        public void CustomerShouldSetAndGet()
        {
            // arrange
            var cust = new Customer();

            // act
            cust.FirstName = "FirstName";
            cust.LastName = "LastName";
            cust.Address = new Address { X = 12, Y = 12 };

            // assert
            Assert.Equal("FirstName", cust.FirstName);
            Assert.Equal("LastName", cust.LastName);
            Assert.Equal(12, cust.Address.X);
            Assert.Equal(12, cust.Address.Y);
        }

        [Fact]
        public void CustomerToStringShouldReturnString()
        {
            // arrange
            var cust = new Customer
            {
                FirstName = "FN",
                LastName = "LN",
                Address = new Address { X = 1, Y = 2}
            };

            // act
            string result = cust.ToString();

            // assert
            Assert.Equal("Name: FN LN\n" +
                   "Address: (1 , 2)\n", result);
        }

        [Fact]
        public void OrderHistoryToStringShouldWork()
        {
            // arrange

            var cust = new Customer {
                FirstName = "FN",
                LastName = "LN",
                Address = new Address
                {
                    X = 1,
                    Y = 2,
                }                 
            };
            

            // act
            Order newOrder = new Order();            
            newOrder.UpdateCustomer(cust);
            bool succes = newOrder.AddProduct(new Product
            {
                Name = "Something",
                Type = "Some Type",
                Price = 100,
                RestrictedAmount = 100,
            },10);            
            newOrder.Rules = "Some Rules";
            Location newLocation = new Location
            {
                LocationID = 1,                
                Address = new Address
                {
                    X = 1,
                    Y = 1,
                }
            };

            newOrder.UpdateLocation(newLocation);            
            cust.OrderHistory.Add(newOrder);

            // assert
            string result = cust.OrderHistoryToString();
            // FOR DEBUGGING PURPOSE.
            //output.WriteLine(result);

            Assert.Equal("Customer: FN LN\nLocation: (1 , 1)\nRules: Some Rules\n[Something, 10]", result);
            
        }
    }
}
