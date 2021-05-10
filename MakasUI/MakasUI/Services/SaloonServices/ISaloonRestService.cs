using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.SaloonServices
{
    public interface ISaloonRestService
    {
        Task<Saloon> GetSaloonAsync(int saloonId);
        Task<HttpResponseMessage> UpdateSaloonNameAsync(UpdateSaloonNameDto saloon);
        Task<HttpResponseMessage> UpdateSaloonLocationAsync(UpdateSaloonLocation saloon);
        Task<HttpResponseMessage> UpdateSaloonPasswordAsync(UpdatePasswordDto saloon);
        Task<HttpResponseMessage> UpdateSaloonPhotoAsync(UpdateSaloonImageDto saloon);
        Task<HttpResponseMessage> AddWorkerAsync(AddWorkerDto worker);
        Task<HttpResponseMessage> AddPriceAsync(AddPriceDto worker);
        Task<HttpResponseMessage> DeletePriceAsync(int Id);
        Task<List<Worker>> GetWorkersAsync();
        Task<List<WorkerAppointmentDto>> GetPastAppointmentAsync(Worker worker);
        Task<List<WorkerAppointmentDto>> GetFutureAppointmentAsync(Worker worker);


    }
}
