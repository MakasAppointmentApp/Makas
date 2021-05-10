using MakasUI.Models.DtosForAuth;
using MakasUI.Services.SaloonServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.SaloonManagers
{
    public class SaloonAuthManager
    {
        private ISaloonAuthService _saloonAuthRestService;
        public SaloonAuthManager(ISaloonAuthService restService)
        {
            _saloonAuthRestService = restService;
        }
        public Task<HttpResponseMessage> PostRegisterAsync(SaloonForRegisterDto saloon)
        {
            return _saloonAuthRestService.PostRegisterAsync(saloon);
        }

        public Task<HttpResponseMessage> PostLoginAsync(SaloonForLoginDto saloon)
        {
            return _saloonAuthRestService.PostLoginAsync(saloon);
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
