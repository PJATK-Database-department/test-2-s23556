using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExample2.Models
{
    public class Confectionery_ClientOrder
    {
        public int Amount { get; set; }
        public string Comments { get; set; }
        public Confectionery confectionery { get; set; }
        public ClientOrder clientOrder { get; set; }
        public int IdClientOrder { get; set; }
        public int IdConfectionary { get; set; }
    }
}
