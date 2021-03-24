using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakasUI.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaloonListPage : ContentPage
    {
        public SaloonListPage()
        {

            InitializeComponent();
            backclick();


            var SaloonList = new List<Saloon>
            {
                new Saloon {SaloonName="A Kuaför Salonu",SaloonImage="chair.png", WorkerCount=3, SaloonRate=8.0 },
                new Saloon {SaloonName="B Kuaför Salonu",SaloonImage="help.png", WorkerCount=4, SaloonRate=4.2 },
                new Saloon {SaloonName="C Kuaför Salonu",SaloonImage="user.png",WorkerCount=5, SaloonRate=5.2 }

            };

            KuaforListView.ItemsSource = SaloonList;
        }

        void backclick()
        {
            back.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PopAsync();

                })
            });
        }



    }
}