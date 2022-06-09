using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExample2.Models
{
    public class Confectionery
    {
        public int IdConfectionery { get; set; }
        public string Name { get; set; }
        public float PricePerOne { get; set; }
        public virtual IEnumerable<Confectionery_ClientOrder> Confectionery_ClientOrders { get; set; }
    }
}
