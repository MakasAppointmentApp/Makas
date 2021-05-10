using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using MakasUI.Services.SaloonServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.SaloonManagers
{
    public class SaloonManager
    {
        private ISaloonRestService _saloonRestService;
        public SaloonManager(ISaloonRestService restService)
        {
            _saloonRestService = restService;
        }
        public Task<Saloon> GetSaloonAsync(int saloonId)
        {
            return _saloonRestService.GetSaloonAsync(saloonId);
        }
        public Task<HttpResponseMessage> UpdateSaloonNameAsync(UpdateSaloonNameDto saloon)
        {
            return _saloonRestService.UpdateSaloonNameAsync(saloon);
        }
        public Task<HttpResponseMessage> UpdateSaloonLocationAsync(UpdateSaloonLocation saloon)
        {
            return _saloonRestService.UpdateSaloonLocationAsync(saloon);
        }
        public Task<HttpResponseMessage> UpdateSaloonPasswordAsync(UpdatePasswordDto saloon)
        {
            return _saloonRestService.UpdateSaloonPasswordAsync(saloon);
        }
        public Task<HttpResponseMessage> UpdateSaloonPhotoAsync(UpdateSaloonImageDto saloon)
        {
            return _saloonRestService.UpdateSaloonPhotoAsync(saloon);
        }
        public Task<HttpResponseMessage> AddWorkerAsync(AddWorkerDto worker)
        {
            return _saloonRestService.AddWorkerAsync(worker);
        }
        public Task<HttpResponseMessage> AddPriceAsync(AddPriceDto worker)
        {
            return _saloonRestService.AddPriceAsync(worker);
        }
        public Task<HttpResponseMessage> DeletePriceAsync(int Id)
        {
            return _saloonRestService.DeletePriceAsync(Id);
        }
        public Task<List<Worker>> GetWorkersAsync()
        {
            return _saloonRestService.GetWorkersAsync();
        }
        public Task<List<WorkerAppointmentDto>> GetPastAppointmentAsync(Worker worker)
        {
            return _saloonRestService.GetPastAppointmentAsync(worker);
        }
        public Task<List<WorkerAppointmentDto>> GetFutureAppointmentAsync(Worker worker)
        {
            return _saloonRestService.GetFutureAppointmentAsync(worker);
        }


    }
}
