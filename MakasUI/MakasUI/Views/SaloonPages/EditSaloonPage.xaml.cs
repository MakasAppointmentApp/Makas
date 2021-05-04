using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForSaloon;
using MakasUI.Services.SaloonServices;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditSaloonPage : ContentPage
    {
        int saloonId = 2;//BURADA LOGİN YAPAN SALONUN IDSİNİ ÇEKECEĞİZ ASLINDA

        public byte[] imagebyte;
        SaloonUpdateService service = new SaloonUpdateService();
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

                    await DisplayAlert("Not supported", "Your device does not currently support this functionality.", "OK");
                    return;
                }

                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImage == null)
                {
                    await DisplayAlert("Error", "Could not get the image , please try again.", "OK");
                }
                selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                imagebyte = GetImageStreamAsBytes(selectedImageFile.GetStream());



            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not get the image , please try again.", "OK");
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
            AddWorkerDto worker = new AddWorkerDto
            {
                SaloonId = saloonId,
                WorkerName = kuaförName.Text,
                WorkerPhoto = imagebyte
            };
            var response = await service.AddWorkerAsync(worker);
            if (response.IsSuccessStatusCode.Equals(true))
            {
                await DisplayAlert("Tebrikler", "Yeni çalışan ekledi", "OK");
            }
            else
            {
                await DisplayAlert("Hata", "Yeni çalışan eklenemedi!", "OK");
            }

        }
        private async void AddPrice_Button_Clicked(object sender, EventArgs e)
        {
            AddPriceDto price = new AddPriceDto
            {
                SaloonId = saloonId,
                PriceName = priceName.Text,
                PriceAmount = Convert.ToDouble(priceAmount.Text)
            };
            var response = await service.AddPriceAsync(price);
            if (response.IsSuccessStatusCode.Equals(true))
            {
                await DisplayAlert("Tebrikler", "Yeni işlem ekledi", "OK");
            }
            else
            {
                await DisplayAlert("Hata", "Yeni işlem eklenemedi!", "OK");
            }

        }

        private async void SalonName_Update_Button_Clicked(object sender, EventArgs e)
        {
            UpdateSaloonNameDto saloon = new UpdateSaloonNameDto
            {
                Id = saloonId,
                SaloonName = saloonName.Text
            };
            var response = await service.UpdateSaloonNameAsync(saloon);
            if (response.IsSuccessStatusCode.Equals(true))
            {
                await DisplayAlert("Tebrikler", "Salon adı değiştirildi", "OK");
            }
            else
            {
                await DisplayAlert("Hata", "Salon adı değiştirilemedi", "OK");
            }
        }

        private async void SaloonLocation_Button_Clicked(object sender, EventArgs e)
        {
            UpdateSaloonLocation saloon = new UpdateSaloonLocation
            {
                Id = saloonId,
                SaloonLocation = saloonLocation.Text
            };
            var response = await service.UpdateSaloonLocationAsync(saloon);
            if (response.IsSuccessStatusCode.Equals(true))
            {
                await DisplayAlert("Tebrikler", "Salon konumu değiştirildi", "OK");
            }
            else
            {
                await DisplayAlert("Hata", "Salon konumu değiştirilemedi", "OK");
            }
        }

        private async void SaloonPhoto_Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported || !CrossMedia.Current.IsTakePhotoSupported)
                {

                    await DisplayAlert("Not supported", "Your device does not currently support this functionality.", "OK");
                    return;
                }

                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (saloonProfilePhoto == null)
                {
                    await DisplayAlert("Error", "Could not get the image , please try again.", "OK");
                }
                saloonProfilePhoto.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                imagebyte = GetImageStreamAsBytes(selectedImageFile.GetStream());

                UpdateSaloonImageDto saloon = new UpdateSaloonImageDto
                {
                    Id = saloonId,
                    SaloonImage = imagebyte
                };
                var response = await service.UpdateSaloonPhotoAsync(saloon);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Salon fotoğrafı değiştirildi", "OK");
                }
                else
                {
                    await DisplayAlert("Hata", "Salon fotoğrafı değiştirilemedi", "OK");
                }

            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not get the image , please try again.", "OK");
            }
        }

        private async void PasswordChange_Button_Clicked(object sender, EventArgs e)
        {
            if (verifyPassword.Text == newPassword.Text)
            {
                UpdatePasswordDto saloon = new UpdatePasswordDto
                {
                    Id = saloonId,
                    OldPassword = oldPassword.Text,
                    NewPassword = newPassword.Text
                };
                var response = await service.UpdateSaloonPasswordAsync(saloon);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Şifre değiştirildi", "OK");
                }
                else
                {
                    await DisplayAlert("Hata", "Şifre değiştirilemedi", "OK");
                }
            }
            else
            {
                await DisplayAlert("Hata", "Şifreler uyuşmuyor", "OK");
            }
        }

        private async void DeletePrice_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var price = PricesObservable.FirstOrDefault(p => p.PriceName == prices.SelectedItem.ToString());
                var response = await service.DeletePriceAsync(price.Id);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Fiyat silindi", "OK");
                }
            }
            catch (Exception)
            {

                await DisplayAlert("Hata", "Fiyat silinemedi", "OK");
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
                var result = await client.GetStringAsync(App.API_URL + $"Saloon/saloonprices?id={saloonId}");
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
                
                await DisplayAlert("Hata", "Fiyat listesi bulunamadı", "Ok");
            }
            
        }
    }
}