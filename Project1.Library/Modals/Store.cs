namespace Project1.Library.Modals
{
    public class Store
    {
        // Store's ID
        public int ID { get; set; }

        // Store's Name
        public string Name { set; get; }

        // Store's Description
        public string Description { get; set;}

        public string Rules { set; get; }

        /// <summary>
        ///  Default Constructor
        /// </summary>
        public Store()
        {
            Name = "N/A";
            Description = "N/A";
            ID = 0;
            Rules = "N/A";
        }

        /// <summary>
        /// Overload Default Constructor for Store Copy.
        /// </summary>
        /// <param name="store"> a store used to copy to this. </param>
        public Store(Store store)
        {
            this.Name = store.Name;
            this.ID = store.ID;
            this.Description = store.Description;
            this.Rules = store.Rules;
        }

        /// <summary>
        /// a string return method that gives a summary of a store.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ID: " + ID + "\n" +
                   "Name: " + Name + "\n" +
                   "Description: "+ Description + "\n"+
                   "Rules: "+ Rules+ "\n";
        }
    }
}
