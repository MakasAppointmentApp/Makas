using MakasUI.Functions;
using MakasUI.Models.DtosForAuth;
using MakasUI.Services;
using MakasUI.Views.SaloonPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginSaloonPage : ContentPage
    {
        SaloonAuthServices _apiServices = new SaloonAuthServices();

        public LoginSaloonPage()
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            functions.registerSaloonclick(register, Navigation);
            Device.StartTimer(TimeSpan.FromSeconds(4), () => {

                Device.BeginInvokeOnMainThread(() => functions.Effect(logo));
                return true;
            });
        }
        public void ShowPass(object sender, EventArgs args)
        {
            password.IsPassword = password.IsPassword ? false : true;
            EyeVisible.Source = password.IsPassword ? "eye.png" : "closedeye.png";
        }


        private async void LoginClicked(object sender, EventArgs e)
        {
            var saloon = new SaloonForLoginDto
            {
                 SaloonPhone = phone.Text,
                 SaloonPassword = password.Text

            };
            var result = await _apiServices.PostLoginAsync(saloon);
            if (result.IsSuccessStatusCode.Equals(true))
            {
                string token = result.ToString();//DÜZENLE
                App.Current.MainPage = new SaloonHomePage();
            }
            else
            {
                await DisplayAlert("Hata", "Telefon numaranız ya da şifreniz yanlış", "Tamam");
            }

        }
    }
}