using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace essentials2
{
    public class ClientToCompanyMap : IMapper<Client, Company>
    {
        // use case: when user sends data in one object format, and our databas wants to store it in another format
        public Company Map(Client source)
        {
            return new Company
            {
                Id = source.Id,
                Name = source.Name,
                Location = source.Location,
                CEO = null,
                YearFounded = source.ContractStart
            };
            throw new NotImplementedException();
        }
    }
}
