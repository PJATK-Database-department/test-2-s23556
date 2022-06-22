using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExample2.DTO;

namespace TestExample2.Services
{
    public interface ICustomer
    {
        public Task<GetCustomer> ReturnCustomer(int id);
    }
}
