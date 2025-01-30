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

        public static void PopulateDictionary<T>(Dictionary<string, T> companies) where T : Company, new()
        {
            companies.Add("Microsoft", new T { Name = "Microsoft", Location = "Redmond, WA", CEO = "Satya Nadella", YearFounded = new DateOnly(1975, 4, 15) });
            companies.Add("Apple", new T { Name = "Apple", Location = "Cupertino, CA", CEO = "Tim Cook", YearFounded = new DateOnly(1988, 5, 30) });
            companies.Add("Google", new T { Name = "Google", Location = "Mountain View, CA", CEO = "Sundar Pichai", YearFounded = new DateOnly(1998, 3, 23) });
            companies.Add("Amazon", new T { Name = "Amazon", Location = "Seattle, WA", CEO = "Jeff Bezos", YearFounded = new DateOnly(1994, 7, 5) });
            companies.Add("Intel", new T { Name = "Intel", Location = "Santa Clara, CA", CEO = "Pat Gelsinger", YearFounded = new DateOnly(1968, 7, 18) });
        }

        public static void AddCompany<T>(Dictionary<string, T> companies, string key, T company) where T : Company
        {
            if (companies.TryAdd(key, company))
            {
                Console.WriteLine($" {key} successfully added to database.");
                return;
            }
            Console.WriteLine($"Error: {key} already exists in database.");
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

            // Working with keyed collections
            Dictionary<string, Company> companies = new Dictionary<string, Company>(); // using a dictionary
            PopulateDictionary(companies);


            //if (companies.ContainsKey("estfsddfds"))
            //{
            //    Console.WriteLine("Microsoft is in the dictionary.");
            //}
            //else
            //{
            //    throw new Exception("ERROR: Key does not exist.");
            //}

            AddCompany(companies, "Intel", new Company("Intel", "Santa Clara, CA", "Pat Gelsinger", new DateOnly(1965, 4, 10)));

            // Print the populated dictionary
            foreach (var kvp in companies)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Name}, {kvp.Value.Location}, {kvp.Value.CEO}, {kvp.Value.YearFounded}");
            }

            try
            {
                int[] nums = {1, 2, 3, 4, 5, 6};
                for (int i = 0; i < 24; i++)
                {
                    Console.WriteLine(nums[i]);
                }
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("Error handled.");
            }
        }
    }
}