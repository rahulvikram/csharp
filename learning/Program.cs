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

public partial class Program
{
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
    }
}
