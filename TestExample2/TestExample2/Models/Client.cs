﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExample2.Models
{
    public class Client
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IEnumerable<ClientOrder> Orders { get; set; }
    }
}
