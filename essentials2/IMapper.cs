using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace essentials2
{
    public interface IMapper<S, T> // two generic type parameters
    {
        T Map(S source); // method that takes a source object and returns a target object
    }
}
