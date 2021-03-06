using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditSaloonPage : ContentPage
    {

        public byte[] imagebyte;

        public ObservableCollection<Price> PricesObservable { get; set; }

        public EditSaloonPage()
        {
            InitializeComponent();

            ItemFunctions function = new ItemFunctions();
            function.backclick(back, Navigation);

        }
        public EditSaloonPage(string text, ImageSource profilePhoto, string saloonLocation)
        {
            InitializeComponent();
            this.saloonName.Text = text;
            this.saloonProfilePhoto.Source = profilePhoto;
            this.saloonLocation.Text = saloonLocation;
            PricesObservable = new ObservableCollection<Price>();
            ItemFunctions function = new ItemFunctions();
            function.backclick(back, Navigation);
        }



        public void ShowPass(object sender, EventArgs args)
        {
            oldPassword.IsPassword = oldPassword.IsPassword ? false : true;
            EyeVisible.Source = oldPassword.IsPassword ? "eye.png" : "closedeye.png";
        }
        private async void AddPhotoFromGallery(object sender, EventArgs e)
        {
            try
            {

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported || !CrossMedia.Current.IsTakePhotoSupported)
                {

                    await DisplayAlert("Desteklenmiyor", "Cihazınız bu özelliği desteklemiyor!", "Tamam");
                    return;
                }
                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImage == null)
                {
                    await DisplayAlert("Hata", "Fotoğraf seçilemedi. Tekrar deneyiniz.", "Tamam");

                }
                selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                imagebyte = GetImageStreamAsBytes(selectedImageFile.GetStream());

            }
            catch (Exception)
            {
                selectedImage.Source = "camera.png";
                await DisplayAlert("Hata", "Fotoğraf seçilemedi. Tekrar deneyiniz.", "Tamam");

            }
        }
        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private async void AddWorker_Button_Clicked(object sender, EventArgs e)
        {
            if (kuaförName.Text != null || kuaförName.Text != "")
            {
                var app = Application.Current as App;
                AddWorkerDto worker = new AddWorkerDto
                {

                    SaloonId = Convert.ToInt32(app.USER_ID),
                    WorkerName = kuaförName.Text,
                    WorkerPhoto = imagebyte
                };
                var response = await App.saloonManager.AddWorkerAsync(worker);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Yeni çalışan ekledi", "Tamam");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Hata", "Yeni çalışan eklenemedi!", "Tamam");
                }

            }
            else
            {
                await DisplayAlert("Hata", "Gerekli yerleri doldurun!", "Tamam");
            }

        }
        private async void AddPrice_Button_Clicked(object sender, EventArgs e)
        {
            if (priceName.Text != null || priceName.Text != "" || priceAmount.Text != null || priceAmount.Text != "")
            {
                var app = Application.Current as App;
                AddPriceDto price = new AddPriceDto
                {
                    SaloonId = Convert.ToInt32(app.USER_ID),
                    PriceName = priceName.Text,
                    PriceAmount = Convert.ToDouble(priceAmount.Text)
                };
                var response = await App.saloonManager.AddPriceAsync(price);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Yeni işlem ekledi", "Tamam");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Hata", "Yeni işlem eklenemedi!", "Tamam");
                }
            }
            else
            {
                await DisplayAlert("Hata", "Gerekli yerleri doldurun!", "Tamam");
            }

        }

        private async void SalonName_Update_Button_Clicked(object sender, EventArgs e)
        {
            if (saloonName.Text != null || saloonName.Text != "")
            {
                var app = Application.Current as App;
                UpdateSaloonNameDto saloon = new UpdateSaloonNameDto
                {
                    Id = Convert.ToInt32(app.USER_ID),
                    SaloonName = saloonName.Text
                };
                var response = await App.saloonManager.UpdateSaloonNameAsync(saloon);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Salon adı değiştirildi", "Tamam");
                }
                else
                {
                    await DisplayAlert("Hata", "Salon adı değiştirilemedi", "Tamam");
                }

            }
            else
            {
                await DisplayAlert("Hata", "Gerekli yerleri doldurun!", "Tamam");
            }
        }

        private async void SaloonLocation_Button_Clicked(object sender, EventArgs e)
        {
            if (saloonLocation.Text != null || saloonLocation.Text != "")
            {
                var app = Application.Current as App;
                UpdateSaloonLocation saloon = new UpdateSaloonLocation
                {
                    Id = Convert.ToInt32(app.USER_ID),
                    SaloonLocation = saloonLocation.Text
                };
                var response = await App.saloonManager.UpdateSaloonLocationAsync(saloon);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Salon konumu değiştirildi", "OK");
                }
                else
                {
                    await DisplayAlert("Hata", "Salon konumu değiştirilemedi", "OK");
                }
            }
            else
            {
                await DisplayAlert("Hata", "Gerekli yerleri doldurun!", "Tamam");
            }
        }

        private async void SaloonPhoto_Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported || !CrossMedia.Current.IsTakePhotoSupported)
                {

                    await DisplayAlert("Desteklenmiyor", "Cihazınız bu özelliği desteklemiyor!", "Tamam");
                    return;
                }

                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (saloonProfilePhoto == null)
                {
                    saloonProfilePhoto.Source = ImageSource.FromResource("camera.png");
                    await DisplayAlert("Hata", "Fotoğraf seçilemedi. Tekrar deneyiniz.", "Tamam");
                }
                else
                {
                    saloonProfilePhoto.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                    imagebyte = GetImageStreamAsBytes(selectedImageFile.GetStream());
                }
                var app = Application.Current as App;

                UpdateSaloonImageDto saloon = new UpdateSaloonImageDto
                {
                    Id = Convert.ToInt32(app.USER_ID),
                    SaloonImage = imagebyte
                };
                var response = await App.saloonManager.UpdateSaloonPhotoAsync(saloon);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Salon fotoğrafı değiştirildi", "Tamam");
                }
                else
                {
                    await DisplayAlert("Hata", "Salon fotoğrafı değiştirilemedi", "Tamam");
                }

            }
            catch (Exception)
            {
                await DisplayAlert("Hata", "Fotoğraf seçilemedi. Tekrar deneyiniz.", "Tamam");
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
                UpdatePasswordDto saloon = new UpdatePasswordDto
                {
                    Id = Convert.ToInt32(app.USER_ID),
                    OldPassword = oldPassword.Text,
                    NewPassword = newPassword.Text
                };
                var response = await App.saloonManager.UpdateSaloonPasswordAsync(saloon);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Şifre değiştirildi", "Tamam");
                    await Navigation.PopAsync();
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

        private async void DeletePrice_Button_Clicked(object sender, EventArgs e)
        {
            if (prices.SelectedItem != null)
            {
                try
                {
                    var price = PricesObservable.FirstOrDefault(p => p.PriceName == prices.SelectedItem.ToString());
                    var response = await App.saloonManager.DeletePriceAsync(price.Id);
                    if (response.IsSuccessStatusCode.Equals(true))
                    {
                        await DisplayAlert("Tebrikler", "Fiyat silindi", "Tamam");
                        await Navigation.PopAsync();
                    }
                }
                catch (Exception)
                {

                    await DisplayAlert("Hata", "Fiyat silinemedi", "Tamam");
                }
            }
            else
            {
                await DisplayAlert("Hata", "Lütfen seçim yapın", "Tamam");
            }




        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            try
            {
                var app = Application.Current as App;
                var result = await client.GetStringAsync(App.API_URL + $"Saloon/saloonprices?id={Convert.ToInt32(app.USER_ID)}");
                var result2 = JsonConvert.DeserializeObject<List<Price>>(result);
                foreach (var item in result2)
                {
                    PricesObservable.Add(item);
                }

                foreach (var item in PricesObservable)
                {
                    prices.Items.Add(item.PriceName);
                }

            }
            catch (Exception)
            {

                await DisplayAlert("Hata", "Fiyat listesi bulunamadı", "Tamam");
            }

        }
    }
}