using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using MakasUI.Services.CustomerServices.Abstract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.CustomerManagers
{
    public class CustomerManager
    {
        private ICustomerRestService _customerRestService;

        public CustomerManager(ICustomerRestService restService)
        {
            _customerRestService = restService;
        }
        public Task<Customer> GetCustomerAsync(int customerId)
        {
            return _customerRestService.GetCustomerAsync(customerId);
        }
        public Task<List<GetSaloonsByLocationDto>> ListSaloonsByLocationAsync(SearchSaloonsDto listedSaloon)
        {
            return _customerRestService.ListSaloonsByLocationAsync(listedSaloon);
        }
        public Task<HttpResponseMessage> UpdateCustomerNameAsync(UpdateCustomerNameDto customer)
        {
            return _customerRestService.UpdateCustomerNameAsync(customer);
        }
        public Task<HttpResponseMessage> UpdateCustomerPasswordAsync(UpdateCustomerPasswordDto customer)
        {
            return _customerRestService.UpdateCustomerPasswordAsync(customer);
        }
        public Task<HttpResponseMessage> UpdateCustomerMailAsync(UpdateCustomerMailDto customer)
        {
            return _customerRestService.UpdateCustomerMailAsync(customer);
        }
    }
}
