using MakasUI.Models;
using MakasUI.Models.DtosForAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services
{
    class SaloonAuthServices
    {
        public async Task<HttpResponseMessage> PostRegisterAsync(SaloonForRegisterDto saloon)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",accessToken)//access token parametre olarak verilecek
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "SaloonAuth/register", content);
            return response;
        }
        public async Task<HttpResponseMessage> PostLoginAsync(SaloonForLoginDto saloon)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);

            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "SaloonAuth/login", content);
            return response;
        }
    }
}
