using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace equality
{
    public class Equality
    {
        public static void Classes()
        {
            Payment p1 = new Payment(3000, "USD");
            Payment p2 = new Payment(3000, "USD");

            Console.WriteLine($"{p1 == p2}");
            Console.WriteLine($"{p1.Equals(p2)}");
        }
    }
}