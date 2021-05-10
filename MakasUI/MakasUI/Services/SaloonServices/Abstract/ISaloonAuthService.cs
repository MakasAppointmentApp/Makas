using MakasUI.Models.DtosForAuth;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.SaloonServices
{
    public interface ISaloonAuthService
    {
        Task<HttpResponseMessage> PostRegisterAsync(SaloonForRegisterDto saloon);
        Task<HttpResponseMessage> PostLoginAsync(SaloonForLoginDto saloon);


    }
}
