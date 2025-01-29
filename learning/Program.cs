using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using equality;
using L=learning;
using Assembly;
using Newtonsoft.Json;
using learning;
using System.Diagnostics.CodeAnalysis;

public partial class Program
{
    static string? PadAndTrim([AllowNull]string input, int len, char paddingChar)
    {
        if (input == null)
        {
            // return an empty string of length len, padded with paddingChar
            return String.Empty.PadLeft(len, paddingChar);
        }
        // else, return the input string, trimmed and padded with paddingChar
        else if (input != null && len > input.Length)
        {
            // various padding based on paddingChar
            switch (paddingChar)
            {
                // pad letters on the right, numbers on the left
                // using relational and logical patterns
                case (>= 'a' and <= 'z') or ('A' and <= 'Z') when paddingChar != 'x':
                    return input.PadRight(len, paddingChar);
                case >= '0' and <= '9':
                    return input.PadLeft(len, paddingChar);
                default:
                    Console.WriteLine("Error: Invalid padding character provided.");
                    return input;
            }
        }
        throw new ArgumentException("Input string cannot be longer than the specified length.", input);
    }

    // This uses a property pattern to match the DateTime object to a pattern (in our case, a weekend night shift)
    // this pattern is useful when you want to check PROPERTIES of an object, rather than the object itself
    static bool IsWeekendNightShift(DateTime date) => date switch // expression switch which allows pattern matching
    {   
        // using curly braces allows us to access properties of the DateTime object, to match patterns
        { Hour: >= 18, DayOfWeek: DayOfWeek.Saturday or DayOfWeek.Sunday } => true,
        _ => false // any other case will return false
    };

    public static void Main(string[] args)
    {
        Console.WriteLine("Main executed.");

        // instance of Application using constructor, then accessing its properties
        var commonapp = new Application("College Application", "Application for college admission", "applicant@example.com", "123-456-7890", "John", "Doe", 18, school: "High School Name", gradYear: 2023, currentCompany: null);

        // this won't work UNLESS we have a defualt constructor
        var capp = new Application
        {
            FormName = "College Application",
            FormDescription = "Application for college admission",
            Email = "applicant@example.com",
            Phone = "123-456-7890",
            Name = "John Doe",
            Age = 18,
            School = "High School Name",
            GradYear = 2023,
            CurrentCompany = null
        };

        Console.WriteLine(commonapp.PrintInfo());

        Equality.Classes();

        L.Cash cash = new L.Cash(100, "USD");
        cash.ProcessPayment();

        var e = new Employee(444, "Rahul", "Developer", 15.50m);
        e.PrintEmployeeInfo();
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(Console.Out, e);

        var p = new { Name = "John", Age = 25, CreditScore = 748, GrossIncome = 314000 };

        //p.Name = "wef"; ERROR: p is a read-only object, useful for creating temporary data structures
        var employees = new[]
{
            new { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
            new { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
            new { Id = 3, Name = "Charlie", Department = "Finance", Salary = 55000 }
        };

        var employeeSummaries = employees.Select(e => new
        {
            e.Name,
            e.Department
        });

        foreach (var summary in employeeSummaries)
        {
            Console.WriteLine($"Name: {summary.Name}, Department: {summary.Department}");
        }

        // dynamic variable: type is determined at runtime, rather than compile time
        dynamic d = new { Name = "Rahul Vikram", Age = 19, City = "Beaverton" }; // d. will not work because the type is not known at compile time
        // dynamic vars are dangerous because propety access won't have red squiggles, but will throw runtime errors

        serializer.Serialize(Console.Out, d);

        var et = new EnumTester();
        et.internshipSeason = EnumTester.Seasons.Winter | EnumTester.Seasons.Summer;
        Console.WriteLine((int)et.internshipSeason);

        /*
         * nullable types
         */
        int notNull;
        int? someInt = null;
        someInt ??= 10; // if someInt is null, assign 10 to it
        notNull = someInt ?? 10; // if someInt is null, assign 10 to notNull

        if (someInt.HasValue)
        {
            Console.WriteLine(someInt.Value);
        }
        else
        {
            Console.WriteLine("someInt is null");
        }

        string? s = "fortnite";
        Console.WriteLine(PadAndTrim(s, 14, '9') + "\n\n");
        Console.WriteLine("------------Control Flow Patterns------------");
        DateTime[] dates = new DateTime[]
        {
            new DateTime(2023, 10, 1, 14, 30, 0), // October 1, 2023, 2:30 PM
            new DateTime(2023, 12, 25, 9, 0, 0), // December 25, 2023, 9:00 AM
            new DateTime(2024, 1, 1, 0, 0, 0), // January 1, 2024, 12:00 AM
            new DateTime(2025, 1, 26, 19, 46, 0), // January 26, 2025, 7:46 PM
            new DateTime(2023, 11, 11, 11, 11, 11) // November 11, 2023, 11:11:11 AM
        };

        foreach (var date in dates)
        {
            Console.WriteLine($"Is {date} a weekend night shift? {IsWeekendNightShift(date)}");
        }

    }
}
