using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExample2.Services;
using TestExample2.DTO;

namespace TestExample2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ICustomer _service;
        public OrderController(ICustomer service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderCustomer(int id)
        {
            GetCustomer client = (GetCustomer)await _service.ReturnCustomer(id);

            if (client == null) { return NotFound(); }

            return Ok(client);
        }

    }
}
