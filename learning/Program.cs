using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using equality;
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

        Cash cash = new Cash(100, "USD");
        cash.ProcessPayment();
    }
}
