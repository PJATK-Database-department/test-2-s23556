using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExample2.Models
{
    public class ClientOrder
    {
        public int IdClientOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Comments { get; set; }
        public virtual Client client { get; set; }
        public virtual Employee employee { get; set; }
        public virtual IEnumerable<Confectionery_ClientOrder> Confectionery_ClientOrders { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }
    }
}
