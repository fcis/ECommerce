using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Interfaces
{
    public interface ICustomerProvider
    {
        Task<(bool isSuccess, IEnumerable<Models.Customer> customers, string ErrorMessage)> GetCustomersAsync();
        Task<(bool isSuccess, Models.Customer customer, string ErrorMessage)> GetCustomerAsync(int id);

    }
}
