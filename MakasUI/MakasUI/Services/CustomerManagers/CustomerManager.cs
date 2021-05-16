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
        public Task<List<CustomerAppointmentsDto>> GetCustomerAppointmentAsync(int customerId)
        {
            return _customerRestService.GetCustomerAppointmentAsync(customerId);
        }
        public Task<List<CustomerFavoritesDto>> GetCustomerFavoritesAsync(int customerId)
        {
            return _customerRestService.GetCustomerFavoritesAsync(customerId);
        }
        public Task<bool> IsFavoriteByCustomer(int saloonId, int customerId)
        {
            return _customerRestService.IsFavoriteByCustomer(saloonId,customerId);
        }
        public Task<HttpResponseMessage> UnFavoriteAsync(int Id)
        {
            return _customerRestService.UnFavoriteAsync(Id);
        }
        public Task<HttpResponseMessage> UnfavoriteV2(UnfavoriteItDto fav)
        {
            return _customerRestService.UnfavoriteV2(fav);
        }
        public Task<HttpResponseMessage> FavoriteSaloon(AddFavoriteDto fav)
        {
            return _customerRestService.FavoriteSaloon(fav);
        }
        public Task<List<HourDto>> GetAvailableHoursByDate(int workerId, DateTime date)
        {
            return _customerRestService.GetAvailableHoursByDate(workerId,date);
        }
        public Task<HttpResponseMessage> AddAppointmentAsync(AddAppointmentDto app)
        {
            return _customerRestService.AddAppointmentAsync(app);
        }
        public Task<HttpResponseMessage> GetReviewIfExists(int saloonId, int customerId, int workerId, int appointmentId)
        {
            return _customerRestService.GetReviewIfExists(saloonId, customerId, workerId, appointmentId);
        }
        public Task<HttpResponseMessage> AddReviewAsync(AddReviewDto review)
        {
            return _customerRestService.AddReviewAsync(review);
        }
        public Task<Review> GetReviewAsync(int Id)
        {
            return _customerRestService.GetReviewAsync(Id);
        }
    }
}
