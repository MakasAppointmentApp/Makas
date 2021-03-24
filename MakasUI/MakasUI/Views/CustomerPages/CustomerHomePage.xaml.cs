using MakasUI.Functions;
using MakasUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerHomePage : Shell
    {
        public CustomerHomePage()
        {
            InitializeComponent();
            var Categories = new List<Kuafor>
            {
                new Kuafor {kuaforName="MEO kuafor",kuaforPP="chair.png",kuaforRate="8,2" },
                new Kuafor {kuaforName="DAN kuafor",kuaforPP="help.png",kuaforRate="4,2" },
                new Kuafor {kuaforName="GWEN kuafor",kuaforPP="user.png",kuaforRate="5,2" }

            };
            
            FavoriteListView.ItemsSource = Categories;
        }
        async void Listele_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SaloonListPage());
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