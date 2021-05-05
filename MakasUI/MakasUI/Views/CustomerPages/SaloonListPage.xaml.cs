using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Views.CustomerPages;
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
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);

            var SaloonList = new List<Saloon>
            {
                new Saloon {SaloonName="A Kuaför Salonu", SaloonRate=8.0 },
                new Saloon {SaloonName="B Kuaför Salonu", SaloonRate=4.2 },
                new Saloon {SaloonName="C Kuaför Salonu", SaloonRate=5.2 }

            };

            KuaforListView.ItemsSource = SaloonList;
        }

        private async void Go_Profile_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;

            Saloon ob = btn.CommandParameter as Saloon;
           
            await Navigation.PushAsync(new SaloonProfilePage(ob));
            //await Navigation.PushAsync(new SaloonProfilePage());
        }
    }
}