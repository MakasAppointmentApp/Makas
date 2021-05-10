using MakasUI.Models.DtosForAuth;
using MakasUI.Services.CustomerServices.Abstract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.CustomerManagers
{
    public class CustomerAuthManager
    {
        private ICustomerAuthService _customerAuthRestService;
        public CustomerAuthManager(ICustomerAuthService restService)
        {
            _customerAuthRestService = restService;
        }
        public Task<HttpResponseMessage> PostRegisterAsync(CustomerForRegisterDto customer)
        {
            return _customerAuthRestService.PostRegisterAsync(customer);
        }

        public Task<HttpResponseMessage> PostLoginAsync(CustomerForLoginDto customer)
        {
            return _customerAuthRestService.PostLoginAsync(customer);
        }
        public void LogOutAsync(App app)
        {
            app.USER_ID = null;
            app.LoggedIn = "false";
            app.TOKEN = null;
            app.USER_NAME = null;
        }
    }
}
