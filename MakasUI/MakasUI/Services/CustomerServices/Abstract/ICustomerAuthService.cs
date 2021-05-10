using MakasUI.Models.DtosForAuth;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.CustomerServices.Abstract
{
    public interface ICustomerAuthService
    {
        Task<HttpResponseMessage> PostRegisterAsync(CustomerForRegisterDto customer);
        Task<HttpResponseMessage> PostLoginAsync(CustomerForLoginDto customer);

    }
}
