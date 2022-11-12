using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Interfaces
{
    public interface ICustomerService
    {
        Task<(bool isSuccess, Models.Customer customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
