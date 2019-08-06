using System;
using Project1.Library;
using Project1.Library.Modals;
using Xunit;
namespace Project1.UnitTesting
{
    public class AddressTest
    {
        [Fact]
        public void AddressShouldCreateAnObject()
        {
            // arrange

            // act
            var NewAddress = new Address();

            // assert

        }

        /// <summary>
        /// Checking if the Address object fields can be changed
        /// </summary>
        [Fact]
        public void AddressShouldSetAndGetXandY()
        {
            // arrange
            var NewAddress = new Address();

            // act
            NewAddress.X = 1;
            NewAddress.Y = 1;


            var tmp = new Address
            {
                X = 1,
                Y = 1,
            };
            // assert
            Assert.Equal(tmp.X, NewAddress.X);
            Assert.Equal(tmp.Y, NewAddress.Y);
        }
    }
}
