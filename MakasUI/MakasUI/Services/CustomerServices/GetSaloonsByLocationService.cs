using MakasUI.Models.DtosForCustomer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MakasUI.Services.CustomerServices
{
    class GetSaloonsByLocationService
    {
        public async Task<List<GetSaloonsByLocationDto>> ListedSaloonLocationAsync(SearchSaloonsDto listedSaloon)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(listedSaloon);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string saloonCity = HttpUtility.UrlEncode(listedSaloon.SaloonCity, System.Text.Encoding.UTF8);
            string saloonDistrict = HttpUtility.UrlEncode(listedSaloon.SaloonDistrict, System.Text.Encoding.UTF8);
            var response = await client.GetStringAsync(App.API_URL+$"Customer/locationsaloons?SaloonCity={saloonCity}&SaloonDistrict={saloonDistrict}&SaloonGender=true");
            var result = JsonConvert.DeserializeObject<List<GetSaloonsByLocationDto>>(response);
            return result;
        }
    }
}
