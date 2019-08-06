using Xunit;
using Project1.Library.Modals;

namespace Project_0.UnitTesting.Modals
{
    public class ProductTest
    {
        [Fact]
        public void ProductShouldCreateObject()
        {
            // arrange

            // act
            var NewProduct = new Product();

            // assert
        }

        [Fact]
        public void ProductShouldGetAndSet()
        {
            // arrange
            var NewProductForSet = new Product();
            var NewProductForGet = new Product
            {
                 Name = "SomeProductName",
                 Type = "ABC",
                 Price = 100,
            };

            // act
            NewProductForSet.Name = "EditedProductName";
            NewProductForSet.Type= "EditedType";
            NewProductForSet.Price = 123;

            // assert
            Assert.Equal("EditedProductName", NewProductForSet.Name);
            Assert.Equal("EditedType", NewProductForSet.Type);
            Assert.Equal(123, NewProductForSet.Price);

            Assert.Equal("SomeProductName", NewProductForGet.Name);
            Assert.Equal("ABC", NewProductForGet.Type);
            Assert.Equal(100, NewProductForGet.Price);
        }

        [Fact]
        public void ProductToStringShouldWork()
        {
            // arrange
            var NewProduct = new Product
            {
                Name = "SomeName",
                Type = "SomeType",
                Price = 100,
            };
            // act
            string result = NewProduct.ToString();

            // assert
            Assert.NotNull(result);
        }
    }
}
