using MakasUI.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MakasUI.Services.CustomerServices;
using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerProfilePage : ContentPage
    {
        Customer presentCustomer;
        public CustomerProfilePage()
        {
            InitializeComponent();
           
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await GetCustomerProfile();
            changeName.Text = (presentCustomer.CustomerName+" "+presentCustomer.CustomerSurname);
            changeEmail.Text = presentCustomer.CustomerEmail;
            name.Text = presentCustomer.CustomerName;
            sName.Text = presentCustomer.CustomerSurname;
            email.Text = presentCustomer.CustomerEmail;


        }
        private void ExitClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new WelcomePage());

        }

        private async void CustomerName_Update_Button_Clicked(object sender, EventArgs e)
        {
            if (name.Text == null || name.Text == "" || (name.Text == presentCustomer.CustomerName && sName.Text == presentCustomer.CustomerSurname))
            {
                await DisplayAlert("Hata", "Gerekli yerleri doldurun veya değiştirin!", "Tamam");
            }
            else
            {
                var app = Application.Current as App;
                UpdateCustomerNameDto customer = new UpdateCustomerNameDto
                {
                    Id = Convert.ToInt32(app.USER_ID),
                    CustomerName = name.Text,
                    CustomerSurName = sName.Text
                };
                var response = await App.customerManager.UpdateCustomerNameAsync(customer);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Müsteri adı değiştirildi, lütfen tekrar giriş yapınız.", "Tamam");
                    App.Current.MainPage = new NavigationPage(new WelcomePage());
                }
                else
                {
                    await DisplayAlert("Hata", "Müsteri adı değiştirilemedi", "Tamam");
                }
            }
        }
        private async void PasswordChange_Button_Clicked(object sender, EventArgs e)
        {
            if (verifyPassword.Text == newPassword.Text &&
                (verifyPassword.Text != null || verifyPassword.Text != "") &&
                (newPassword.Text != null || newPassword.Text != "") &&
                (oldPassword.Text != null || oldPassword.Text != "")
                )
            {
                var app = Application.Current as App;
                UpdateCustomerPasswordDto customer = new UpdateCustomerPasswordDto
                {
                    Id = Convert.ToInt32(app.USER_ID),
                    OldPassword = oldPassword.Text,
                    NewPassword = newPassword.Text
                };
                var response = await App.customerManager.UpdateCustomerPasswordAsync(customer);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Şifre değiştirildi, lütfen giriş yapınız.", "Tamam");
                    App.Current.MainPage = new NavigationPage(new WelcomePage());
                }
                else
                {
                    await DisplayAlert("Hata", "Şifre değiştirilemedi", "Tamam");
                }
            }
            else
            {
                await DisplayAlert("Hata", "Şifreler uyuşmuyor", "Tamam");
            }
        }
        private async void CustomerMail_Update_Button_Clicked(object sender, EventArgs e)
        {
            if (email.Text == null || email.Text == "" || email.Text == presentCustomer.CustomerEmail)
            {
                await DisplayAlert("Hata", "Gerekli yerleri doldurun veya değiştirin!", "Tamam");
            }
            else
            {
                var app = Application.Current as App;
                UpdateCustomerMailDto customer = new UpdateCustomerMailDto
                {
                    Id = Convert.ToInt32(app.USER_ID),
                    CustomerMail = email.Text
                };
                var response = await App.customerManager.UpdateCustomerMailAsync(customer);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Müsteri Mail adresi değiştirildi, lütfen tekrar giriş yapınız.", "Tamam");
                    App.Current.MainPage = new NavigationPage(new WelcomePage());
                }
                else
                {
                    await DisplayAlert("Hata", "Müsteri Mail adresi değiştirilemedi! Lütfen daha önce kullanılmayan bir Mail giriniz.", "Tamam");
                }
            }
        }
        public void ShowPass(object sender, EventArgs args)
        {
            newPassword.IsPassword = newPassword.IsPassword ? false : true;
            EyeVisible.Source = newPassword.IsPassword ? "eye.png" : "closedeye.png";            
            
        }

        private async Task GetCustomerProfile()
        {
            var app = Application.Current as App;
            var customer = await App.customerManager.GetCustomerAsync(Convert.ToInt32(app.USER_ID));
            presentCustomer = customer;
        }


    }
}