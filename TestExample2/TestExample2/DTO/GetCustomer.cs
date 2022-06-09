using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExample2.Models;

namespace TestExample2.DTO
{
    public class GetCustomer
    {
        public ClientOrder ClientOrder { get; set; }
        public List<Confectionery> ConfectioneryList { get; set; }
    }
}
