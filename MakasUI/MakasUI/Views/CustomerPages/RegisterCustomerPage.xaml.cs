using MakasUI.Functions;
using System;
using MakasUI.Models.DtosForAuth;
using MakasUI.Services;
using MakasUI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCustomerPage : ContentPage
    {
        CustomerAuthServices _apiServices = new CustomerAuthServices();
        public RegisterCustomerPage()
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
        }
        public void ShowPass(object sender, EventArgs args)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
            EyeVisible.Source = Password.IsPassword ? "eye.png" : "closedeye.png";
        }

        async void registerClicked(object sender, EventArgs e)
        {

            if (Password.Text == checkPasswordEntry.Text)
            {
                var customer = new CustomerForRegisterDto
                {
                    CustomerName = name.Text,
                    CustomerSurname = surname.Text,
                    CustomerEmail = email.Text,
                    CustomerPassword = Password.Text
                };
                var result = await _apiServices.PostRegisterAsync(customer);
                if (result.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Başarıyla kayıt oluşturuldu", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    email.Text = "";
                    await DisplayAlert("Hata", "Bu E-Mail daha önceden kullanılıyor.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Şifre", "Şifreler aynı değil!", "OK");
            }

        }
    }
}