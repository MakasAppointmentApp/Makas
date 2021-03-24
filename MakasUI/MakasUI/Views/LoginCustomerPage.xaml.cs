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
        public LoginCustomerPage()
        {
            InitializeComponent();
            backclick();
            registerclick();
            Device.StartTimer(TimeSpan.FromSeconds(4), () => {

                Device.BeginInvokeOnMainThread(() => Effect());
                return true;
            });
        }
        private async void Effect()
        {
            uint transitionTime = 600;
            double displacement = logo.Width;

            await Task.WhenAll(
                logo.FadeTo(0, transitionTime, Easing.Linear),
                logo.TranslateTo(-displacement, logo.Y, transitionTime, Easing.CubicInOut));
            await logo.TranslateTo(displacement, 0, 0);
            await Task.WhenAll(
                logo.FadeTo(1, transitionTime, Easing.Linear),
                logo.TranslateTo(0, logo.Y, transitionTime, Easing.CubicInOut));
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
        void registerclick()
        {
            var signup_tap = new TapGestureRecognizer();
            signup_tap.Tapped += async (s, e) =>
            {
                await Navigation.PushAsync(new RegisterCustomerPage());
            };
            register.GestureRecognizers.Add(signup_tap);
        }
        public void ShowPass(object sender, EventArgs args)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
            EyeVisible.Source = Password.IsPassword ? "eye.png" : "closedeye.png";
        }
        private async void Login_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CustomerHomePage();
        }
        
    }
}