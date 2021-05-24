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
using MakasUI.Helpers.Validations.CustomerValidations.CustomerEditProfileValidations;

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
            changeName.Text = (presentCustomer.CustomerName + " " + presentCustomer.CustomerSurname);
            changeEmail.Text = presentCustomer.CustomerEmail;
            name.Text = presentCustomer.CustomerName;
            sName.Text = presentCustomer.CustomerSurname;
            emailEdit.Text = presentCustomer.CustomerEmail;


        }
        private async void ExitClicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("ÇIKIŞ?", "Çıkış yapmak istediğinize emin misiniz?", "Evet", "Hayır");
            if (action)
            {
                var app = Application.Current as App;
                App.customerAuthManager.LogOutAsync(app);
                App.Current.MainPage = new NavigationPage(new WelcomePage());
            }

        }

        NameUpdateValidatior nameUpdateValidatior = new NameUpdateValidatior();
        SurnameUpdateValidatior surnameUpdateValidatior = new SurnameUpdateValidatior();
        private async void CustomerName_Update_Button_Clicked(object sender, EventArgs e)
        {
            string nameUpdateValidate = nameUpdateValidatior.Validate(name.Text);
            string surnameUpdateValidate = surnameUpdateValidatior.Validate(sName.Text);

            if ((nameUpdateValidate == null && name.Text == presentCustomer.CustomerName) || (surnameUpdateValidate == null && sName.Text == presentCustomer.CustomerSurname))
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
            }
            else
            {
                nameAndSurnameUpdateErrorLabel.Text = nameUpdateValidate;
                nameAndSurnameUpdateErrorLabel.Text = surnameUpdateValidate;
            }
        }

        OldPasswordValidatior oldPasswordValidation = new OldPasswordValidatior();
        NewPasswordValidatior newPasswordValidation = new NewPasswordValidatior();
        VeriyfPasswordValidatior veriyfPasswordValidation = new VeriyfPasswordValidatior();
        private async void PasswordChange_Button_Clicked(object sender, EventArgs e)
        {
            string oldPasswordValidate = oldPasswordValidation.Validate(oldPassword.Text);
            string newPasswordValidate = newPasswordValidation.Validate(newPassword.Text);
            string verifyPasswordValidate = veriyfPasswordValidation.Validate(verifyPassword.Text);

            if (newPasswordValidate == null && verifyPasswordValidate == null && oldPasswordValidate == null)
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
                await DisplayAlert("Hata", "Eski Şifreniz hatalıdır","Tamam");
            }
            else
            {
                oldPasswordErrorLabel.Text = oldPasswordValidate;
                newPasswordErrorLabel.Text = newPasswordValidate;
            }
        }
    

    EmailUpdateValidator emailUpdateValidator = new EmailUpdateValidator();
    private async void CustomerMail_Update_Button_Clicked(object sender, EventArgs e)
    {
        string emailUpdateValidate = emailUpdateValidator.Validate(emailEdit.Text);

        if (emailUpdateValidate == null || emailUpdateValidate == presentCustomer.CustomerEmail)
        {
            var app = Application.Current as App;
            UpdateCustomerMailDto customer = new UpdateCustomerMailDto
            {
                Id = Convert.ToInt32(app.USER_ID),
                CustomerMail = emailEdit.Text
            };
            var response = await App.customerManager.UpdateCustomerMailAsync(customer);
            if (response.IsSuccessStatusCode.Equals(true))
            {
                await DisplayAlert("Tebrikler", "Müsteri Mail adresi değiştirildi, lütfen tekrar giriş yapınız.", "Tamam");
                App.Current.MainPage = new NavigationPage(new WelcomePage());
            }
        }
        else
        {
            emailUpdateErrorLabel.Text = emailUpdateValidate;
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