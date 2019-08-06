using System;
namespace Project1.Library.Modals
{
    public class Address
    {
        public int X { set; get; }
        public int Y { set; get; }
        public override string ToString()
        {
            return "("+X + " , " + Y+")";
        }
    }
}
