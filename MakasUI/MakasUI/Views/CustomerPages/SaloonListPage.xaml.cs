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


            var Categories = new List<Kuafor>
            {
                new Kuafor {kuaforName="MEO kuafor",kuaforPP="chair.png",kuaforRate="8,2" },
                new Kuafor {kuaforName="DAN kuafor",kuaforPP="help.png",kuaforRate="4,2" },
                new Kuafor {kuaforName="GWEN kuafor",kuaforPP="user.png",kuaforRate="5,2" }

            };

            KuaforListView.ItemsSource = Categories;
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