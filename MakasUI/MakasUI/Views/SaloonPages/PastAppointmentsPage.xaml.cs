using System;
using System.Collections.ObjectModel;
using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PastAppointmentsPage : ContentPage
    {
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
            try
            {
                workers.ItemsSource =  await App.saloonManager.GetWorkersAsync();
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
            var worker = e.SelectedItem as Worker;
            try
            {
                var result = await App.saloonManager.GetPastAppointmentAsync(worker);
                foreach (var item in result)
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