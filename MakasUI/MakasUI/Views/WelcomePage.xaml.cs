﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
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
        private async void Customer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginCustomerPage());
        }
        private async void Saloon_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginSaloonPage());
        }
        private void Quit_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private void HelpedButton(object sender, EventArgs e)
        {
            popUpImageView.IsVisible = false;
        }

        private void HelpButton_Clicked(object sender, EventArgs e)
        {
            popUpImageView.IsVisible = true;
        }

    }
}