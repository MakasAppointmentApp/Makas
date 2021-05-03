using MakasUI.Models.DtosForAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MakasUI.ViewModels.SaloonAuth
{
    public class SaloonRegisterViewModel
    {
        const string API_URL = "https://192.168.1.24:45456/api/SaloonAuth/register";
        public async Task<bool> InsertUser(SaloonForRegisterDto saloon)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            string serializedObject = JsonConvert.SerializeObject(saloon);
            HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(API_URL, contentPost);
                Console.WriteLine(response);
                return true;
            }
            catch (TaskCanceledException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(new HttpResponseMessage());
                return false;
            }
        }
    }
}
