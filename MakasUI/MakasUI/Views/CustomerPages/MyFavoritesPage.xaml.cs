using MakasUI.Models;
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
    public partial class MyFavoritesPage : ContentPage
    {
        public List<Saloon> Categories = new List<Saloon>();
        public MyFavoritesPage()
        {
            InitializeComponent();

            Categories.Add(new Saloon { SaloonName = "MEO kuafor", SaloonImage = "chair.png", SaloonRate = 8.2 });
            Categories.Add(new Saloon { SaloonName = "DAN kuafor", SaloonImage = "help.png", SaloonRate = 5.6 });
            Categories.Add(new Saloon { SaloonName = "GWEN kuafor", SaloonImage = "user.png", SaloonRate = 4.4 });

            FavoriteListView.ItemsSource = Categories;
        }
        private async void Fav_Delete_Clicked(object sender, EventArgs e)
        {
            // DisplayAlert("asd", "Test", "OK");
            
            ImageButton btn = (ImageButton)sender;
            await btn.ScaleTo(1.2, 250, Easing.SpringIn);
            var ob = btn.CommandParameter as Saloon;
            Categories.Remove(ob);
            FavoriteListView.ItemsSource = Categories;
            await btn.ScaleTo(1.0, 50, Easing.SpringOut);



        }

        private async void FavoriteListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedInstructor = e.Item as Saloon;
            await Navigation.PushAsync(new SaloonProfilePage(selectedInstructor));

        }

        private void ImageButton_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}