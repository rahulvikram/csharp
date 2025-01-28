using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

var myself = new Student
{
    Id = 444,
    FirstName = "Rahul",
    LastName = "Vikram",
    Age = 19
};

// uses Student class fields
Console.WriteLine($"Id: {myself.Id}, Name: {myself.FirstName} {myself.LastName}, Age: {myself.Age}");
