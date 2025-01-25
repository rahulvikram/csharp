class Standard
{
    // fields
    static int transactionId = 44953;
    double amount;
    DateTime date;
    
    // entry point of our program, is executed first
    public static void Main(string[] args)
    {
        Console.WriteLine($"Hello, World! Your transaction ID is {transactionId}"); // formatted string

        // trim whitespace from string
        string entryUserName = "     rahulvikram123      ";
        entryUserName = entryUserName.Trim(); // using BCL (base class library) built into C#
        entryUserName = entryUserName.Replace("123", "1488"); // string.Replace() method

        Console.WriteLine(entryUserName);
        Console.WriteLine(entryUserName.Contains("ahulvi"));

        // float division
        float a, b;
        a = 10;
        b = 20;
        float c = a / b;
        Console.WriteLine($"The value of c is {c}");

        // pyramid printing using for loop
        for (int i = 0; i < 5; i++)
        {
            // repeat | 5 times, and concatenate them into a string (LINQ syntax)
            Console.WriteLine(String.Concat(Enumerable.Repeat("|", i + 1)));
        }

        // collections of data: defines a list of strings
        var transactionIds = new List<string> { // var = implicitly inferring the type, C# figures out type
            "4L8dJ9aB1",
            "tG5nR8eK4",
            "E3aS9dF7g",
            "RtY6uI8oL",
            "1pM4aS9dF",
            "L9eK4rT8y",
            "aSdF7gH6j",
            "8eK4rT5yU",
            "I8oL9pM4",
            "T5yU4aS9d",
            "F7gH6jL9e",
            "K4rT8yU1p",
            "M4aS9dF7g",
            "H6jL9eK4r",
            "U1pM4aS9d"
        };
        foreach (var hash in transactionIds)
        {
            Console.WriteLine(hash);
        }
        Console.WriteLine($"Last item in list: {transactionIds.Last()}");
        transactionIds.Add("this is the new last item");
        Console.WriteLine($"Last item in list: {transactionIds.Last()}");

        var numbers = new List<int> { 3, 8, 3, 6, 8, 2, 0, 6, 8, 5, 3, 9, 6, 5, 4, 3, 2 };
        numbers.Sort();
        Console.WriteLine($"9 is now at index {numbers.IndexOf(9)}");
    }
}