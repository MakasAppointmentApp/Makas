using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakasUI.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FutureAppointmentsPage : ContentPage
    {
        public FutureAppointmentsPage()
        {
            InitializeComponent();

            var CustomersAppointments = new List<Customers>
            {
                new Customers {CustomerName="Mustafa Emre Orbağ",Date="15:00"},
                new Customers {CustomerName="Dan Bilzerian",Date="17:00"},
                new Customers {CustomerName="Muhammed Gwen",Date="19:00"},
                new Customers {CustomerName="Danyel Kar",Date="20:00"}

            };

            FavoriteListView.ItemsSource = CustomersAppointments;
        }
    }
}