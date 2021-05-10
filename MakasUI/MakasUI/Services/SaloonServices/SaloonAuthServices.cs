using MakasUI.Models;
using MakasUI.Models.DtosForAuth;
using MakasUI.Services.SaloonServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services
{
    class SaloonAuthServices:ISaloonAuthService
    {
        HttpClientHandler clientHandler;
        HttpClient client;
        public SaloonAuthServices()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }
        public async Task<HttpResponseMessage> PostRegisterAsync(SaloonForRegisterDto saloon)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",accessToken)//access token parametre olarak verilecek
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "SaloonAuth/register", content);
            return response;
        }
        public async Task<HttpResponseMessage> PostLoginAsync(SaloonForLoginDto saloon)
        {
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "SaloonAuth/login", content);
            return response;
        }
    }
}
