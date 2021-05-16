using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using MakasUI.Services.CustomerServices.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public async Task<HttpResponseMessage> UnFavoriteAsync(int Id)
        {
            var json = JsonConvert.SerializeObject(Id);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.DeleteAsync(App.API_URL + $"Customer/unfavorite?id={Id}");
            return response;
        }
        public async Task<HttpResponseMessage> FavoriteSaloon(AddFavoriteDto fav)
        {
            var json = JsonConvert.SerializeObject(fav);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Customer/addfavorite", content);
            return response;
        }

        public async Task<HttpResponseMessage> UnfavoriteV2(UnfavoriteItDto fav)
        {
            var json = JsonConvert.SerializeObject(fav);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.DeleteAsync(App.API_URL + $"Customer/unfavoritev2?customerId={fav.CustomerId}&SaloonId={fav.SaloonId}");
            return response;
        }
        public async Task<List<HourDto>> GetAvailableHoursByDate(int workerId, DateTime date)
        {
            var convertedDate = $"{date.Year}-{date.Month}-{date.Day}";
            var response = await client.GetStringAsync(App.API_URL + $"Customer/availablehours?workerId={workerId}&date={convertedDate}");
            var result = JsonConvert.DeserializeObject<List<HourDto>>(response);
            return result;
        }
        public async Task<HttpResponseMessage> AddAppointmentAsync(AddAppointmentDto app)
        {
            var json = JsonConvert.SerializeObject(app);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.API_URL + "Customer/addappointment", content);
            return response;
        }

        public async Task<HttpResponseMessage> GetReviewIfExists(int saloonId, int customerId, int workerId, int appointmentId)
        {
            var response = await client.GetAsync(App.API_URL + $"Customer/getexistsreviews?saloonId={saloonId}&customerId={customerId}&workerId={workerId}&appointmentId={appointmentId}");
            return response;
        }
    }
}
