using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace essentials2
{
    public class Client : IComparable<Client>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateOnly ContractStart { get; set; }
        public DateOnly ContractEnd { get; set; }
        public string Industry { get; set; }

        // this method is a generic method that takes a mapper object as a parameter, and returns a target object T 
        public T Map<T>(IMapper<Client, T> mapper)
        {
            return mapper.Map(this); // pass in this Client object to the mapper's Map method
        }

        // implement IComparable interface methods
        // CompareTo is called in Sorter.cs to compare two Client objects
        public int CompareTo(Client other)
        {
            // Id-based comparison
            if (other?.Id == this.Id)
                return 0;
            else if (other?.Id > this.Id)
                return -1;
            else
                return 1;
        }
    }
}
