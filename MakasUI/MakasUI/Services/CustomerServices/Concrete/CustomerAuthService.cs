using MakasUI.Models.DtosForAuth;
using MakasUI.Services.CustomerServices.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.CustomerServices.Concrete
{
    public class CustomerAuthService: ICustomerAuthService
    {
        HttpClientHandler clientHandler;
        HttpClient client;
        public CustomerAuthService()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }
        public async Task<HttpResponseMessage> PostRegisterAsync(CustomerForRegisterDto customer)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",accessToken)//access token parametre olarak verilecek
            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "CustomerAuth/register", content);
            return response;
        }
        public async Task<HttpResponseMessage> PostLoginAsync(CustomerForLoginDto customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "CustomerAuth/login", content);
            return response;
        }
    }
}
