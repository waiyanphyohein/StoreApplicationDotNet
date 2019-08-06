using Project1.Library.Modals;
using Xunit;

namespace Project1.UnitTesting.Modals
{
    public class StoreTest
    {
        

        /// <summary>
        /// A unit test for checking whether an object of Store can be created.
        /// </summary>
        [Fact]
        public void StoreShouldCreateObjectCorrectly()
        {
            // arrange

            // act
            var NewStore = new Store();

            // assert
        }


        [Fact]
        public void StoreFieldsShouldGetAndSet()
        {
            // arrange
            var NewStoreForGet = new Store
            {
                 Name = "SomeName",
                 Description = "Some Description",
                 ID = 0,
                 Rules = "SomeRules",
            };
            var NewStoreForSet = new Store();

            // act

            NewStoreForSet.Name = "EditedName";
            NewStoreForSet.ID = 123;
            NewStoreForSet.Description = "EditedDescription";
            NewStoreForSet.Rules = "EditedRules";

            // assert

            // FOR SETTING TEST
            Assert.Equal("EditedName", NewStoreForSet.Name);
            Assert.Equal("EditedDescription", NewStoreForSet.Description);
            Assert.Equal(123, NewStoreForSet.ID);
            Assert.Equal("EditedRules", NewStoreForSet.Rules);


            // FOR GETTING TEST
            Assert.Equal("SomeName", NewStoreForGet.Name);
            Assert.Equal("Some Description", NewStoreForGet.Description);
            Assert.Equal(0, NewStoreForGet.ID);
            Assert.Equal("SomeRules", NewStoreForGet.Rules);
        }


        [Fact]
        public void StoreToStringShouldWorkCorrectly()
        {
            // arrange
            var NewStore = new Store();

            // act
            NewStore.Name = "EditedName";
            NewStore.ID = 123;
            NewStore.Description = "EditedDescription";
            NewStore.Rules = "EditedRules";


            string expected = "ID: 123\n" +
                   "Name: EditedName\n" +
                   "Description: EditedDescription\n" +
                   "Rules: EditedRules\n";
            // assert
            string result = NewStore.ToString();
            Assert.Equal(expected,result);
        }



    }
}
