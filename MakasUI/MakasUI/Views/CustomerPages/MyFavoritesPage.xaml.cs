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
        public MyFavoritesPage()
        {
            InitializeComponent();
            var Categories = new List<Saloon>
            {
                new Saloon {SaloonName="MEO kuafor",SaloonImage="chair.png",SaloonRate=8.2 },
                new Saloon {SaloonName="DAN kuafor",SaloonImage="help.png",SaloonRate=5.6 },
                new Saloon {SaloonName="GWEN kuafor",SaloonImage="user.png",SaloonRate=4.4 }

            };

            FavoriteListView.ItemsSource = Categories;
        }
        private void Fav_Delete_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("asd", "Test", "OK");
            /*Button btn = (Button)sender;

            var ob = btn.CommandParameter as Kuafor;
            */
        }
    }
}