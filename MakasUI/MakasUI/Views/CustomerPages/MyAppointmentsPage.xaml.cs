using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using MakasUI.Services.SaloonServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAppointmentsPage : ContentPage
    {
        Customer presentCustomer;
        public ObservableCollection<CustomerAppointmentsDto> AppointmentsCollection { get; set; }
        public MyAppointmentsPage()
        {
            InitializeComponent();

            ItemFunctions functions = new ItemFunctions();
            AppointmentsCollection = new ObservableCollection<CustomerAppointmentsDto>();
        }
        private async Task GetCustomerProfile()
        {
            var app = Application.Current as App;
            var customer = await App.customerManager.GetCustomerAsync(Convert.ToInt32(app.USER_ID));
            presentCustomer = customer;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AppointmentsCollection.Clear();
            await GetCustomerProfile();
            await getItems();
        }
        public async Task getItems()
        {
            try
            {
                var result = await App.customerManager.GetCustomerAppointmentAsync(presentCustomer.Id);
                foreach (var item in result)
                {
                    ReviewDto rev = new ReviewDto
                    {
                        SaloonId = item.SaloonId,
                        WorkerId = item.WorkerId,
                        CustomerId = Convert.ToInt32(presentCustomer.Id),
                        AppointmentId = item.AppointmentId
                    };
                    var response = await App.customerManager.GetReviewIfExists(item.SaloonId, Convert.ToInt32(presentCustomer.Id), item.WorkerId, item.AppointmentId);
                    if (item.Date > DateTime.Now)
                    {
                        item.ReviewControl = "İptal Et";
                        item.ButtonImage = "cancel.png";
                    }
                    else if (response.IsSuccessStatusCode.Equals(true))
                    {
                        item.ReviewControl = "Değerlendirmem";
                        item.ButtonImage = "comment.png";
                    }
                    else
                    {
                        item.ReviewControl = "Değerlendir";
                        item.ButtonImage = "comment.png";
                    }
                    AppointmentsCollection.Add(item);
                }
                AppointmentsListView.ItemsSource = AppointmentsCollection;
            }
            catch (Exception)
            {
                await DisplayAlert("Hata", "Randevu bulunamadı", "Ok");
            }
        }

        private async void Review_Clicked(object sender, EventArgs e)
        {

            ImageButton btn = (ImageButton)sender;
            await btn.ScaleTo(1.2, 250, Easing.SpringIn);
            CustomerAppointmentsDto ob = btn.CommandParameter as CustomerAppointmentsDto;
            await btn.ScaleTo(1.0, 50, Easing.SpringOut);
            if (ob.ReviewControl == "İptal Et")
            {
                var action = await DisplayAlert("İPTAL?", "Randevunuzu iptal etmek istediğinize emin misiniz?", "Evet", "Hayır");
                if (action)
                {
                    try
                    {
                        var result = await App.customerManager.CancelAppointment(ob.AppointmentId);
                        OnAppearing();
                    }
                    catch (Exception)
                    {
                        await DisplayAlert("Hata", "Randevu iptal edilemedi", "Ok");
                    }
                    
                }

            }
            else if (ob.ReviewControl == "Değerlendirmem")
            {
                await Navigation.PushAsync(new EvaluationPage(ob));
            }
            else
            {
                await Navigation.PushAsync(new RateAppointmentPage(ob));
            }

        }

    }

}