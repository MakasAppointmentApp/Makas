using MakasUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.SaloonServices
{

    public class SaloonProfileService
    {
        public async Task<Saloon> GetSaloonAsync(int saloonId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var result = await client.GetStringAsync(App.API_URL + $"Saloon/saloondetail?id={saloonId}");
            var saloon = JsonConvert.DeserializeObject<Saloon>(result);
            return saloon;
        }
    }
}
