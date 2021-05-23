using MakasUI.Functions;
using MakasUI.Helpers.Validations.SaloonValidations.SaloonRegisterValidations;
using MakasUI.Models.DtosForAuth;
using MakasUI.Services;
using MakasUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterSaloonPage : ContentPage
    {
        bool genderBoolean = false;
        public RegisterSaloonPage()
        {
            InitializeComponent();
            BindingContext = new SaloonSearchViewModel();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            gender.ItemsSource = new List<Gender>
            {
                new Gender {Value="Erkek"},
                new Gender{Value="Kadın"}
            };
       
        }
        public void ShowPass(object sender, EventArgs args)
        {
            password.IsPassword = password.IsPassword ? false : true;
            EyeVisible.Source = password.IsPassword ? "eye.png" : "closedeye.png";
        }

        SaloonNameValidator saloonNameValidator = new SaloonNameValidator();
        PhoneNumberValidator phoneNumberValidator = new PhoneNumberValidator();
        EmailValidator emailValidator = new EmailValidator();
        GenderValidator genderValidator = new GenderValidator();
        CityValidator cityValidator = new CityValidator();
        DistrictValidator districtValidator = new DistrictValidator();
        PasswordValidator passwordValidator = new PasswordValidator();
        PasswordVerifyValidator passwordVerifyValidator = new PasswordVerifyValidator();


        async void Button_Clicked(object sender, EventArgs e)
        {
    
            var SelectedCity = "";
            var SelectedDistrict = "";
            if (city.SelectedItem != null || district.SelectedItem != null)
            {

                
                var selectedItem = city.SelectedItem as City;
                SelectedCity = selectedItem.Value;
                var selectedItem2 = district.SelectedItem as City;
                SelectedDistrict = selectedItem2.Value;


            }
            string saloonNameValidate = saloonNameValidator.Validate(registerSaloonName.Text);
            string phoneValidate = phoneNumberValidator.Validate(registerPhone.Text);
            string emailValidate = emailValidator.Validate(registerEmail.Text);
            string genderValidate = genderValidator.Validate(genderBoolean.ToString());
            string cityValidate = cityValidator.Validate(SelectedCity);
            string districtValidate = districtValidator.Validate(SelectedDistrict);
            string passwordValidate = passwordValidator.Validate(password.Text);
            string passwordVerifyValidate = passwordVerifyValidator.Validate(passwordVerify.Text);
            if (passwordVerify.Text == passwordVerify.Text)
            {
                var saloon = new SaloonForRegisterDto
                {
                    SaloonName = registerSaloonName.Text,
                    SaloonPhone = registerPhone.Text,
                    SaloonEmail = registerEmail.Text,
                    SaloonGender = genderBoolean,
                    SaloonCity = SelectedCity,
                    SaloonDistrict = SelectedDistrict,
                    SaloonPassword = password.Text

                };
                var result = await App.saloonAuthManager.PostRegisterAsync(saloon);
                if (result.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Başarıyla kayıt oluşturuldu", "OK");
                    await Navigation.PushAsync(new LoginSaloonPage(saloon.SaloonPhone, saloon.SaloonPassword));
                }
                else
                {
                    registerPhone.Text = "";
                    await DisplayAlert("Hata", "Bu telefon numarası sistemde kayıtlı ya da bir hata oluştu", "OK");
                }
            }
            else
            {
                await DisplayAlert("Şifre", "Şifreler aynı değil", "OK");
            }
        }
     
        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {

            Picker picker = sender as Picker;
            var selectedGender = (Gender)picker.SelectedItem;
            if (selectedGender.Value == "Erkek")
            {
                genderBoolean = true;
            }
            else
            {
                genderBoolean = false;
            }
            
        }
    }

    internal class Gender
    {
        public string Value { get; set; }
    }
}
