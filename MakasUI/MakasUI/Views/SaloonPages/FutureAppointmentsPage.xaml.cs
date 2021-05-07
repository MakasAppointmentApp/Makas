using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FutureAppointmentsPage : ContentPage
    {
        ViewCell lastCell;
        public ObservableCollection<WorkerAppointmentDto> AppointmentsCollection { get; set; }

        public FutureAppointmentsPage()
        {
            InitializeComponent();
            AppointmentsCollection = new ObservableCollection<WorkerAppointmentDto>();

        }
       
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            try
            {
                var app = Application.Current as App;
                var result = await client.GetStringAsync(App.API_URL + $"Saloon/saloonworkers?id={Convert.ToInt32(app.USER_ID)}");
                var result2 = JsonConvert.DeserializeObject<List<Worker>>(result);
                workers.ItemsSource = result2;
            }
            catch (Exception)
            {

                await DisplayAlert("Hata", "Çalışan bulunamadı", "Ok");
            }
        }
        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.FromHex("#e8eef1");
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.FromHex("#fa7a5a");
                lastCell = viewCell;
            }
        }

        private async void workers_ItemSelected(object senderObj, SelectedItemChangedEventArgs e)
        {
            AppointmentsCollection.Clear();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var worker = e.SelectedItem as Worker;
            string workerId = worker.Id.ToString();
            try
            {
                var result = await client.GetStringAsync(App.API_URL + $"Saloon/futureappointments?workerId={workerId}");
                var result2 = JsonConvert.DeserializeObject<List<WorkerAppointmentDto>>(result);
                foreach (var item in result2)
                {
                    AppointmentsCollection.Add(item);
                }
                FutureAppListView.ItemsSource = AppointmentsCollection;//üst üste biniyor olabilir
            }
            catch (Exception)
            {
                await DisplayAlert("Hata", "Gelecek randevu bulunamadı", "Ok");
            }

        }
    }
}