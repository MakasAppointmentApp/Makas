using MakasUI.Functions;
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
            ItemFunctions functions = new ItemFunctions();
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
                await Navigation.PushAsync(new RateAppointmentPage(ob.SaloonName, ob.WorkerName, ob.Rate));
                await btn.ScaleTo(1.0, 50, Easing.SpringOut);
            }
           
        }
    }
}