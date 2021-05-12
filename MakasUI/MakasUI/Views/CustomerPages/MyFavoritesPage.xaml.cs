using MakasUI.Functions;
using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFavoritesPage : ContentPage
    {
        Customer presentCustomer;
        public ObservableCollection<CustomerFavoritesDto> FavoritesCollections { get; set; }
        //public List<Saloon> Categories = new List<Saloon>();
        public MyFavoritesPage()
        {
            InitializeComponent();

            FavoritesCollections = new ObservableCollection<CustomerFavoritesDto>();
        }
        /*private async void Fav_Delete_Clicked(object sender, EventArgs e)
        {
            // DisplayAlert("asd", "Test", "OK");

            ImageButton btn = (ImageButton)sender;
            await btn.ScaleTo(1.2, 250, Easing.SpringIn);
            var ob = btn.CommandParameter as Saloon;
            Categories.Remove(ob);
            FavoriteListView.ItemsSource = Categories;
            await btn.ScaleTo(1.0, 50, Easing.SpringOut);



        }
        */
        private async Task GetCustomerProfile()
        {
            var app = Application.Current as App;
            var customer = await App.customerManager.GetCustomerAsync(Convert.ToInt32(app.USER_ID));
            presentCustomer = customer;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            FavoritesCollections.Clear();
            await GetCustomerProfile();
            await getItems();

        }
        public async Task getItems()
        {
            try
            {
                var result = await App.customerManager.GetCustomerFavoritesAsync(presentCustomer.Id);
                foreach (var item in result)
                {
                    FavoritesCollections.Add(item);
                }
                FavoriteListView.ItemsSource = FavoritesCollections;
            }
            catch (Exception)
            {
                await DisplayAlert("Hata", "Favori bulunamadı", "Ok");
            }
        }

        private async void Go_Profile_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            int Id = (int)btn.CommandParameter;
            await Navigation.PushAsync(new SaloonProfilePage(Id));

        }

        private async void UnFavorite_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            int Id = (int)btn.CommandParameter;

            try
            {
                var favorite = FavoritesCollections.FirstOrDefault(f => f.Id == Id);
                var response = await App.customerManager.UnFavoriteAsync(favorite.Id);
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Tebrikler", "Favorilerden çıkarıldı.", "Tamam");
                    OnAppearing();
                }
            }
            catch (Exception)
            {

                await DisplayAlert("Hata", "Fiyat silinemedi", "Tamam");
            }

        }
    }
}