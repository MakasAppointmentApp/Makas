using MakasUI.Functions;
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
        SaloonAuthServices _apiServices = new SaloonAuthServices();
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
            if (passwordVerify.Text == passwordVerify.Text)
            {
                var saloon = new SaloonForRegisterDto
                {
                    SaloonName = name.Text,
                    SaloonPhone = phone.Text,
                    SaloonEmail = email.Text,
                    SaloonGender = genderBoolean,
                    SaloonCity = SelectedCity,
                    SaloonDistrict = SelectedDistrict,
                    SaloonPassword = password.Text

                };
                var result = await _apiServices.PostRegisterAsync(saloon);
                if (result.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Başarıyla kayıt oluşturuldu", "OK");
                    await Navigation.PushAsync(new LoginSaloonPage(saloon.SaloonPhone, saloon.SaloonPassword));
                }
                else
                {
                    phone.Text = "";
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
