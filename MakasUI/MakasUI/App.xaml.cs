using MakasUI.Views;
using MakasUI.Views.SaloonPages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "Expander_Experimental"
            });
            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
