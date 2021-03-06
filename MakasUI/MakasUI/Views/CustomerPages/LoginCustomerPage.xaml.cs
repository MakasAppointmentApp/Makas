using MakasUI.Functions;
using MakasUI.Helpers.Validations.CustomerValidations.CustomerLogin;
using MakasUI.Models.DtosForAuth;
using MakasUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            functions.registerCustomerclick(register, Navigation);
            Device.StartTimer(TimeSpan.FromSeconds(4), () => {

                Device.BeginInvokeOnMainThread(() => functions.Effect(logo));
                return true;
            });
        }
        public LoginCustomerPage(string CustomerEmail, string CustomerPassword)
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            functions.registerCustomerclick(register, Navigation);
            Device.StartTimer(TimeSpan.FromSeconds(4), () => {

                Device.BeginInvokeOnMainThread(() => functions.Effect(logo));
                return true;
            });
            email.Text = CustomerEmail;
            password.Text = CustomerPassword;
        }
        public void ShowPass(object sender, EventArgs args)
        {
            password.IsPassword = password.IsPassword ? false : true;
            EyeVisible.Source = password.IsPassword ? "eye.png" : "closedeye.png";
        }

        EmailValidator emailValidator = new EmailValidator();
        PasswordValidator passwordValidator = new PasswordValidator();
        private async void Login_Clicked(object sender, EventArgs e)
        {           
            string emailValidate = emailValidator.Validate(email.Text);           
            string passwordValidate = passwordValidator.Validate(password.Text);

            emailErrorLabel.Text = emailValidate;
            passwordErrorLabel.Text = passwordValidate;

            if (emailValidate == null && passwordValidate == null)
            {
                var app = Application.Current as App;
                var customer = new CustomerForLoginDto
                {
                    CustomerEmail = email.Text,
                    CustomerPassword = password.Text
                };
                var result = await App.customerAuthManager.PostLoginAsync(customer);
                if (result.IsSuccessStatusCode.Equals(true))
                {
                    string response = await result.Content.ReadAsStringAsync();
                    app.TOKEN = JsonConvert.DeserializeObject<string>(response);
                    var jwtHandler = new JwtSecurityTokenHandler();
                    var token = jwtHandler.ReadJwtToken(app.TOKEN);
                    app.USER_ID = token.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;
                    app.USER_NAME = token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
                    app.LoggedIn = "true";
                    await DisplayAlert("Hoş geldiniz", app.USER_NAME, "Teşekkürler");
                    App.Current.MainPage = new CustomerHomePage();
                }
                else
                {
                    password.Text = "";
                    await DisplayAlert("Hata", "E-Mail'iniz ya da şifreniz yanlış. Lütfen kontrol edin.", "Tamam");
                }
            }         
        }
    }
}