using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Use the abstract modifier in a class declaration to indicate that a class is intended only to be a base class of other classes, not instantiated on its own.
 */

// abstract: not implemented in base class, must be implemented by subclasses
// virtual: must be implemented in base class, optionally implemented in subclasses
using System;

namespace learning
{
    public abstract class Payment
    {
        // Properties
        public string PaymentType { get; private set; }
        public double Amount { get; private set; }
        public string Currency { get; private set; }

        // Constructor
        protected Payment(string paymentType, double amount, string currency)
        {
            PaymentType = paymentType;
            Amount = amount;
            Currency = currency;
        }

        // Abstract method
        public virtual void ProcessPayment()
        {
            Console.WriteLine("Payment processing.\n");
        }
    }

    public class CreditCard : Payment
    {
        public CreditCard(double amount, string currency)
            : base("CreditCard", amount, currency)
        {
        }

        public override void ProcessPayment() // Override abstract method
        {
            base.ProcessPayment();
            Console.WriteLine($"Credit card payment of {Amount} {Currency} processed.");
        }
    }

    public class Cash : Payment
    {
        public Cash(double amount, string currency)
            : base("Cash", amount, currency)
        {
        }

        public override void ProcessPayment() // Override abstract method
        {
            base.ProcessPayment();
            Console.WriteLine($"Cash payment of {Amount} {Currency} processed. Making change now.");
        }
    }
}

