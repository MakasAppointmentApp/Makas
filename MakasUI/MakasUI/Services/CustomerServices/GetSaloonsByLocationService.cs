using MakasUI.Models.DtosForCustomer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
            var response = await client.GetStringAsync("https://192.168.0.38:45455/api/Customer/locationsaloons?SaloonCity=Eskisehir&SaloonDistrict=Tepebasi&SaloonGender=true");
            var result = JsonConvert.DeserializeObject<List<GetSaloonsByLocationDto>>(response);
            return result;
        }
    }
}
