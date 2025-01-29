using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning
{
    internal class EnumTester
    {
        public enum Seasons
        {
            Winter = 2,
            Spring = 4,
            Summer = 8,
            Fall = 16
        }

        public Seasons internshipSeason { get; set; }

        public static void testEnums()
        {
            dynamic d = new CreditCard(5000, "KRW");
            var day = DayOfWeek.Monday;
            Console.WriteLine(day);
        }
    }
}
