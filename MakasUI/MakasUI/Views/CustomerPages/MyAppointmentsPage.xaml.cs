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
        Saloon presentSaloon;
        string reviewControl = "";
        SaloonRestService service = new SaloonRestService();
        public ObservableCollection<CustomerAppointmentsDto> AppointmentsCollection { get; set; }

        public MyAppointmentsPage()
        {
            InitializeComponent();

            ItemFunctions functions = new ItemFunctions();
            AppointmentsCollection = new ObservableCollection<CustomerAppointmentsDto>();

            /*var MyAppointments = new List<Appointment>
            {
                new Appointment { SaloonName="A Kuaför Salonu", WorkerName="Muhammed Güven", Date = DateTime.Now, Hour = DateTime.Now, Rate=7.5, Review="Değerlendirmem" },
                new Appointment { SaloonName="B Kuaför Salonu", WorkerName="Mustafa Emre Orbağ", Date = DateTime.Now, Hour = DateTime.Now, Rate=7.2, Review="Değerlendirmem" },
                new Appointment { SaloonName="C Kuaför Salonu", WorkerName="Danyel Kar", Date = DateTime.Now, Hour = DateTime.Now, Rate=7.7, Review="Değerlendir" },
            };
            AppointmentsListView.ItemsSource = MyAppointments;*/
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
                    /*ReviewDto rev = new ReviewDto
                    {
                        SaloonId = item.SaloonId,
                        WorkerId = item.WorkerId,
                        CustomerId = Convert.ToInt32(presentCustomer.Id),
                        AppointmentId = item.AppointmentId
                    };*/
                    var response = await App.customerManager.GetReviewIfExists(item.SaloonId, Convert.ToInt32(presentCustomer.Id), item.WorkerId, item.AppointmentId);
                    if (item.Date > DateTime.Now)
                    {
                        item.reviewControl = "İptal Et";
                    }
                    else if (response.IsSuccessStatusCode.Equals(true))
                    {
                        item.reviewControl = "Değerlendirmem";
                    }
                    else
                    {
                        item.reviewControl = "Değerlendir";
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
        async void Review_Clicked(object sender, EventArgs e)
        {

            ImageButton btn = (ImageButton)sender;
            await btn.ScaleTo(1.2, 250, Easing.SpringIn);
            ReviewDto ob = btn.CommandParameter as ReviewDto;

            if (ob.reviewControl == "İptal Et")
            {
                await DisplayAlert("İptal", "Randevuyu iptal etmek istediğinize emin misiniz?", "Ok");

            }
            else if (ob.reviewControl == "Değerlendirmem")
            {
                await Navigation.PushAsync(new EvaluationPage());
            }
            else
            {
                await Navigation.PushAsync(new RateAppointmentPage(ob));
            }

            /*var app = Application.Current as App;
            ReviewDto rev = new ReviewDto
            {
                SaloonId = ob.SaloonId,
                WorkerId = ob.WorkerId,
                CustomerId = Convert.ToInt32(app.USER_ID),
                AppointmentId = ob.AppointmentId
            };
            var response = await App.customerManager.GetReviewIfExists(rev);

            if (response.IsSuccessStatusCode.Equals(true))
            {
                await Navigation.PushAsync(new EvaluationPage(rev));

            }
            else
            {
                await DisplayAlert("Yorumunu Yap", "Randevuna değerlendirmeni yapabilirsin.", "Tamam");
                //Burada değerlendirmem sayfasına gitmeli

               await btn.ScaleTo(1.0, 50, Easing.SpringOut);




         }*/
        }

        /*if (ob.Review == "Değerlendir")
        {
            await Navigation.PushAsync(new RateAppointmentPage(ob.SaloonName, ob.WorkerName, ob.Rate));
            await btn.ScaleTo(1.0, 50, Easing.SpringOut);
        }
        else
        {//Burada değerlendirmem sayfasına gitmeli
            await Navigation.PushAsync(new EvaluationPage());
            await btn.ScaleTo(1.0, 50, Easing.SpringOut);
        }*/

    }

}