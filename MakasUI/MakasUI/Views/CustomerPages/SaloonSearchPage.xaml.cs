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
        public SaloonSearchPage()
        {
            InitializeComponent();
        }
        async void Listele_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SaloonListPage());
        }
    }
}