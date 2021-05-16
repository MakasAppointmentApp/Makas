using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.CustomerServices.Abstract
{
    public interface ICustomerRestService
    {
        Task<Customer> GetCustomerAsync(int customerId);
        Task<bool> IsFavoriteByCustomer(int saloonId, int customerId);
        Task<HttpResponseMessage> UnFavoriteAsync(int Id);
        Task<HttpResponseMessage> UnfavoriteV2(UnfavoriteItDto fav);
        Task<HttpResponseMessage> FavoriteSaloon(AddFavoriteDto fav);
        Task<List<GetSaloonsByLocationDto>> ListSaloonsByLocationAsync(SearchSaloonsDto listedSaloon);
        Task<List<CustomerAppointmentsDto>> GetCustomerAppointmentAsync(int customerId);
        Task<List<CustomerFavoritesDto>> GetCustomerFavoritesAsync(int customerId);
        Task<HttpResponseMessage> UpdateCustomerNameAsync(UpdateCustomerNameDto customer);
        Task<HttpResponseMessage> UpdateCustomerPasswordAsync(UpdateCustomerPasswordDto customer);
        Task<HttpResponseMessage> UpdateCustomerMailAsync(UpdateCustomerMailDto customer);
        Task<List<HourDto>> GetAvailableHoursByDate(int workerId, DateTime date);
        Task<HttpResponseMessage> AddAppointmentAsync(AddAppointmentDto app);
        Task<HttpResponseMessage> GetReviewIfExists(int saloonId, int customerId, int workerId, int appointmentId);
    }
}
