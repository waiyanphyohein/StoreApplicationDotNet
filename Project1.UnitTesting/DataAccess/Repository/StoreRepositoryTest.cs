using Xunit;
using Xunit.Abstractions;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Project1.DataAccess.Repositories;
using Project1.Library.Modals;
using Project1.UnitTesting.Repository;

namespace Project_0.UnitTesting.Repository
{
    public class StoreRepositoryTest
    {
        private readonly ITestOutputHelper output;

        public StoreRepositoryTest(ITestOutputHelper output) => this.output = output;
        private static ILogger _logger = new LoggerConfiguration().WriteTo.File("StoreRepo.log").CreateLogger();

        private StoreRepository ReturnReinstatedRepo()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project1.DataAccess.Entities.Project1DbContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.SecretConnectionString);
            var dbContext = new Project1.DataAccess.Entities.Project1DbContext(optionsBuilder.Options);
            var newRepo = new StoreRepository(dbContext);
            return newRepo;
        }

        [Fact]
        public void AddCustomerShouldWork()
        {
            using (var newRepo = ReturnReinstatedRepo())
            {
                // arrange
                Log.Logger = _logger;
                Log.Information("Testing AddCustomer Method with raw data input.");


                // act            
                bool result = newRepo.AddCustomer("Jorge", "Inclue", new Project1.Library.Modals.Address { X = 1, Y = 30 });
                output.WriteLine(newRepo.message);

                // assert
                Assert.False(result);
            }
        }

        [Fact]
        public void AddCustomerByBusinessCustomerShouldWork()
        {
            // arrange
            using (var newRepo = ReturnReinstatedRepo())
            {
                Log.Logger = _logger;
                Log.Information("Testing AddCustomer method with (Modals.Customer) input.");
            
                var newCust = new Customer
                {
                    FirstName = "Jorge",
                    LastName = "Inclue",
                    Address = new Address
                    {
                        X = 1,
                        Y = 1,
                    }
                };

                // act
                bool result = newRepo.AddCustomer(newCust);
                output.WriteLine(newRepo.message);

                // assert
                Assert.False(result);
            }

        }

        [Fact]
        public void DeleteCustomerByCustomerIdShouldWork()
        {
            using(var newRepo = ReturnReinstatedRepo())
            {
            // arrange
                Log.Logger = _logger;
                Log.Information("Testing DeleteCustomer method with (CustomerId) input.");
                
                int CustomerId = 9;

                // act
                bool result = newRepo.DeleteCustomerById(CustomerId);
                output.WriteLine($"Deletion Result: {result.ToString()}");

                // assert
                Assert.False(result);
            }
        }
    }
}
