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
        }

        async void Listele_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SaloonListPage());
        }
    }
}