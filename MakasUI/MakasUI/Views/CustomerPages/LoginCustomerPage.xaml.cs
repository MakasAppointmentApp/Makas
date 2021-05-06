using MakasUI.Functions;
using MakasUI.Models.DtosForAuth;
using MakasUI.Services;
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
    public partial class LoginCustomerPage : ContentPage
    {
        CustomerAuthServices _apiServices = new CustomerAuthServices();
        public LoginCustomerPage()
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            functions.registerCustomerclick(register, Navigation);
            Device.StartTimer(TimeSpan.FromSeconds(4), () => {

                Device.BeginInvokeOnMainThread(() => functions.Effect(logo));
                return true;
            });
        }
        public void ShowPass(object sender, EventArgs args)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
            EyeVisible.Source = Password.IsPassword ? "eye.png" : "closedeye.png";
        }
        private async void Login_Clicked(object sender, EventArgs e)
        {
            var customer = new CustomerForLoginDto
            {
                CustomerEmail = email.Text,
                CustomerPassword = Password.Text
            };
            var result = await _apiServices.PostLoginAsync(customer);
            if (result.IsSuccessStatusCode.Equals(true))
            {
                string token = result.ToString();
                App.Current.MainPage = new CustomerHomePage();
            }
            else
            {
                Password.Text = "";
                await DisplayAlert("Hata", "E-Mail'iniz ya da şifreniz yanlış. Lütfen kontrol edin.", "Tamam");
            }
        }

       int Topla(int a, int b)
        {
            return a + b;
        }

    }
}