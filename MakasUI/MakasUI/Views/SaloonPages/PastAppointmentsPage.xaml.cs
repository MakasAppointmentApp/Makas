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
    public partial class PastAppointmentsPage : ContentPage
    {
        public PastAppointmentsPage()
        {
            InitializeComponent();

            var CustomersAppointments = new List<Customers>
            {
                new Customers {CustomerName="MEORBAG",Date="15:00"},
                new Customers {CustomerName="KARDANYEL",Date="17:00"},
                new Customers {CustomerName="GWENSTACY",Date="19:00"},
                new Customers {CustomerName="Muhammed Güven",Date="20:00"}

            };

            FavoriteListView.ItemsSource = CustomersAppointments;
        }
    }
}