using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaloonHomePage : Shell
    {
        public SaloonHomePage()
        {
            InitializeComponent();


        }


        private async void Logout_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("ÇIKIŞ?", "Çıkış yapmak istediğinize emin misiniz?", "Evet", "Hayır");
            if (action)
            {
                var app = Application.Current as App;
                App.saloonAuthManager.LogOutAsync(app);
                App.Current.MainPage = new NavigationPage(new WelcomePage());
            }


        }

    }
}