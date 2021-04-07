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
    public partial class SaloonProfilePage : ContentPage
    {

        public SaloonProfilePage(Saloon ob)
        {
            
            InitializeComponent();
            this.sName.Text = ob.SaloonName;
            this.sImage.Source = ob.SaloonImage;
            this.sRate.Text = Convert.ToString(ob.SaloonRate);
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            functions.ButtonsLabelClick(labelComment, butComment);
            functions.ButtonsLabelClick(labelFav, butFav);
            var Workers = new List<Worker>
            {
                new Worker {WorkerName="Muhammed Güven",WorkerImage="chair.png",WorkerRate=8.2 },
                new Worker {WorkerName="Danyel Kar",WorkerImage="help.png",WorkerRate=5.6 },
                new Worker {WorkerName="Mustafa Emre Orbağ",WorkerImage="user.png",WorkerRate=4.4 },
                new Worker {WorkerName="Mustafa Orbağ",WorkerImage="user.png",WorkerRate=5.4 }

            };
            workers.ItemsSource = Workers;

            var Prices = new List<Price>
            {
                new Price { PriceName="Saç Kesim" , PriceNumber = 50},
                new Price { PriceName="Saç Boyama" , PriceNumber = 60},
                new Price { PriceName="Manikür" , PriceNumber = 40},
                new Price { PriceName="Pedikür" , PriceNumber = 10},
                new Price { PriceName="Masaj" , PriceNumber = 20},
            };
            PriceListView.ItemsSource = Prices;
        }

        private async void Comments_Clicked(object sender, EventArgs e)
        {   
            await Navigation.PushAsync(new CommentsPage(sName.Text, sRate.Text));
        }
        private async void Get_Appointment_Clicked(object sender, EventArgs e)
        {
            
            var button = sender as Button;
            var model = button.BindingContext as Worker;
            await button.ScaleTo(1.2, 250, Easing.SpringIn);
            var saloon = new Saloon { SaloonName = sName.Text, SaloonRate = Convert.ToDouble(sRate.Text) };
            await Navigation.PushAsync(new GetAppointmentPage(model,saloon));
            await button.ScaleTo(1.0, 50, Easing.SpringOut);
        }
    }
}