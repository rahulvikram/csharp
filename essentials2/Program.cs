using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace essentials2
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string? CEO { get; set; }
        public DateOnly YearFounded { get; set; }

        public Company() { }
        public Company(string name, string location, string? ceo, DateOnly year)
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

            Company microsoft = new Company("Microsoft", "Redmond, WA", "Satya Nadella", new DateOnly(1975, 4, 15));
            Company apple = new Company("Apple", "Cupertino, CA", "Tim Cook", new DateOnly(1988, 5, 30));
            Swap(microsoft, apple); // Swap operates on its method parameters, not the objects themselves
            Console.WriteLine($"New c1: {microsoft.Name}, new c2: {apple.Name}");

            SwapReal<int>(ref x, ref y);
            SwapReal<Company>(ref microsoft, ref apple);
            Console.WriteLine($"New x: {x}, new y: {y}");
            Console.WriteLine($"New c1: {microsoft.Name}, new c2: {apple.Name}");

            string jsonCompany = @"{""Name"":""Google"",""Location"":""Mountain View, CA"",""CEO"":""Sundar Pichai"",""YearFounded"": ""1998-03-23""}";
            var google = System.Text.Json.JsonSerializer.Deserialize<Company>(jsonCompany); // deserialize json object into c# company object
            Console.WriteLine($"Google: {google.Name}, {google.Location}, {google.CEO}, {google.YearFounded}");

            Nullable<decimal> cost = null;
            Console.WriteLine(cost.GetValueOrDefault());

            // using the IMapper interface, with a generic method
            var c = new Client
            {
                Id = 1,
                Name = "John Doe",
                Location = "New York, NY",
                ContractStart = new DateOnly(2021, 1, 1),
                ContractEnd = new DateOnly(2022, 1, 1),
                Industry = "Tech"
            };

            var mapper = new ClientToCompanyMap();
            var company = c.Map<Company>(mapper);
            var companySerialized = System.Text.Json.JsonSerializer.Serialize(company);
            Console.WriteLine(companySerialized);

            // collections
            var al = new System.Collections.ArrayList(2);
            al.Add(company);
            al.AddRange(new string[] { "Second", "Third,", "Fourth" });
            Console.WriteLine(al);
            for (int i = 0; i < al.Count; i++)
            {
                Console.WriteLine(al[i]);
            }

            CollectionSamples.Queue();
            CollectionSamples.Stack();
        }
    }
}