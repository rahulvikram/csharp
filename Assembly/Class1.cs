namespace Assembly
{
    public class Employee
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        // default constructor
        public Employee()
        { }

        // constructor
        public Employee(int id, string name, string position, decimal salary)
        {
            Id = id;
            Name = name;
            Position = position;
            Salary = salary;
        }
        public void PrintEmployeeInfo()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Salary: {Salary:C}");
        }


    }
}
