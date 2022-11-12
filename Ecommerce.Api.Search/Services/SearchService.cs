using Ecommerce.Api.Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public SearchService(IOrderService orderService,IProductService productService,ICustomerService customerService )
        {
            this.orderService = orderService;
            this.productService = productService;
            this.customerService = customerService;
        }
        public async Task<(bool isSuccess, dynamic searchResult)> SearchAsync(int customerId)
        {
            var customerResult = await customerService.GetCustomerAsync(customerId);
            var OrdersResult = await orderService.GetOrdersAsync(customerId);
            var productResult = await productService.GetProductsAsync();
            if (OrdersResult.IsSuccess)
            {
                foreach (var order in OrdersResult.Orders)
                {
                    foreach (var item in order.Items)
                    {
                        item.ProductName = productResult.IsSuccess? 
                            productResult.Products.FirstOrDefault(a => a.Id == item.ProductId)?.Name : "Product Information Is Not Available";
                    }
                }
                var result = new
                {
                    Customer = customerResult.isSuccess ?
                                customerResult.customer : new Models.Customer {Name= "Customer Information Not Available"},
                    Orders = OrdersResult.Orders
                };
                return (true, result);
            }
            return (false, null);

        }
    }
}
