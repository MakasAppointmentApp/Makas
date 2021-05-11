using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using MakasUI.Services.CustomerServices.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MakasUI.Services.CustomerServices.Concrete
{
    public class CustomerRestService: ICustomerRestService
    {
        HttpClientHandler clientHandler;
        HttpClient client;
        public CustomerRestService()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }
        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            var result = await client.GetStringAsync(App.API_URL + $"Customer/customerdetail?id={customerId}");
            var customer = JsonConvert.DeserializeObject<Customer>(result);
            return customer;
        }
        public async Task<List<GetSaloonsByLocationDto>> ListSaloonsByLocationAsync(SearchSaloonsDto listedSaloon)
        {
            var json = JsonConvert.SerializeObject(listedSaloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string saloonCity = HttpUtility.UrlEncode(listedSaloon.SaloonCity, System.Text.Encoding.UTF8);
            string saloonDistrict = HttpUtility.UrlEncode(listedSaloon.SaloonDistrict, System.Text.Encoding.UTF8);
            var response = await client.GetStringAsync(App.API_URL + $"Customer/locationsaloons?SaloonCity={saloonCity}&SaloonDistrict={saloonDistrict}&SaloonGender=true");
            var result = JsonConvert.DeserializeObject<List<GetSaloonsByLocationDto>>(response);
            return result;
        }
        public async Task<List<CustomerAppointmentsDto>> GetCustomerAppointmentAsync(int customerId)
        {
            var response = await client.GetStringAsync(App.API_URL + $"Customer/customerappointments?customerId={customerId}");
            var result = JsonConvert.DeserializeObject<List<CustomerAppointmentsDto>>(response);
            return result;
        }

        public async Task<HttpResponseMessage> UpdateCustomerNameAsync(UpdateCustomerNameDto customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Customer/updatename", content);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateCustomerPasswordAsync(UpdateCustomerPasswordDto customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Customer/updatepassword", content);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateCustomerMailAsync(UpdateCustomerMailDto customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Customer/updatecustomermail", content);
            return response;
        }

        public async Task<List<CustomerFavoritesDto>> GetCustomerFavoritesAsync(int customerId)
        {
            var response = await client.GetStringAsync(App.API_URL + $"Customer/customerfavorites?customerId={customerId}");
            var result = JsonConvert.DeserializeObject<List<CustomerFavoritesDto>>(response);
            return result;
        }

        public async Task<bool> IsFavoriteByCustomer(int saloonId, int customerId)
        {
            var result = await client.GetStringAsync(App.API_URL + $"Customer/isfavorite?saloonId={saloonId}&customerId={customerId}");
            bool myBool = Convert.ToBoolean(result);
            return myBool;
        }
    }
}
