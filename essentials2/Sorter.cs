using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace essentials2
{
    public class Sorter<T> where T:class, IComparable<T> // Sorter can operate objects of any type specified
    {
        public void Sort(T[] items) // array of items T
        {
            for (int i = 1; i < items.Length; i++)
            {
                // using Client.cs CompareTo method to compare items
                if (items[i].CompareTo(items[i - 1]) < 0)
                {
                    Swap(items, i, i - 1);
                }
            }
        }

        private void Swap(T[] items, int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}


