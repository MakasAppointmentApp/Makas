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
        public SaloonProfilePage()
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
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
        public SaloonProfilePage(string saloonName, string saloonImage, double saloonRate)
        {
            
            InitializeComponent();
            this.sName.Text = saloonName;
            this.sImage.Source = saloonImage;
            this.sRate.Text = Convert.ToString(saloonRate);
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
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
    }
}