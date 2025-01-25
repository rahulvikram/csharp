using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning
{
    internal class LINQtest
    {
        public static void PrintInts(int length)
        {
            int[] numbers = new int[length]; // array of length length

            for (int i = 0; i < length; i++)
            {
                numbers[i] = i + 1;
                Console.WriteLine(numbers[i]);
            }

        }
    }

    LINQtest.PrintInts(5);
}

