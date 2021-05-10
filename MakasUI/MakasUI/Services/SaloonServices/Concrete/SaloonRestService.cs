using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MakasUI.Services.SaloonServices
{

    public class SaloonRestService: ISaloonRestService
    {
        HttpClientHandler clientHandler;
        HttpClient client;
        public SaloonRestService()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }
        public async Task<Saloon> GetSaloonAsync(int saloonId)
        {
            var result = await client.GetStringAsync(App.API_URL + $"Saloon/saloondetail?id={saloonId}");
            var saloon = JsonConvert.DeserializeObject<Saloon>(result);
            return saloon;
        }
        public async Task<List<Worker>> GetWorkersAsync()
        {
            var app = Application.Current as App;
            var response = await client.GetStringAsync(App.API_URL + $"Saloon/saloonworkers?id={Convert.ToInt32(app.USER_ID)}");
            var result = JsonConvert.DeserializeObject<List<Worker>>(response);
            return result;
        }
        public async Task<List<WorkerAppointmentDto>> GetPastAppointmentAsync(Worker worker)
        {
            var response = await client.GetStringAsync(App.API_URL + $"Saloon/pastappointments?workerId={worker.Id}");
            var result = JsonConvert.DeserializeObject<List<WorkerAppointmentDto>>(response);
            return result;
        }
        public async Task<List<WorkerAppointmentDto>> GetFutureAppointmentAsync(Worker worker)
        {
            var response = await client.GetStringAsync(App.API_URL + $"Saloon/futureappointments?workerId={worker.Id}");
            var result = JsonConvert.DeserializeObject<List<WorkerAppointmentDto>>(response);
            return result;
        }

        public async Task<HttpResponseMessage> UpdateSaloonNameAsync(UpdateSaloonNameDto saloon)
        {
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/updatename", content);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateSaloonLocationAsync(UpdateSaloonLocation saloon)
        {
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/updatelocation", content);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateSaloonPasswordAsync(UpdatePasswordDto saloon)
        {
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/updatepassword", content);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateSaloonPhotoAsync(UpdateSaloonImageDto saloon)
        {
            var json = JsonConvert.SerializeObject(saloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/updateimage", content);
            return response;
        }

        public async Task<HttpResponseMessage> AddWorkerAsync(AddWorkerDto worker)
        {
            var json = JsonConvert.SerializeObject(worker);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/addworker", content);
            return response;
        }

        public async Task<HttpResponseMessage> AddPriceAsync(AddPriceDto worker)
        {
            var json = JsonConvert.SerializeObject(worker);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Saloon/addprice", content);
            return response;
        }

        public async Task<HttpResponseMessage> DeletePriceAsync(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.DeleteAsync(App.API_URL + $"Saloon/deleteprice?id={Id}");
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
    }
}
