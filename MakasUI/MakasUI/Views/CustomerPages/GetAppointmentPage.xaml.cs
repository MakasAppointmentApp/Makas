using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetAppointmentPage : ContentPage
    {
        ViewCell lastCell;
        Worker selectedWorker;
        int _saloonId;
        public ObservableCollection<HourDto> HoursCollection { get; set; }

        public GetAppointmentPage(Worker worker, Saloon saloon)
        {
            InitializeComponent();
            datePicker.MinimumDate = DateTime.Now;
            datePicker.MaximumDate = DateTime.Now.AddYears(1);
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            selectedWorker = worker;
            _saloonId = saloon.Id;
            sName.Text = saloon.SaloonName;
            sRate.Text = Convert.ToString(saloon.SaloonRate);
            workerImage.Source = ImageSource.FromStream(() => new MemoryStream(worker.WorkerPhoto));
            workerName.Text = worker.WorkerName;
            workerRate.Text = Convert.ToString(worker.WorkerRate);
            HoursCollection = new ObservableCollection<HourDto>();
            hourList.ItemsSource = HoursCollection;

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var today = DateTime.Now.Date;
                var response = await App.customerManager.GetAvailableHoursByDate(selectedWorker.Id, today);
                foreach (var item in response)
                {
                    HoursCollection.Add(item);
                }
                if (HoursCollection.Count() == 0)
                {
                    await DisplayAlert("Üzgünüz.", $" Bu ayın {datePicker.Date.Day}'inde {selectedWorker.WorkerName}'in tüm randevuları dolu.", "Tamam");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Üzgünüz.", $" Bu ayın {datePicker.Date.Day}'inde {selectedWorker.WorkerName}'in tüm randevuları dolu.", "Tamam");
            }

        }
        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            HoursCollection.Clear();
            var response = await App.customerManager.GetAvailableHoursByDate(selectedWorker.Id, datePicker.Date);
            foreach (var item in response)
            {
                HoursCollection.Add(item);
            }
            if (HoursCollection.Count() == 0)
            {
                await DisplayAlert("Üzgünüz.", $" Bu ayın {datePicker.Date.Day}'inde {selectedWorker.WorkerName}'in tüm randevuları dolu.", "Tamam");
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            datePicker.Focus();
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

        private async void Randevu_Al_Button_Clicked(object sender, EventArgs e)
        {
            if (hourList.SelectedItem != null)
            {
                var app = Application.Current as App;
                var hour = hourList.SelectedItem as HourDto;
                var selectedDate = datePicker.Date;

                DateTime newDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Convert.ToInt32(hour.Hour), 00, 00);
                var response = await App.customerManager.AddAppointmentAsync(
                    new AddAppointmentDto
                    {
                        CustomerId = Convert.ToInt32(app.USER_ID),
                        SaloonId = _saloonId,
                        WorkerId = selectedWorker.Id,
                        Date = newDate
                    });
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Başarılı.", $" Bu ayın {newDate.Date.Day}'inde {selectedWorker.WorkerName}'e randevunuz başarıyla alınmıştır.", "Tamam");
                    App.Current.MainPage = new CustomerHomePage();
                }
                else
                {
                    await DisplayAlert("Hata.", "Bizden kaynaklı bir hata oluştu ya da bu randevu saati dolu.", "Tamam");
                }
            }
            customerGetAppErrorLabel.Text = "Bir randevu saati seçmelisiniz!:";
        }
    }
}