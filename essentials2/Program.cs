using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace essentials2
{
    internal class Company
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string? CEO { get; set; }
        public int YearFounded { get; set; }

        public Company() { }
        public Company(string name, string location, string? ceo, int year)
        {
            Name = name;
            Location = location;
            CEO = ceo;
            YearFounded = year;
        }
    }

    public partial class Program
    {
        public static void Swap(object first, object second)
        {
            object temp = first;
            first = second;
            second = temp;
        }
        
        // this works exactly like void functions in C++ that take reference parameters
        public static void SwapReal<T>(ref T first, ref T second) // specify generic type parameter, T , must provide type when calling method
        {
            T temp = first;
            first = second;
            second = temp;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Main executed.");
            int x = 4, y = 6;
            Swap(x, y); // this won't work because ints are value types, which are passed by value not pointer reference
            Console.WriteLine($"New x: {x}, new y: {y}");

            Company microsoft = new Company("Microsoft", "Redmond, WA", "Satya Nadella", 1975);
            Company apple = new Company("Apple", "Cupertino, CA", "Tim Cook", 1976);
            Swap(microsoft, apple); // Swap operates on its method parameters, not the objects themselves
            Console.WriteLine($"New c1: {microsoft.Name}, new c2: {apple.Name}");

            SwapReal<int>(ref x, ref y);
            SwapReal<Company>(ref microsoft, ref apple);
            Console.WriteLine($"New x: {x}, new y: {y}");
            Console.WriteLine($"New c1: {microsoft.Name}, new c2: {apple.Name}");

            return;
        }
    }
}