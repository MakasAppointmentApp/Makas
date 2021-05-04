using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.SaloonServices
{
    public class SaloonUpdateService
    {
        public async Task<HttpResponseMessage> UpdateSaloonNameAsync(UpdateSaloonNameDto saloon)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/updatename", content);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateSaloonLocationAsync(UpdateSaloonLocation saloon)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/updatelocation", content);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateSaloonPasswordAsync(UpdatePasswordDto saloon)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/updatepassword", content);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateSaloonPhotoAsync(UpdateSaloonImageDto saloon)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/updateimage", content);
            return response;
        }
        public async Task<HttpResponseMessage> AddWorkerAsync(AddWorkerDto worker)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(worker);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(App.API_URL + "Saloon/addworker", content);
            return response;
        }
        /* public async Task<HttpResponseMessage> DeleteWorkerAsync(int Id)
         {
             HttpClientHandler clientHandler = new HttpClientHandler();
             clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
             var client = new HttpClient(clientHandler);
             var json = JsonConvert.SerializeObject(worker);
             HttpContent content = new StringContent(json);
             content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

             var response = await client.DeleteAsync(App.API_URL + $"Saloon/deleteworker?={Id}");
             return response;
         }     BU DEĞİŞECEK!!!     */
        public async Task<HttpResponseMessage> AddPriceAsync(AddPriceDto worker)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(worker);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(App.API_URL + "Saloon/addprice", content);
            return response;
        }
        public async Task<HttpResponseMessage> DeletePriceAsync(int Id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(Id);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.DeleteAsync(App.API_URL + $"Saloon/deleteprice?id={Id}");
            return response;
        }

        
    }
}
