using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Reference types; class Application inherits from interface FormDetails, and 
 */
// classes that inherit this interface must implement ALL of its properties
public interface FormDetails
{
    public string FormName { get; init; }
    public string FormDescription { get; init; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class Application : FormDetails
{
    // default constructor
    public Application()
    {}

    // custom constructor
    public Application(string formName, string formDescription, string email, string phone,
                      string firstName, string lastName, int age, int gradYear, string? school = null, string? currentCompany = null)
    {
        FormName = formName;
        FormDescription = formDescription;
        Email = email;
        Phone = phone;
        Name = firstName + " " + lastName;
        Age = age;
        School = school;
        GradYear = gradYear;
        CurrentCompany = currentCompany;
    }

    // properties inherited from FormDetails
    public string FormName { get; init; } // using init instead of set, we want this property to be immutable after initialization
    public string FormDescription { get; init; }
    public string Email { get; set; }
    public string Phone { get; set; }

    // additional class-specific properties
    public string Name {  get; set; }
    public int Age { get; set; }
    public string? School { get; set; }
    public int GradYear { get; set; }
    public string? CurrentCompany { get; set; }

    // print user application information
    public string PrintInfo()
    {
        return $"{this.Name}'s {this.FormName}\n{this.FormDescription}\n\nContact Info: {this.Email}, {this.Phone}\n";
    }
}


/*
 Value type: e.g. structs, we directly use the struct as a data type in other classes
 */
public struct Payment
{
    // constructor
    public Payment(double amt, string curr)
    {
        amount = amt;
        currency = curr;
    }

    // equality operator overloading
    // Equality operator overloading
    public static bool operator ==(Payment p1, Payment p2)
    {
        return p1.amount == p2.amount && p1.currency == p2.currency;
    }

    // Inequality operator overloading (required when overloading !=)
    public static bool operator !=(Payment p1, Payment p2)
    {
        return p1.amount != p2.amount || p1.currency != p2.currency;
    }

    // Override Equals method for consistency
    public override bool Equals(object obj)
    {
        // first checks if the objects are of the same type
        if (!(obj is Payment))
        {
            return false;
        }

        // then checks if the objects have same values
        Payment other = (Payment)obj;
        return this == other;
    }


    public double amount { get; set; }
    public string currency { get; set; }
}

// using struct payment
// note: structs CANNOT inherit from other base structs
public struct Transaction
{
    public Payment paymentDetails; // using payment struct
    public string transactionId;
    public string transactionDate;
}
