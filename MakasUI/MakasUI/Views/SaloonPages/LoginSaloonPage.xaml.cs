using MakasUI.Functions;
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
            Password.IsPassword = Password.IsPassword ? false : true;
            EyeVisible.Source = Password.IsPassword ? "eye.png" : "closedeye.png";
        }


        private void LoginClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SaloonHomePage();
        }
    }
}