using MakasUI.Models.DtosForCustomer;
using MakasUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaloonSearchPage : ContentPage
    {
        bool genderBoolean = false;
       

        public SaloonSearchPage()
        {
            InitializeComponent();
            BindingContext = new SaloonSearchViewModel();

            genderPicker.ItemsSource = new List<Gender>
            {
                new Gender {Value="Erkek"},
                new Gender{Value="Kadın"}
            };

        }
        private async void Listele_Clicked(object sender, EventArgs e)
        {

            var SelectedCity = "";
            var SelectedDistrict = "";

            if (cityPicker.SelectedItem != null && districtPicker.SelectedItem != null && genderPicker.SelectedItem !=null )
            {

                var selectedItem = cityPicker.SelectedItem as City;
                SelectedCity = selectedItem.Value;
                var selectedItem2 = districtPicker.SelectedItem as City;
                SelectedDistrict = selectedItem2.Value;
               


                var listedSaloon = new SearchSaloonsDto
                {
                    SaloonCity = SelectedCity,
                    SaloonDistrict = SelectedDistrict,
                    SaloonGender = genderBoolean

                };

                await Navigation.PushAsync(new SaloonListPage(listedSaloon));


            }
            else
            {
                await DisplayAlert("Hata", "Şehir, ilçe ve cinsiyet  seçmelisiniz", "Tamam");
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
        internal class Gender
        {
            public string Value { get; set; }
        }


    }
}