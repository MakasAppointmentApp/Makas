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
using MakasUI.Helpers.Validations.CustomerValidations.CustomerRegisterValidations;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCustomerPage : ContentPage
    {
        public RegisterCustomerPage()
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
        }
        public void ShowPass(object sender, EventArgs args)
        {
            customerPassword.IsPassword = customerPassword.IsPassword ? false : true;
            EyeVisible.Source = customerPassword.IsPassword ? "eye.png" : "closedeye.png";
        }

        CustomerNameValidator customerNameValidator = new CustomerNameValidator();
        CustomerSurnameValidator customerSurnameValidator = new CustomerSurnameValidator();
        CustomerEmailValidator customerEmailValidator = new CustomerEmailValidator();
        CustomerPasswordValidator customerPasswordValidator = new CustomerPasswordValidator();
        CustomerVerifyValidator customerVerifyValidator = new CustomerVerifyValidator();
        async void Register_Clicked(object sender, EventArgs e)
        {
            string customerNameValidate = customerNameValidator.Validate(customerName.Text);
            string customerSurnameValidate = customerPasswordValidator.Validate(customerSurname.Text);
            string customerEmailValidate = customerEmailValidator.Validate(customerEmail.Text);
            string customerPasswordValidate = customerPasswordValidator.Validate(customerPassword.Text);
            string customerVerifyValidate = customerVerifyValidator.Validate(checkPassword.Text);


            if (customerPassword.Text != checkPassword.Text)
            {
                verifyPasswordErrorLabel.Text = "Şifreler uyuşmamaktadır.";
                customerPasswordErrorLabel.Text = "Şifreler uyuşmamaktadır.";
            }
            else
            {
                if (customerNameValidate == null &&
               customerSurnameValidate == null &&
               customerEmailValidate == null &&
               customerPasswordValidate == null &&
               customerVerifyValidate == null
               )
                {
                    var customer = new CustomerForRegisterDto
                    {
                        CustomerName = customerName.Text,
                        CustomerSurname = customerSurname.Text,
                        CustomerEmail = customerEmail.Text,
                        CustomerPassword = customerPassword.Text
                    };
                    var result = await App.customerAuthManager.PostRegisterAsync(customer);
                    if (result.IsSuccessStatusCode.Equals(true))
                    {
                        await DisplayAlert("Tebrikler", "Başarıyla kayıt oluşturuldu.", "Tamam");
                        await Navigation.PushAsync(new LoginCustomerPage(customer.CustomerEmail, customer.CustomerPassword));
                    }
                    else
                    {
                        await DisplayAlert("Hata", "Bu email kullanılmaktadır.", "Tamam");
                    }
                }
                customerNameErrorLabel.Text = customerNameValidate;
                customerSurnameErrorLabel.Text = customerSurnameValidate;
                customerEmailErrorLabel.Text = customerEmailValidate;
                customerPasswordErrorLabel.Text = customerPasswordValidate;
                verifyPasswordErrorLabel.Text = customerVerifyValidate;
            }  

        }
    }
}