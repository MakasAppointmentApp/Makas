using MakasUI.Models;
using System;
using System.Collections.Generic;
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
        public MyAppointmentsPage()
        {
            InitializeComponent();

            var MyAppointments = new List<Appointment>
            {
                new Appointment { SaloonName="A Kuaför Salonu", WorkerName="Muhammed Güven", Date = DateTime.Now, Hour = DateTime.Now, Rate=7.5, Review="Değerlendirmem" },
                new Appointment { SaloonName="B Kuaför Salonu", WorkerName="Mustafa Emre Orbağ", Date = DateTime.Now, Hour = DateTime.Now, Rate=7.2, Review="Değerlendirmem" },
                new Appointment { SaloonName="C Kuaför Salonu", WorkerName="Danyel Kar", Date = DateTime.Now, Hour = DateTime.Now, Rate=7.7, Review="Değerlendir" },
            };
            AppointmentsListView.ItemsSource = MyAppointments;


        }

        async void Review_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RateAppointmentPage());
        }
    }
}