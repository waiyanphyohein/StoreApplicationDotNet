using System;
namespace Project1.Library.Modals
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { set; get; }
        public string Type { set; get; }        
        public double Price { set; get; }
        public int RestrictedAmount { set; get; }
        /// <summary>
        /// A return method that describes about Product Info
        /// </summary>
        /// <returns> a string summary of a product </returns>
        public override string ToString()
        {
            return "Name: "+ Name + "\n"+
                   "Type: "+Type + "\n"+
                   "Price: "+ Price + "\n"+
                   "RestrictedAmount: "+RestrictedAmount+"\n";
        }
        
    }
}
