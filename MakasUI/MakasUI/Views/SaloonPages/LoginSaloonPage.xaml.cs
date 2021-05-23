using MakasUI.Functions;
using MakasUI.Helpers.Validations.SaloonValidations.SaloonLoginValidations;
using MakasUI.Models.DtosForAuth;
using MakasUI.Services;
using MakasUI.Views.SaloonPages;
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
        public LoginSaloonPage(string phoneNum, string pass)
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            functions.registerSaloonclick(register, Navigation);
            Device.StartTimer(TimeSpan.FromSeconds(4), () => {

                Device.BeginInvokeOnMainThread(() => functions.Effect(logo));
                return true;
            });
            phone.Text = phoneNum;
            password.Text = pass;
        }
        public void ShowPass(object sender, EventArgs args)
        {
            password.IsPassword = password.IsPassword ? false : true;
            EyeVisible.Source = password.IsPassword ? "eye.png" : "closedeye.png";
        }


        PhoneNumberValidator phoneValidator = new PhoneNumberValidator();
        PasswordValidator passwordValidator = new PasswordValidator();
        private async void LoginClicked(object sender, EventArgs e)
        {
            string phoneValidate = phoneValidator.Validate(phone.Text);
            string passwordValidate = passwordValidator.Validate(password.Text);

            phoneErrorLabel.Text = phoneValidate;
            passwordErrorLabel.Text = passwordValidate;

            if (phoneValidate == null && passwordValidate==null)
            {
                var app = Application.Current as App;
                var saloon = new SaloonForLoginDto
                {
                    SaloonPhone = phone.Text,
                    SaloonPassword = password.Text

                };
                var result = await App.saloonAuthManager.PostLoginAsync(saloon);
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
                    App.Current.MainPage = new SaloonHomePage();
                }
                else
                {
                    password.Text = "";
                    await DisplayAlert("Hata", "Telefon numaranız ya da şifreniz yanlış", "Tamam");
                }
            }

           

        }
    }
}