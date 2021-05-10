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
        public ObservableCollection<CustomerFavoritesDto> AppointmentsCollection { get; set; }
        //public List<Saloon> Categories = new List<Saloon>();
        public MyFavoritesPage()
        {
            InitializeComponent();

            AppointmentsCollection = new ObservableCollection<CustomerFavoritesDto>();
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
            AppointmentsCollection.Clear();
            await GetCustomerProfile();

            try
            {
                var result = await App.customerManager.GetCustomerFavoritesAsync(presentCustomer.Id);
                foreach (var item in result)
                {
                    AppointmentsCollection.Add(item);
                }
                FavoriteListView.ItemsSource = AppointmentsCollection;
            }
            catch (Exception)
            {
                await DisplayAlert("Hata", "Favori bulunamadı", "Ok");
            }

        }
        private void FavoriteListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            /* var selectedInstructor = e.Item as Saloon;
             await Navigation.PushAsync(new SaloonProfilePage(selectedInstructor));*/

        }

        private void ImageButton_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}