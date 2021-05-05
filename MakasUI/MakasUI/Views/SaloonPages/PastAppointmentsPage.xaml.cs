using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PastAppointmentsPage : ContentPage
    {
        int saloonId = 2;//ÖNEMLİ BURADA BUNU TUTMAYIP LOGİN YAPAN KULLANICININ IDYİ ÇEKECEĞİZ
        ViewCell lastCell;
        public ObservableCollection<WorkerAppointmentDto> AppointmentsCollection { get; set; }

        public PastAppointmentsPage()
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
                var result = await client.GetStringAsync(App.API_URL + $"Saloon/saloonworkers?id={saloonId}");
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
                var result = await client.GetStringAsync(App.API_URL + $"Saloon/pastappointments?workerId={workerId}");
                var result2 = JsonConvert.DeserializeObject<List<WorkerAppointmentDto>>(result);
                foreach (var item in result2)
                {
                    AppointmentsCollection.Add(item);
                }
                PastAppListView.ItemsSource = AppointmentsCollection;//üst üste biniyor olabilir
            }
            catch (Exception)
            {
                await DisplayAlert("Hata", "Geçmiş randevu bulunamadı", "Ok");
            }
            
        }
    }
}