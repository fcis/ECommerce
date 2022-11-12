using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerProvider CustomerProvider;

        public CustomersController(ICustomerProvider customerProvider )
        {
            this.CustomerProvider = customerProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await CustomerProvider.GetCustomersAsync();
            if (result.isSuccess)
            {
                return Ok(result.customers);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await CustomerProvider.GetCustomerAsync(id);
            if (result.isSuccess)
            {
                return Ok(result.customer);
            }
            return NotFound();
        }
    }
}
