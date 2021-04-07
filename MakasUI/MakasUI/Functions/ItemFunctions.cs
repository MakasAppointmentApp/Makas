using MakasUI.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MakasUI.Functions
{
    public class ItemFunctions
    {
        public async void Effect(Image logo)
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
        public void backclick(Image back, INavigation Navigation)
        {
            back.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PopAsync();

                })
            });
        }
        public  void ButtonsLabelClick(Label lbl, ImageButton image)
        {
            var signup_tap = new TapGestureRecognizer();
            signup_tap.Tapped += async (s, e) =>
            {
                await lbl.ScaleTo(1.2, 250, Easing.SpringIn);
                image.PropagateUpClicked();
                await lbl.ScaleTo(1.0, 50, Easing.SpringOut);
            };
            lbl.GestureRecognizers.Add(signup_tap);
            
        }
        
        public void registerCustomerclick(Label register, INavigation Navigation)
        {
            var signup_tap = new TapGestureRecognizer();
            signup_tap.Tapped += async (s, e) =>
            {
                await register.ScaleTo(1.2, 250, Easing.SpringIn);
                await Navigation.PushAsync(new RegisterCustomerPage());
                await register.ScaleTo(1.0, 50, Easing.SpringOut);
            };
            register.GestureRecognizers.Add(signup_tap);
        }
        public void registerSaloonclick(Label register, INavigation Navigation)
        {
            var signup_tap = new TapGestureRecognizer();
            signup_tap.Tapped += async (s, e) =>
            {
                await register.ScaleTo(1.2, 250, Easing.SpringIn);
                await Navigation.PushAsync(new RegisterSaloonPage());
                await register.ScaleTo(1.0, 50, Easing.SpringOut);
            };
            register.GestureRecognizers.Add(signup_tap);
        }




    }
}
