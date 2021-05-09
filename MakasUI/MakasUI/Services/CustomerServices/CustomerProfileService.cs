using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.CustomerServices
{
    class CustomerProfileService
    {
        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var result = await client.GetStringAsync(App.API_URL + $"Customer/customerdetail?id={customerId}");
            var customer = JsonConvert.DeserializeObject<Customer>(result);
            return customer;
        }
    }
}
