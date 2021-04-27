using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MakasUI.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PastAppointmentsPage : ContentPage
    {
        ViewCell lastCell;
        public PastAppointmentsPage()
        {
            InitializeComponent();
            datePicker.MaximumDate = DateTime.Now;
            var Workers = new List<Worker>
            {
                new Worker {WorkerName="Muhammed Güven",WorkerImage="chair.png",WorkerRate=8.2 },
                new Worker {WorkerName="Danyel Kar",WorkerImage="help.png",WorkerRate=5.6 },
                new Worker {WorkerName="Mustafa Emre Orbağ",WorkerImage="user.png",WorkerRate=4.4 },
                new Worker {WorkerName="Mustafa Orbağ",WorkerImage="user.png",WorkerRate=5.4 }

            };
            workers.ItemsSource = Workers;
            var CustomersAppointments = new List<Customers>
            {
                new Customers {CustomerName="MEORBAG",Date="15:00"},
                new Customers {CustomerName="KARDANYEL",Date="17:00"},
                new Customers {CustomerName="GWENSTACY",Date="19:00"},
                new Customers {CustomerName="Muhammed Güven",Date="20:00"}

            };

            FavoriteListView.ItemsSource = CustomersAppointments;

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
    }
}