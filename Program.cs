using System;

namespace Group_Dealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dealer dealer = new Dealer();
            dealer.GetParameters(args[0], args[1], Int32.Parse(args[2]));
           
        }
    }
}
