using Xunit;
using System;
using Project1.Library.Modals;

namespace Project1.UnitTesting.Modals
{
    public class OrderTest
    { 

        [Fact]
        public void OrderShouldCreateObjectCorrectly()
        {            

            // arrange
            // act
            var NewOrder = new Order();
            // assert
            
        }

        [Fact]
        public void OrderShouldGetAndSet()
        {
            // act
            int index = Guid.NewGuid().ToByteArray().GetHashCode();
            var NewOrderForSet = new Order();
            var NewOrderForGet = new Order()
            {
                Location = new Address { X = 1, Y = 1 },
                CustomerId = index,                
                Rules = "Some Rules",
            };

            // arrange
            int generatedId = Guid.NewGuid().ToByteArray().GetHashCode();
            NewOrderForSet.CustomerId = generatedId;
            NewOrderForSet.Location = new Address {
                   X = 0,
                   Y = 0
            };
            NewOrderForSet.Rules = "Set Rules";


            // assert

            // ASSERTING FOR SETTING ORDER.
            Assert.Equal(generatedId, NewOrderForSet.CustomerId);
            Assert.Equal("Set Rules", NewOrderForSet.Rules);
            Assert.Equal(0, NewOrderForSet.Location.X);
            Assert.Equal(0, NewOrderForSet.Location.Y);

            // ASSERTING FOR GETTING ORDER.
            Assert.Equal(index, NewOrderForGet.CustomerId);
            Assert.Equal("Some Rules", NewOrderForGet.Rules);
            Assert.Equal(1, NewOrderForGet.Location.X);
            Assert.Equal(1, NewOrderForGet.Location.Y);
        }

        [Fact]
        public void AddProductShouldWorkCorrectly()
        {
            // arrange
            var NewOrder = new Order();
            Product newProd = new Product
            {
                ProductID = 1,
                Name = "Some Product",
                Type = "Some Type",
                Price = 100,
                RestrictedAmount = 200,
            };

            // act
            NewOrder.AddProduct(newProd,100);

            // assert
            // Checking if the data has been registered in ProductDetail.
            Assert.True(NewOrder.ProductDetail.ContainsKey("Some Product"));
            // Checking if the data inside the key is correct.
            Assert.Equal(100, NewOrder.ProductDetail["Some Product"]);
            // Checking if the data has been registered in ProductPrice.
            Assert.True(NewOrder.ProductPrice.ContainsKey("Some Product"));
            // Checking if the data inside the key is correct.
            Assert.Equal(100, NewOrder.ProductPrice["Some Product"]);
        }


        [Theory]
        [InlineData(true,1,"Some_*Product","Type",12.21,10,10)]
        [InlineData(false,2, "ProductName", "Type", 12.21123, 100,200)]
        [InlineData(true,3, "SoProduct", "Type", 12.2f, 100,60)]
        public void AddProductShouldWorkWithUnusualData(bool expected, int ProductId, string name,string type,double price,int restrictedamount,int amount)
        {
            // arrange
            var NewOrder = new Order();
            Product newProduct = new Product
            {
                ProductID = ProductId,
                Name = name,
                Type = type,
                Price = price,
                RestrictedAmount = restrictedamount,
            };

            // act
            var result = NewOrder.AddProduct(newProduct,amount);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1,3,-1,false)]
        [InlineData(-1,-1,-1,false)]
        [InlineData(-1, 3, 2, false)]
        public void UpdateCustomerShouldWorkCorrectly(int X, int Y, int StoreId, bool expected)
        {
            // arrange
            Order tempOrder = new Order
            {
                OrderId = 1,
                LocationID = 1,
                Location = new Address
                {
                    X = 1,
                    Y = 1,
                },
                CustomerId = 1,
                CustomerName = "Some Name",
                ProductDetail = new System.Collections.Generic.Dictionary<string, int>(),
                ProductPrice = new System.Collections.Generic.Dictionary<string, double>(),
                Rules = "Some Rules"
            };
            Location newLoct = new Location
            {
                ID = StoreId,
                Address = new Address
                {
                    X = X,
                    Y = Y
                }
            };

            // act
            bool result = tempOrder.UpdateLocation(newLoct);

            // assert
            Assert.Equal(expected, result);
        }

    }
}
