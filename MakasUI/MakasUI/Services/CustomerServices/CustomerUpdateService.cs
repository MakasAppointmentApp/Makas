using MakasUI.Models.DtosForCustomer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.CustomerServices
{
    class CustomerUpdateService
    {
        public async Task<HttpResponseMessage> UpdateCustomerNameAsync(UpdateCustomerNameDto customer)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Customer/updatename", content);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateCustomerPasswordAsync(UpdateCustomerPasswordDto customer)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Customer/updatepassword", content);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateCustomerMailAsync(UpdateCustomerMailDto customer)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Customer/updatecustomermail", content);
            return response;
        }
    }
}
