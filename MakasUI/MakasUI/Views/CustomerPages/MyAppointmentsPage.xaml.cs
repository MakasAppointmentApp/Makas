using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
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
                    AppointmentsCollection.Add(item);
                }
                AppointmentsListView.ItemsSource = AppointmentsCollection;
            }
            catch (Exception)
            {
                await DisplayAlert("Hata", "Randevu bulunamadı", "Ok");
            }
        }
        /*async void Review_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            await btn.ScaleTo(1.2, 250, Easing.SpringIn);
            Appointment ob = btn.CommandParameter as Appointment;
            if (ob.Review == "Değerlendir")
            {
                await Navigation.PushAsync(new RateAppointmentPage(ob.SaloonName, ob.WorkerName, ob.Rate));
                await btn.ScaleTo(1.0, 50, Easing.SpringOut);
            }
            else
            {//Burada değerlendirmem sayfasına gitmeli
                await Navigation.PushAsync(new EvaluationPage());
                await btn.ScaleTo(1.0, 50, Easing.SpringOut);
            }
           
        }*/
    }
}