using MakasUI.Functions;
using MakasUI.Models.DtosForAuth;
using MakasUI.ViewModels;
using MakasUI.ViewModels.SaloonAuth;
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
        public RegisterSaloonPage()
        {
            InitializeComponent();
            BindingContext = new SaloonSearchViewModel();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
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
            bool selectedGender = false;
            if (city.SelectedItem != null || district.SelectedItem != null)
            {
                /* var selectedGenderItem = gender.SelectedItem as Gender;
                 selectedGender = selectedGenderItem.Key;*/
                var selectedItem = city.SelectedItem as City;
                SelectedCity = selectedItem.Value;
                var selectedItem2 = district.SelectedItem as City;
                SelectedDistrict = selectedItem2.Value;
            }


            SaloonRegisterViewModel viewModel = new SaloonRegisterViewModel();

            if (passwordVerify.Text == passwordVerify.Text)
            {
                var saloon = new SaloonForRegisterDto
                {
                    SaloonName = name.Text,
                    SaloonPhone = phone.Text,
                    SaloonEmail = email.Text,
                    SaloonGender = true,
                    SaloonCity = SelectedCity,
                    SaloonDistrict = SelectedDistrict,
                    SaloonPassword = password.Text

                };
                try
                {
                    var result = await viewModel.InsertUser(saloon);
                    if (result == true)
                    {
                        await DisplayAlert("Registered", "Success!!", "OK");
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else if (result == false)
                    {
                        await DisplayAlert("Not Registered", "Success!!", "OK");
                    }
                }
                catch (Exception)
                {

                    await DisplayAlert("Not registered", "There is a problem!!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Not registered", "Passwords do not match!", "OK");
            }
        }
    }

    internal class Gender
    {
        public bool Key { get; set; }
        public string Value { get; set; }
    }
}
