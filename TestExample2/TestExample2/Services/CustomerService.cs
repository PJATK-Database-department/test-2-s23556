using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExample2.DTO;
using TestExample2.Models;

namespace TestExample2.Services
{
    public class CustomerService : ICustomer
    {
        private readonly OrderDBContext dBContext;

        public CustomerService(OrderDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<GetCustomer> ReturnCustomer(int id)
        {
            var client = new GetCustomer { };

            var co = await dBContext.ClientOrders.FirstOrDefaultAsync(x => x.IdClient == id);
            client.ClientOrder = await dBContext.ClientOrders.Where(x => x.IdClient == id).FirstOrDefaultAsync();

            

            /*client.ConfectioneryList = await dBContext.Confectionery_ClientOrders
                .Where(x => x.IdClientOrder == co)
                .Include(x => x.confectionery)
                .Select(x => new Confectionery_ClientOrder
                {
                    //Name = x.Name,
                    Amount = x.Amount,
                })
                .ToListAsync();*/

            

            return client;
        }
    }
}
